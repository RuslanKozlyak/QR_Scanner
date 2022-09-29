
namespace QR_Scanner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.CroppedPicBox = new System.Windows.Forms.PictureBox();
            this.PDFPicBox = new System.Windows.Forms.PictureBox();
            this.DecodeButton = new System.Windows.Forms.Button();
            this.AutoScanButton = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CroppedPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PDFPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(632, 389);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(396, 272);
            this.resultTextBox.TabIndex = 1;
            this.resultTextBox.Text = "";
            // 
            // CroppedPicBox
            // 
            this.CroppedPicBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CroppedPicBox.Location = new System.Drawing.Point(632, 12);
            this.CroppedPicBox.Name = "CroppedPicBox";
            this.CroppedPicBox.Size = new System.Drawing.Size(396, 319);
            this.CroppedPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CroppedPicBox.TabIndex = 2;
            this.CroppedPicBox.TabStop = false;
            // 
            // PDFPicBox
            // 
            this.PDFPicBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PDFPicBox.Location = new System.Drawing.Point(12, 45);
            this.PDFPicBox.Name = "PDFPicBox";
            this.PDFPicBox.Size = new System.Drawing.Size(600, 616);
            this.PDFPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PDFPicBox.TabIndex = 0;
            this.PDFPicBox.TabStop = false;
            this.PDFPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PDFPicBox_Paint);
            this.PDFPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PDFPicBox_MouseDown);
            this.PDFPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PDFPicBox_MouseMove);
            // 
            // DecodeButton
            // 
            this.DecodeButton.Location = new System.Drawing.Point(632, 337);
            this.DecodeButton.Name = "DecodeButton";
            this.DecodeButton.Size = new System.Drawing.Size(167, 46);
            this.DecodeButton.TabIndex = 3;
            this.DecodeButton.Text = "Сканировать код";
            this.DecodeButton.UseVisualStyleBackColor = true;
            this.DecodeButton.Click += new System.EventHandler(this.DecodeButton_Click);
            // 
            // AutoScanButton
            // 
            this.AutoScanButton.Location = new System.Drawing.Point(805, 337);
            this.AutoScanButton.Name = "AutoScanButton";
            this.AutoScanButton.Size = new System.Drawing.Size(223, 46);
            this.AutoScanButton.TabIndex = 4;
            this.AutoScanButton.Text = "Сканировать автоматически";
            this.AutoScanButton.UseVisualStyleBackColor = true;
            this.AutoScanButton.Click += new System.EventHandler(this.AutoScanButton_Click);
            // 
            // openFileDialog1
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(12, 10);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(600, 29);
            this.OpenFile.TabIndex = 5;
            this.OpenFile.Text = "Открыть PDF файл";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 673);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.AutoScanButton);
            this.Controls.Add(this.DecodeButton);
            this.Controls.Add(this.CroppedPicBox);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.PDFPicBox);
            this.Name = "Form1";
            this.Text = "PDF QR Scanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CroppedPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PDFPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox resultTextBox;
        private System.Windows.Forms.PictureBox CroppedPicBox;
        private System.Windows.Forms.PictureBox PDFPicBox;
        private System.Windows.Forms.Button DecodeButton;
        private System.Windows.Forms.Button AutoScanButton;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button OpenFile;
    }
}

