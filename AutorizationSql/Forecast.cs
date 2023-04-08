using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutorizationSql
{
    public class ForecastTable : DataTable
    {
        // An instance of a DataTable with some default columns.  Expressions help quickly calculate E
        public ForecastTable()
        {
            this.Columns.Add("Instance", typeof(Int32));    //The position in which this value occurred in the time-series
            this.Columns.Add("Value", typeof(Decimal));     //The value which actually occurred
            this.Columns.Add("Forecast", typeof(Decimal));  //The forecasted value for this instance
            this.Columns.Add("Holdout", typeof(Boolean));   //Identifies a holdout actual value row, for testing after err is calculated

            //E(t) = D(t) - F(t)
            this.Columns.Add("Error", typeof(Decimal), "Forecast-Value");
            //Absolute Error = |E(t)|
            this.Columns.Add("AbsoluteError", typeof(Decimal), "IIF(Error>=0, Error, Error * -1)");
            //Percent Error = E(t) / D(t)
            this.Columns.Add("PercentError", typeof(Decimal), "IIF(Value<>0, Error / Value, Null)");
            //Absolute Percent Error = |E(t)| / D(t)
            this.Columns.Add("AbsolutePercentError", typeof(Decimal), "IIF(Value <> 0, AbsoluteError / Value, Null)");
        }
    }

    public class TimeSeries
    {
        public const Int32 DEFAULT_IGNORE = 3;
        public const Int32 DEFAULT_HOLDOUT = 6;

        //Bayes: use prior actual value as forecast
        public static ForecastTable naive(decimal[] values, int Extension, int Holdout)
        {
            ForecastTable dt = new ForecastTable();

            for (Int32 i = 0; i < (values.Length + Extension); i++)
            {
                //Insert a row for each value in set
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);

                row.BeginEdit();
                //assign its sequence number
                row["Instance"] = i;

                //if i is in the holdout range of values
                row["Holdout"] = (i > (values.Length - 1 - Holdout)) && (i < values.Length);

                if (i < values.Length)
                { //processing values which actually occurred
                  //Assign the actual value to the DataRow
                    row["Value"] = values[i];
                    if (i == 0)
                    {
                        //first row, value gets itself
                        row["Forecast"] = values[i];
                    }
                    else
                    {
                        //Put the prior row's value into the current row's forecasted value
                        row["Forecast"] = values[i - 1];
                    }
                }
                else
                {//Extension rows
                    row["Forecast"] = values[values.Length - 1];
                }
                row.EndEdit();
            }
            dt.AcceptChanges();
            return dt;
        }

        //
        //Simple Moving Average
        //
        //            ( Dt + D(t-1) + D(t-2) + ... + D(t-n+1) )
        //  F(t+1) =  -----------------------------------------
        //                              n
        public static ForecastTable simpleMovingAverage(decimal[] values, int Extension, int Periods, int Holdout)
        {
            ForecastTable dt = new ForecastTable();

            for (Int32 i = 0; i < values.Length + Extension; i++)
            {
                //Insert a row for each value in set
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);

                row.BeginEdit();
                //assign its sequence number
                row["Instance"] = i;
                if (i < values.Length)
                {//processing values which actually occurred
                    row["Value"] = values[i];
                }

                //Indicate if this is a holdout row
                row["Holdout"] = (i > (values.Length - Holdout)) && (i < values.Length);

                if (i == 0)
                {//Initialize first row with its own value
                    row["Forecast"] = values[i];
                }
                else if (i <= values.Length - Holdout)
                {//processing values which actually occurred, but not in holdout set
                    decimal avg = 0;
                    DataRow[] rows = dt.Select("Instance>=" + (i - Periods).ToString() + " AND Instance < " + i.ToString(), "Instance");
                    foreach (DataRow priorRow in rows)
                    {
                        avg += (Decimal)priorRow["Value"];
                    }
                    avg /= rows.Length;
                    avg = Math.Round(avg, 3);
                    row["Forecast"] = avg;
                }
                else
                {//must be in the holdout set or the extension
                    decimal avg = 0;

                    //get the Periods-prior rows and calculate an average actual value
                    DataRow[] rows = dt.Select("Instance>=" + (i - Periods).ToString() + " AND Instance < " + i.ToString(), "Instance");
                    foreach (DataRow priorRow in rows)
                    {
                        if ((Int32)priorRow["Instance"] < values.Length)
                        {//in the test or holdout set
                            avg += (Decimal)priorRow["Value"];
                        }
                        else
                        {//extension, use forecast since we don't have an actual value
                            avg += (Decimal)priorRow["Forecast"];
                        }
                    }
                    avg /= rows.Length;

                    //set the forecasted value
                    avg = Math.Round(avg, 3);
                    row["Forecast"] = avg;
                }
                row.EndEdit();
            }

            dt.AcceptChanges();
            return dt;
        }

        //
        //Weighted Moving Average
        //            
        //  F(t+1) =  (Weight1 * D(t)) + (Weight2 * D(t-1)) + (Weight3 * D(t-2)) + ... + (WeightN * D(t-n+1))
        //          
        public static ForecastTable weightedMovingAverage(decimal[] values, int Extension, params decimal[] PeriodWeight)
        {
            //PeriodWeight[].Length is used to determine the number of periods over which to average
            //PeriodWeight[x] is used to apply a weight to the prior period's value

            //Make sure PeriodWeight values add up to 100%
            decimal test = 0;
            foreach (decimal weight in PeriodWeight)
            {
                test += weight;
            }
            if (test != 1)
            {
                MessageBox.Show("Period weights must add up to 1.0", "Invalid parameters", MessageBoxButtons.OK);
                return null;
            }

            ForecastTable dt = new ForecastTable();

            for (Int32 i = 0; i < values.Length + Extension; i++)
            {
                //Insert a row for each value in set
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);

                row.BeginEdit();
                //assign its sequence number
                row["Instance"] = i;

                if (i < values.Length)
                {//we're in the test set
                    row["Value"] = values[i];
                }

                if (i == 0)
                {//initialize forecast with first row's value
                    row["Forecast"] = values[i];
                }
                else if ((i < values.Length) && (i < PeriodWeight.Length))
                {//processing one of the first rows, before we've advanced enough to properly weight past rows
                    decimal avg = 0;

                    //Get the datarows representing the values within the WMA length
                    DataRow[] rows = dt.Select("Instance>=" + (i - PeriodWeight.Length).ToString() + " AND Instance < " + i.ToString(), "Instance");
                    for (int j = 0; j < rows.Length; j++)
                    {//apply an initial, uniform weight (1 / rows.Length) to the initial rows
                        avg += (Decimal)rows[j]["Value"] * (1 / rows.Length);
                    }
                    avg = Math.Round(avg, 3);
                    row["Forecast"] = avg;
                }
                else if ((i < values.Length) && (i >= PeriodWeight.Length))
                {//Out of initial rows and processing the test set
                    decimal avg = 0;

                    //Get the rows within the weight range just prior to the current row
                    DataRow[] rows = dt.Select("Instance>=" + (i - PeriodWeight.Length).ToString() + " AND Instance < " + i.ToString(), "Instance");
                    for (int j = 0; j <= rows.Length - 1; j++)
                    {//Apply the appropriate period's weight to the value
                        avg += (Decimal)rows[j]["Value"] * PeriodWeight[j];
                    }
                    //Assign the forecasted value to the current row
                    avg = Math.Round(avg, 3);
                    row["Forecast"] = avg;
                }
                else
                {//into the extension
                    decimal avg = 0;

                    DataRow[] rows = dt.Select("Instance>=" + (i - PeriodWeight.Length).ToString() + " AND Instance < " + i.ToString(), "Instance");
                    for (int j = 0; j < rows.Length; j++)
                    {//with no actual values to weight, use the previous rows' forecast instead
                        avg += (Decimal)rows[j]["Forecast"] * PeriodWeight[j];
                    }
                    avg = Math.Round(avg, 3);
                    row["Forecast"] = avg;
                }
                row.EndEdit();
            }

            dt.AcceptChanges();
            return dt;
        }

        //
        //Exponential Smoothing
        //
        //  F(t+1) =    ( Alpha * D(t) ) + (1 - Alpha) * F(t)
        //
        public static ForecastTable exponentialSmoothing(decimal[] values, int Extension, decimal Alpha)
        {
            ForecastTable dt = new ForecastTable();

            for (Int32 i = 0; i < (values.Length + Extension); i++)
            {
                //Insert a row for each value in set
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);

                row.BeginEdit();
                //assign its sequence number
                row["Instance"] = i;
                if (i < values.Length)
                {//test set
                    row["Value"] = values[i];
                    if (i == 0)
                    {//initialize first value
                        row["Forecast"] = values[i];
                    }
                    else
                    {//main area of forecasting
                        DataRow priorRow = dt.Select("Instance=" + (i - 1).ToString())[0];
                        decimal PriorForecast = (Decimal)priorRow["Forecast"];
                        decimal PriorValue = (Decimal)priorRow["Value"];
                        
                        row["Forecast"] = Math.Round(PriorForecast + (Alpha * (PriorValue - PriorForecast)),3);
                    }
                }
                else
                {//extension has to use prior forecast instead of prior value
                    DataRow priorRow = dt.Select("Instance=" + (i - 1).ToString())[0];
                    decimal PriorForecast = (Decimal)priorRow["Forecast"];
                    decimal PriorValue = (Decimal)priorRow["Forecast"];

                    row["Forecast"] = Math.Round(PriorForecast + (Alpha * (PriorValue - PriorForecast)),3);
                }
                row.EndEdit();
            }

            dt.AcceptChanges();

            return dt;
        }

        //
        // Adaptive Rate Smoothing
        //
        public static ForecastTable adaptiveRateSmoothing(decimal[] values, int Extension, decimal MinGamma, decimal MaxGamma)
        {
            ForecastTable dt = new ForecastTable();

            for (Int32 i = 0; i < (values.Length + Extension); i++)
            {
                //Insert a row for each value in set
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);

                row.BeginEdit();
                //assign its sequence number
                row["Instance"] = i;
                if (i < values.Length)
                {
                    row["Value"] = values[i];
                    if (i == 0)
                    {//initialize first row
                        row["Forecast"] = values[i];
                    }
                    else
                    {//calculate gamma and forecast value
                        DataRow priorRow = dt.Select("Instance=" + (i - 1).ToString())[0];
                        decimal PriorForecast = (Decimal)priorRow["Forecast"];
                        decimal PriorValue = (Decimal)priorRow["Value"];

                        decimal Gamma = Math.Abs(TrackingSignal(dt, false, 3));
                        if (Gamma < MinGamma)
                            Gamma = MinGamma;
                        if (Gamma > MaxGamma)
                            Gamma = MaxGamma;

                        row["Forecast"] = Math.Round(PriorForecast + (Gamma * (PriorValue - PriorForecast)),3);
                    }
                }
                else
                {//extension set, can't use actual values anymore
                    DataRow priorRow = dt.Select("Instance=" + (i - 1).ToString())[0];
                    decimal PriorForecast = (Decimal)priorRow["Forecast"];
                    decimal PriorValue = (Decimal)priorRow["Forecast"];

                    decimal Gamma = Math.Abs(TrackingSignal(dt, false, 3));
                    if (Gamma < MinGamma)
                        Gamma = MinGamma;
                    if (Gamma > MaxGamma)
                        Gamma = MaxGamma;

                    row["Forecast"] = Math.Round(PriorForecast + (Gamma * (PriorValue - PriorForecast)),3);
                }
                row.EndEdit();
            }

            dt.AcceptChanges();

            return dt;

        }

        #region "Forecast Performance Measures"

        //MeanSignedError = Sum(E(t)) / n
        public static decimal MeanSignedError(ForecastTable dt, bool Holdout, int IgnoreInitial)
        {
            string Filter = "Error Is Not Null AND Instance > " + IgnoreInitial.ToString();
            if (Holdout)
                Filter += " AND Holdout=True";

            if (dt.Select(Filter).Length == 0)
                return 0;
            return (Decimal)dt.Compute("Avg(Error)", Filter);
        }

        //MeanAbsoluteError = Sum(|E(t)|) / n
        public static decimal MeanAbsoluteError(ForecastTable dt, bool Holdout, int IgnoreInitial)
        {
            string Filter = "AbsoluteError Is Not Null AND Instance > " + IgnoreInitial.ToString();
            if (Holdout)
                Filter += " AND Holdout=True";

            if (dt.Select(Filter).Length == 0)
                return 0;
            return (Decimal)dt.Compute("Avg(AbsoluteError)", Filter);
        }

        //MeanPercentError = Sum( PercentError ) / n
        public static decimal MeanPercentError(ForecastTable dt, bool Holdout, int IgnoreInitial)
        {
            string Filter = "PercentError Is Not Null AND Instance > " + IgnoreInitial.ToString();
            if (Holdout)
                Filter += " AND Holdout=True";

            if (dt.Select(Filter).Length == 0)
                return 0;
            return (Decimal)dt.Compute("Avg(PercentError)", Filter);
        }

        //MeanAbsolutePercentError = Sum( |PercentError| ) / n
        public static decimal MeanAbsolutePercentError(ForecastTable dt, bool Holdout, int IgnoreInitial)
        {
            string Filter = "AbsolutePercentError Is Not Null AND Instance > " + IgnoreInitial.ToString();
            if (Holdout)
                Filter += " AND Holdout=True";

            if (dt.Select(Filter).Length == 0)
                return 1;
            return (Decimal)dt.Compute("AVG(AbsolutePercentError)", Filter);
        }

        //Tracking signal = MeanSignedError / MeanAbsoluteError
        public static decimal TrackingSignal(ForecastTable dt, bool Holdout, int IgnoreInitial)
        {
            decimal MAE = MeanAbsoluteError(dt, Holdout, IgnoreInitial);
            if (MAE == 0)
                return 0;

            return MeanSignedError(dt, Holdout, IgnoreInitial) / MAE;
        }

        //MSE = Sum( E(t)^2 ) / n
        public static decimal MeanSquaredError(ForecastTable dt, bool Holdout, int IgnoreInitial, int DegreesOfFreedom)
        {
            decimal SquareError = 0;
            string Filter = "Error Is Not Null AND Instance > " + IgnoreInitial.ToString();
            if (Holdout)
                Filter += " AND Holdout=True";

            DataRow[] rows = dt.Select(Filter);
            if (rows.Length == 0)
                return 0;

            foreach (DataRow row in rows)
            {
                SquareError = (Decimal)Math.Pow(Double.Parse(row["Error"].ToString()), (Double)2.0);
            }
            return SquareError / (dt.Rows.Count - DegreesOfFreedom);
        }

        //CumulativeSignedError = Sum( E(t) )
        public static decimal CumulativeSignedError(ForecastTable dt, bool Holdout, int IgnoreInitial)
        {
            string Filter = "Error Is Not Null AND Instance > " + IgnoreInitial.ToString();
            if (Holdout)
                Filter += " AND Holdout=True";

            if (dt.Select(Filter).Length == 0)
                return 0;
            return (Decimal)dt.Compute("SUM(Error)", Filter);
        }

        //CumulativeAbsoluteError = Sum( |E(t)| )
        public static decimal CumulativeAbsoluteError(ForecastTable dt, bool Holdout, int IgnoreInitial)
        {
            string Filter = "AbsoluteError Is Not Null AND Instance > " + IgnoreInitial.ToString();
            if (Holdout)
                Filter += " AND Holdout=True";

            if (dt.Select(Filter).Length == 0)
                return 0;
            return (Decimal)dt.Compute("SUM(AbsoluteError)", Filter);
        }

        #endregion //Forecast Performance Measures

        public ITransformer Train(MLContext mlContext, string dataPath)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<Data_Fromcsv>(dataPath, hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "End").Append(mlContext.Transforms.Concatenate("Features", "Start", "Count_of_values")).Append(mlContext.Regression.Trainers.FastTree());

            var model = pipeline.Fit(dataView);

            return model;
        }

        public string TestSinglePrediction(MLContext mlContext, ITransformer model, float current_price)
        {
            var predictionFunction = mlContext.Model.CreatePredictionEngine<Data_Fromcsv, End_Prediction>(model);

            var taxiTripSample = new Data_Fromcsv()
            {
                Start = current_price,
                End = 0,//0.40495f
                Count_of_values = 75000
            };

            var prediction = predictionFunction.Predict(taxiTripSample);

            return Math.Round(prediction.End, 3).ToString();
        }

    }

    public class Data_Fromcsv
    {
        [LoadColumn(0)]
        public string Data;

        [LoadColumn(1)]
        public float Trash1;

        [LoadColumn(2)]
        public float Trash2;

        [LoadColumn(3)]
        public float Start;

        [LoadColumn(4)]
        public float End;

        [LoadColumn(5)]
        public float Count_of_values;
    }

    public class End_Prediction
    {
        [ColumnName("Score")]
        public float End;
    }

}
