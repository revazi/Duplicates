namespace WindowsFormsApplication3
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtAccessFileName = new System.Windows.Forms.TextBox();
            this.resultLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenAccessFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataSetDesigner = new WindowsFormsApplication3.DataSet1();
            this.dataDuplicates = new WindowsFormsApplication3.DataSet2();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDesigner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDuplicates)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Go!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAccessFileName
            // 
            this.txtAccessFileName.Location = new System.Drawing.Point(12, 45);
            this.txtAccessFileName.Name = "txtAccessFileName";
            this.txtAccessFileName.Size = new System.Drawing.Size(418, 20);
            this.txtAccessFileName.TabIndex = 34;
            this.txtAccessFileName.TextChanged += new System.EventHandler(this.txtAccessFileName_TextChanged);
            // 
            // resultLog
            // 
            this.resultLog.Location = new System.Drawing.Point(12, 117);
            this.resultLog.Multiline = true;
            this.resultLog.Name = "resultLog";
            this.resultLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultLog.Size = new System.Drawing.Size(440, 220);
            this.resultLog.TabIndex = 35;
            this.resultLog.TextChanged += new System.EventHandler(this.resultLog_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Enter File or Directory Path";
            // 
            // btnOpenAccessFile
            // 
            this.btnOpenAccessFile.Location = new System.Drawing.Point(436, 44);
            this.btnOpenAccessFile.Name = "btnOpenAccessFile";
            this.btnOpenAccessFile.Size = new System.Drawing.Size(24, 20);
            this.btnOpenAccessFile.TabIndex = 37;
            this.btnOpenAccessFile.Text = "...";
            this.btnOpenAccessFile.Click += new System.EventHandler(this.btnOpenAccessFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "Files in Directory";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(343, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 40);
            this.button2.TabIndex = 39;
            this.button2.Text = "SaveToXml";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 343);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 40);
            this.button3.TabIndex = 40;
            this.button3.Text = "FindDuplicate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataSetDesigner
            // 
            this.dataSetDesigner.DataSetName = "DataSet1";
            this.dataSetDesigner.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataDuplicates
            // 
            this.dataDuplicates.DataSetName = "DataSet2";
            this.dataDuplicates.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 390);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenAccessFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultLog);
            this.Controls.Add(this.txtAccessFileName);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(480, 480);
            this.MinimumSize = new System.Drawing.Size(480, 425);
            this.Name = "Form1";
            this.Text = "Files in Folder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDesigner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDuplicates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox txtAccessFileName;
        internal System.Windows.Forms.TextBox resultLog;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnOpenAccessFile;
        private DataSet1 dataSetDesigner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private DataSet2 dataDuplicates;
    }
}

