namespace ReadExcel
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Save = new System.Windows.Forms.Button();
            this.PathText = new System.Windows.Forms.TextBox();
            this.SelectFile = new System.Windows.Forms.Button();
            this.SavePath = new System.Windows.Forms.TextBox();
            this.SelectSavePath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(181, 326);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(102, 23);
            this.Save.TabIndex = 0;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // PathText
            // 
            this.PathText.AcceptsReturn = true;
            this.PathText.AllowDrop = true;
            this.PathText.Location = new System.Drawing.Point(12, 110);
            this.PathText.Multiline = true;
            this.PathText.Name = "PathText";
            this.PathText.Size = new System.Drawing.Size(271, 48);
            this.PathText.TabIndex = 1;
            this.PathText.Text = "选择Excel文件";
            this.PathText.TextChanged += new System.EventHandler(this.PathText_TextChanged);
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(318, 121);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(102, 23);
            this.SelectFile.TabIndex = 2;
            this.SelectFile.Text = "选择文件";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // SavePath
            // 
            this.SavePath.AllowDrop = true;
            this.SavePath.Location = new System.Drawing.Point(13, 217);
            this.SavePath.Multiline = true;
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(270, 48);
            this.SavePath.TabIndex = 3;
            this.SavePath.Text = "选择保存XML路径";
            // 
            // SelectSavePath
            // 
            this.SelectSavePath.Location = new System.Drawing.Point(318, 226);
            this.SelectSavePath.Name = "SelectSavePath";
            this.SelectSavePath.Size = new System.Drawing.Size(102, 23);
            this.SelectSavePath.TabIndex = 4;
            this.SelectSavePath.Text = "选择保存目录";
            this.SelectSavePath.UseVisualStyleBackColor = true;
            this.SelectSavePath.Click += new System.EventHandler(this.SelectSavePath_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 409);
            this.Controls.Add(this.SelectSavePath);
            this.Controls.Add(this.SavePath);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.PathText);
            this.Controls.Add(this.Save);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox PathText;
        private System.Windows.Forms.Button SelectFile;
        private System.Windows.Forms.TextBox SavePath;
        private System.Windows.Forms.Button SelectSavePath;
    }
}

