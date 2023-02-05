using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace AutorizationSql
{
    public partial class FormAfterEnter : MaterialForm
    {
        string BitcoinPrice2, EthereumPrice2, TetherPrice2, LitecoinPrice2, RipplePrice2,
            DogecoinPrice2, SolanaPrice2, MoneroPrice2, CardanoPrice2, TravalaPrice2, TerraPrice2;

        string Bitcoin_24h_Chg2, Ethereum_24h_Chg2, Tether_24h_Chg2, Litecoin_24h_Chg2, 
            Ripple_24h_Chg2, Dogecoin_24h_Chg2, Solana_24h_Chg2, Monero_24h_Chg2, Cardano_24h_Chg2, Travala_24h_Chg2, Terra_24h_Chg2;
        string label_waiting_text = "Курс может отображаться не сразу";

        public FormAfterEnter()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            string theme_of_reg_form = TextColor.Text;

            if (theme_of_reg_form == "1")
            {
                materialSkinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue800, MaterialSkin.Accent.Cyan700, MaterialSkin.TextShade.WHITE);
            }
            if (theme_of_reg_form == "2")
            {
                materialSkinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Green800, MaterialSkin.Primary.Green900, MaterialSkin.Primary.Green900, MaterialSkin.Accent.LightGreen700, MaterialSkin.TextShade.WHITE);
            }
            if (theme_of_reg_form == "3")
            {
                materialSkinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Orange800, MaterialSkin.Primary.Orange900, MaterialSkin.Primary.Orange800, MaterialSkin.Accent.Yellow700, MaterialSkin.TextShade.WHITE);
            }
        }

        private void FormAfterEnter_Load(object sender, EventArgs e)
        {
            TextColor.Text = "Поздравляю вы прошли авторизацию";
            
            Thread myThread = new Thread(new ThreadStart(update_price));
            myThread.Start();

            Thread myThread2 = new Thread(new ThreadStart(update_24h_Chg));
            myThread2.Start();

            if (Bitcoin_24h_Chg.Text[0] == '-')
            {
                Bitcoin_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Bitcoin_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Ethereum_24h_Chg.Text[0] == '-')
            {
                Ethereum_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Ethereum_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Tether_24h_Chg.Text[0] == '-')
            {
                Tether_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Tether_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Litecoin_24h_Chg.Text[0] == '-')
            {
                Litecoin_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Litecoin_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Ripple_24h_Chg.Text[0] == '-')
            {
                Ripple_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Ripple_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Dogecoin_24h_Chg.Text[0] == '-')
            {
                Dogecoin_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Dogecoin_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Solana_24h_Chg.Text[0] == '-')
            {
                Solana_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Solana_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Monero_24h_Chg.Text[0] == '-')
            {
                Monero_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Monero_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Cardano_24h_Chg.Text[0] == '-')
            {
                Cardano_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Cardano_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Travala_24h_Chg.Text[0] == '-')
            {
                Travala_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Travala_24h_Chg.ForeColor = Color.Green;
            }
            //--------------------------------------------------------------------------------
            if (Terra_24h_Chg.Text[0] == '-')
            {
                Terra_24h_Chg.ForeColor = Color.Red;
            }
            else
            {
                Terra_24h_Chg.ForeColor = Color.Green;
            }

        }

        private void FormAfterEnter_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Thread myThread = new Thread(new ThreadStart(update_price));
            myThread.Start();
            BitcoinPrice.Text = BitcoinPrice2;
            EthereumPrice.Text = EthereumPrice2;
            TetherPrice.Text = TetherPrice2;
            LitecoinPrice.Text = LitecoinPrice2;
            RipplePrice.Text = RipplePrice2;
            DogecoinPrice.Text = DogecoinPrice2;
            SolanaPrice.Text = SolanaPrice2;
            MoneroPrice.Text = MoneroPrice2;
            CardanoPrice.Text = CardanoPrice2;
            TravalaPrice.Text = TravalaPrice2;
            TerraPrice.Text = TerraPrice2;


            Thread myThread2 = new Thread(new ThreadStart(update_24h_Chg));
            myThread2.Start();
            Bitcoin_24h_Chg.Text = Bitcoin_24h_Chg2;
            Ethereum_24h_Chg.Text = Ethereum_24h_Chg2;
            Tether_24h_Chg.Text = Tether_24h_Chg2;
            Litecoin_24h_Chg.Text = Litecoin_24h_Chg2;
            Ripple_24h_Chg.Text = Ripple_24h_Chg2;
            Dogecoin_24h_Chg.Text = Dogecoin_24h_Chg2;
            Solana_24h_Chg.Text = Solana_24h_Chg2;
            Monero_24h_Chg.Text = Monero_24h_Chg2;
            Cardano_24h_Chg.Text = Cardano_24h_Chg2;
            Travala_24h_Chg.Text = Travala_24h_Chg2;
            Terra_24h_Chg.Text = Terra_24h_Chg2;
            Label_time_waiting.Text = label_waiting_text;
        }

        string Price_coin(string url)
        {

            string responseString = string.Empty;
            WebClient webClient = new WebClient();
            responseString = webClient.DownloadString(url);
            int indexofprice = responseString.IndexOf("price") + 8;
            return responseString.Substring(indexofprice, responseString.Length - 7 - indexofprice);
        }

        string Price_change_coin(string url)
        {
            WebClient webClient = new WebClient();
            string responseString = string.Empty;
            responseString = webClient.DownloadString(url);
            int indexofprice = responseString.IndexOf("priceChangePercent") + 21;

            return responseString.Substring(indexofprice, 5);
        }
        
        void update_price()
        {
            BitcoinPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=BTCUSDC");
            EthereumPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=ETHUSDC");
            TetherPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=USDCUSDT");
            LitecoinPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=LTCUSDC");
            RipplePrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=XRPUSDC");
            DogecoinPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=DOGEUSDT");
            SolanaPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=SOLUSDC");
            MoneroPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=XMRUSDT");
            CardanoPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=ADAUSDC");
            TravalaPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=AVAUSDT");
            TerraPrice2 = Price_coin("https://api.binance.com/api/v3/ticker/price?symbol=LUNAUSDT");
            label_waiting_text = "                                                                                     ";
        }


        void update_24h_Chg()
        {
            Bitcoin_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=BTCUSDC");
            Ethereum_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=ETHUSDC");
            Tether_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=USDCUSDT");
            Litecoin_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=LTCUSDC");
            Ripple_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=XRPUSDC");
            Dogecoin_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=DOGEUSDT");
            Solana_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=SOLUSDC");
            Monero_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=XMRUSDT");
            Cardano_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=ADAUSDC");
            Travala_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=AVAUSDT");
            Terra_24h_Chg2 = Price_change_coin("https://api.binance.com/api/v3/ticker/24hr?symbol=LUNAUSDT");
        }

        private void ButtonBitcoin_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

        private void ButtonEtherium_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

        private void ButtonTether_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

        private void ButtonLitecoin_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

        private void ButtonRipple_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

        private void ButtonDoge_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

        private void ButtonSolana_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

        private void ButtonMonero_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

        private void ButtonCardano_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

        private void ButtonTravala_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

        private void ButtonTerra_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.binance.com/ru/buy-sell-crypto");
        }

    }
}
