namespace AutorizationSql
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PictureChengecolor = new System.Windows.Forms.PictureBox();
            this.ChangeGreen = new MaterialSkin.Controls.MaterialRadioButton();
            this.ChangeBlue = new MaterialSkin.Controls.MaterialRadioButton();
            this.ChangeOrange = new MaterialSkin.Controls.MaterialRadioButton();
            this.PanelChangecolor = new System.Windows.Forms.Panel();
            this.LoginText = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.PasswordText = new MaterialSkin.Controls.MaterialTextBox();
            this.EnterBut = new MaterialSkin.Controls.MaterialButton();
            this.RegBut = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.PictureChengecolor)).BeginInit();
            this.PanelChangecolor.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureChengecolor
            // 
            this.PictureChengecolor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.PictureChengecolor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureChengecolor.BackgroundImage")));
            this.PictureChengecolor.InitialImage = ((System.Drawing.Image)(resources.GetObject("PictureChengecolor.InitialImage")));
            this.PictureChengecolor.Location = new System.Drawing.Point(814, 26);
            this.PictureChengecolor.Name = "PictureChengecolor";
            this.PictureChengecolor.Size = new System.Drawing.Size(35, 35);
            this.PictureChengecolor.TabIndex = 16;
            this.PictureChengecolor.TabStop = false;
            this.PictureChengecolor.Click += new System.EventHandler(this.PictureChengecolor_Click);
            // 
            // ChangeGreen
            // 
            this.ChangeGreen.AutoSize = true;
            this.ChangeGreen.BackColor = System.Drawing.Color.Transparent;
            this.ChangeGreen.Depth = 0;
            this.ChangeGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ChangeGreen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ChangeGreen.Location = new System.Drawing.Point(243, 0);
            this.ChangeGreen.Margin = new System.Windows.Forms.Padding(0);
            this.ChangeGreen.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ChangeGreen.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangeGreen.Name = "ChangeGreen";
            this.ChangeGreen.Ripple = true;
            this.ChangeGreen.Size = new System.Drawing.Size(97, 37);
            this.ChangeGreen.TabIndex = 19;
            this.ChangeGreen.TabStop = true;
            this.ChangeGreen.Text = "Зелений";
            this.ChangeGreen.UseVisualStyleBackColor = false;
            this.ChangeGreen.Visible = false;
            this.ChangeGreen.CheckedChanged += new System.EventHandler(this.ChangeGreen_CheckedChanged);
            // 
            // ChangeBlue
            // 
            this.ChangeBlue.AutoSize = true;
            this.ChangeBlue.Checked = true;
            this.ChangeBlue.Depth = 0;
            this.ChangeBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ChangeBlue.Location = new System.Drawing.Point(158, 0);
            this.ChangeBlue.Margin = new System.Windows.Forms.Padding(0);
            this.ChangeBlue.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ChangeBlue.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangeBlue.Name = "ChangeBlue";
            this.ChangeBlue.Ripple = true;
            this.ChangeBlue.Size = new System.Drawing.Size(76, 37);
            this.ChangeBlue.TabIndex = 18;
            this.ChangeBlue.TabStop = true;
            this.ChangeBlue.Text = "Синій";
            this.ChangeBlue.UseVisualStyleBackColor = true;
            this.ChangeBlue.Visible = false;
            this.ChangeBlue.CheckedChanged += new System.EventHandler(this.ChangeBlue_CheckedChanged);
            // 
            // ChangeOrange
            // 
            this.ChangeOrange.AutoSize = true;
            this.ChangeOrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.ChangeOrange.Depth = 0;
            this.ChangeOrange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ChangeOrange.Location = new System.Drawing.Point(5, 0);
            this.ChangeOrange.Margin = new System.Windows.Forms.Padding(0);
            this.ChangeOrange.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ChangeOrange.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangeOrange.Name = "ChangeOrange";
            this.ChangeOrange.Ripple = true;
            this.ChangeOrange.Size = new System.Drawing.Size(147, 37);
            this.ChangeOrange.TabIndex = 17;
            this.ChangeOrange.Text = "Помаранчевий";
            this.ChangeOrange.UseVisualStyleBackColor = false;
            this.ChangeOrange.Visible = false;
            this.ChangeOrange.CheckedChanged += new System.EventHandler(this.ChangeOrange_CheckedChanged);
            // 
            // PanelChangecolor
            // 
            this.PanelChangecolor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.PanelChangecolor.Controls.Add(this.ChangeOrange);
            this.PanelChangecolor.Controls.Add(this.ChangeGreen);
            this.PanelChangecolor.Controls.Add(this.ChangeBlue);
            this.PanelChangecolor.Location = new System.Drawing.Point(459, 26);
            this.PanelChangecolor.Name = "PanelChangecolor";
            this.PanelChangecolor.Size = new System.Drawing.Size(347, 37);
            this.PanelChangecolor.TabIndex = 20;
            this.PanelChangecolor.Visible = false;
            // 
            // LoginText
            // 
            this.LoginText.AnimateReadOnly = false;
            this.LoginText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginText.Depth = 0;
            this.LoginText.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LoginText.LeadingIcon = null;
            this.LoginText.Location = new System.Drawing.Point(301, 174);
            this.LoginText.MaxLength = 50;
            this.LoginText.MouseState = MaterialSkin.MouseState.OUT;
            this.LoginText.Multiline = false;
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(258, 50);
            this.LoginText.TabIndex = 22;
            this.LoginText.Text = "1";
            this.LoginText.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(309, 152);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(41, 19);
            this.materialLabel1.TabIndex = 23;
            this.materialLabel1.Text = "Логін";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(309, 227);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(57, 19);
            this.materialLabel2.TabIndex = 25;
            this.materialLabel2.Text = "Пароль";
            // 
            // PasswordText
            // 
            this.PasswordText.AnimateReadOnly = false;
            this.PasswordText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordText.Depth = 0;
            this.PasswordText.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PasswordText.LeadingIcon = null;
            this.PasswordText.Location = new System.Drawing.Point(301, 249);
            this.PasswordText.MaxLength = 50;
            this.PasswordText.MouseState = MaterialSkin.MouseState.OUT;
            this.PasswordText.Multiline = false;
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(258, 50);
            this.PasswordText.TabIndex = 24;
            this.PasswordText.Text = "2";
            this.PasswordText.TrailingIcon = null;
            // 
            // EnterBut
            // 
            this.EnterBut.AutoSize = false;
            this.EnterBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EnterBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.EnterBut.Depth = 0;
            this.EnterBut.HighEmphasis = true;
            this.EnterBut.Icon = null;
            this.EnterBut.Location = new System.Drawing.Point(317, 368);
            this.EnterBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EnterBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.EnterBut.Name = "EnterBut";
            this.EnterBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.EnterBut.Size = new System.Drawing.Size(228, 36);
            this.EnterBut.TabIndex = 26;
            this.EnterBut.Text = "Вхід";
            this.EnterBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.EnterBut.UseAccentColor = false;
            this.EnterBut.UseVisualStyleBackColor = true;
            this.EnterBut.Click += new System.EventHandler(this.EnterBut_Click);
            // 
            // RegBut
            // 
            this.RegBut.AutoSize = false;
            this.RegBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RegBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.RegBut.Depth = 0;
            this.RegBut.HighEmphasis = true;
            this.RegBut.Icon = null;
            this.RegBut.Location = new System.Drawing.Point(317, 426);
            this.RegBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RegBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.RegBut.Name = "RegBut";
            this.RegBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.RegBut.Size = new System.Drawing.Size(228, 36);
            this.RegBut.TabIndex = 27;
            this.RegBut.Text = "Реєстрація";
            this.RegBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.RegBut.UseAccentColor = false;
            this.RegBut.UseVisualStyleBackColor = true;
            this.RegBut.Click += new System.EventHandler(this.RegBut_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 540);
            this.Controls.Add(this.RegBut);
            this.Controls.Add(this.EnterBut);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.LoginText);
            this.Controls.Add(this.PanelChangecolor);
            this.Controls.Add(this.PictureChengecolor);
            this.Name = "MainForm";
            this.Text = "Авторизація";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureChengecolor)).EndInit();
            this.PanelChangecolor.ResumeLayout(false);
            this.PanelChangecolor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox PictureChengecolor;
        public MaterialSkin.Controls.MaterialRadioButton ChangeGreen;
        public MaterialSkin.Controls.MaterialRadioButton ChangeBlue;
        public MaterialSkin.Controls.MaterialRadioButton ChangeOrange;
        public System.Windows.Forms.Panel PanelChangecolor;
        private MaterialSkin.Controls.MaterialTextBox LoginText;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox PasswordText;
        private MaterialSkin.Controls.MaterialButton EnterBut;
        private MaterialSkin.Controls.MaterialButton RegBut;
    }
}

