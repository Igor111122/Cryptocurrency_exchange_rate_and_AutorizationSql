namespace AutorizationSql
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RedistrationButt = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.PasswordText = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.LoginText = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.DateBirth = new System.Windows.Forms.DateTimePicker();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.ChangeSexFemale = new MaterialSkin.Controls.MaterialRadioButton();
            this.ChangeSexMale = new MaterialSkin.Controls.MaterialRadioButton();
            this.ChangeSexOther = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.SityText = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // RedistrationButt
            // 
            this.RedistrationButt.AutoSize = false;
            this.RedistrationButt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RedistrationButt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.RedistrationButt.Depth = 0;
            this.RedistrationButt.HighEmphasis = true;
            this.RedistrationButt.Icon = null;
            this.RedistrationButt.Location = new System.Drawing.Point(285, 400);
            this.RedistrationButt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RedistrationButt.MouseState = MaterialSkin.MouseState.HOVER;
            this.RedistrationButt.Name = "RedistrationButt";
            this.RedistrationButt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.RedistrationButt.Size = new System.Drawing.Size(228, 36);
            this.RedistrationButt.TabIndex = 31;
            this.RedistrationButt.Text = "Регестрация";
            this.RedistrationButt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.RedistrationButt.UseAccentColor = false;
            this.RedistrationButt.UseVisualStyleBackColor = true;
            this.RedistrationButt.Click += new System.EventHandler(this.RedistrationButt_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(496, 95);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(57, 19);
            this.materialLabel2.TabIndex = 30;
            this.materialLabel2.Text = "Пароль";
            // 
            // PasswordText
            // 
            this.PasswordText.AnimateReadOnly = false;
            this.PasswordText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordText.Depth = 0;
            this.PasswordText.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PasswordText.LeadingIcon = null;
            this.PasswordText.Location = new System.Drawing.Point(488, 117);
            this.PasswordText.MaxLength = 50;
            this.PasswordText.MouseState = MaterialSkin.MouseState.OUT;
            this.PasswordText.Multiline = false;
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(258, 50);
            this.PasswordText.TabIndex = 29;
            this.PasswordText.Text = "";
            this.PasswordText.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(65, 95);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(46, 19);
            this.materialLabel1.TabIndex = 28;
            this.materialLabel1.Text = "Логин";
            // 
            // LoginText
            // 
            this.LoginText.AnimateReadOnly = false;
            this.LoginText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginText.Depth = 0;
            this.LoginText.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LoginText.LeadingIcon = null;
            this.LoginText.Location = new System.Drawing.Point(57, 117);
            this.LoginText.MaxLength = 50;
            this.LoginText.MouseState = MaterialSkin.MouseState.OUT;
            this.LoginText.Multiline = false;
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(258, 50);
            this.LoginText.TabIndex = 27;
            this.LoginText.Text = "";
            this.LoginText.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(64, 205);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(122, 19);
            this.materialLabel3.TabIndex = 33;
            this.materialLabel3.Text = "Дата рождения ";
            // 
            // DateBirth
            // 
            this.DateBirth.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.DateBirth.CalendarTitleForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.DateBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateBirth.Location = new System.Drawing.Point(57, 230);
            this.DateBirth.Name = "DateBirth";
            this.DateBirth.Size = new System.Drawing.Size(256, 29);
            this.DateBirth.TabIndex = 34;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(515, 203);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(30, 19);
            this.materialLabel4.TabIndex = 35;
            this.materialLabel4.Text = "Пол";
            // 
            // ChangeSexFemale
            // 
            this.ChangeSexFemale.AutoSize = true;
            this.ChangeSexFemale.Depth = 0;
            this.ChangeSexFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ChangeSexFemale.Location = new System.Drawing.Point(477, 222);
            this.ChangeSexFemale.Margin = new System.Windows.Forms.Padding(0);
            this.ChangeSexFemale.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ChangeSexFemale.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangeSexFemale.Name = "ChangeSexFemale";
            this.ChangeSexFemale.Ripple = true;
            this.ChangeSexFemale.Size = new System.Drawing.Size(102, 37);
            this.ChangeSexFemale.TabIndex = 36;
            this.ChangeSexFemale.TabStop = true;
            this.ChangeSexFemale.Text = "Женский";
            this.ChangeSexFemale.UseVisualStyleBackColor = true;
            // 
            // ChangeSexMale
            // 
            this.ChangeSexMale.AutoSize = true;
            this.ChangeSexMale.Depth = 0;
            this.ChangeSexMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ChangeSexMale.Location = new System.Drawing.Point(588, 222);
            this.ChangeSexMale.Margin = new System.Windows.Forms.Padding(0);
            this.ChangeSexMale.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ChangeSexMale.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangeSexMale.Name = "ChangeSexMale";
            this.ChangeSexMale.Ripple = true;
            this.ChangeSexMale.Size = new System.Drawing.Size(104, 37);
            this.ChangeSexMale.TabIndex = 37;
            this.ChangeSexMale.TabStop = true;
            this.ChangeSexMale.Text = "Мужской";
            this.ChangeSexMale.UseVisualStyleBackColor = true;
            // 
            // ChangeSexOther
            // 
            this.ChangeSexOther.AutoSize = true;
            this.ChangeSexOther.Depth = 0;
            this.ChangeSexOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ChangeSexOther.Location = new System.Drawing.Point(702, 222);
            this.ChangeSexOther.Margin = new System.Windows.Forms.Padding(0);
            this.ChangeSexOther.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ChangeSexOther.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangeSexOther.Name = "ChangeSexOther";
            this.ChangeSexOther.Ripple = true;
            this.ChangeSexOther.Size = new System.Drawing.Size(73, 37);
            this.ChangeSexOther.TabIndex = 38;
            this.ChangeSexOther.TabStop = true;
            this.ChangeSexOther.Text = "Иной";
            this.ChangeSexOther.UseVisualStyleBackColor = true;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(281, 287);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(47, 19);
            this.materialLabel5.TabIndex = 40;
            this.materialLabel5.Text = "Город";
            // 
            // SityText
            // 
            this.SityText.AnimateReadOnly = false;
            this.SityText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SityText.Depth = 0;
            this.SityText.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SityText.LeadingIcon = null;
            this.SityText.Location = new System.Drawing.Point(269, 309);
            this.SityText.MaxLength = 50;
            this.SityText.MouseState = MaterialSkin.MouseState.OUT;
            this.SityText.Multiline = false;
            this.SityText.Name = "SityText";
            this.SityText.Size = new System.Drawing.Size(258, 50);
            this.SityText.TabIndex = 39;
            this.SityText.Text = "";
            this.SityText.TrailingIcon = null;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.SityText);
            this.Controls.Add(this.ChangeSexOther);
            this.Controls.Add(this.ChangeSexMale);
            this.Controls.Add(this.ChangeSexFemale);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.DateBirth);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.RedistrationButt);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.LoginText);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton RedistrationButt;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        public MaterialSkin.Controls.MaterialTextBox PasswordText;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox LoginText;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.DateTimePicker DateBirth;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        public MaterialSkin.Controls.MaterialRadioButton ChangeSexFemale;
        public MaterialSkin.Controls.MaterialRadioButton ChangeSexMale;
        public MaterialSkin.Controls.MaterialRadioButton ChangeSexOther;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialTextBox SityText;
    }
}