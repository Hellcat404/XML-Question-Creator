namespace XML_Question_Creator
{
    partial class frmQCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQCreator));
            this.tctlQuestions = new System.Windows.Forms.TabControl();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.tsFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExport = new System.Windows.Forms.ToolStripButton();
            this.tctlQuestions.SuspendLayout();
            this.tsTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // tctlQuestions
            // 
            this.tctlQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tctlQuestions.Controls.Add(this.tabAdd);
            this.tctlQuestions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tctlQuestions.Location = new System.Drawing.Point(0, 28);
            this.tctlQuestions.Name = "tctlQuestions";
            this.tctlQuestions.SelectedIndex = 0;
            this.tctlQuestions.Size = new System.Drawing.Size(665, 332);
            this.tctlQuestions.TabIndex = 0;
            this.tctlQuestions.Click += new System.EventHandler(this.tctlQuestions_Click);
            // 
            // tabAdd
            // 
            this.tabAdd.Location = new System.Drawing.Point(4, 22);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(657, 306);
            this.tabAdd.TabIndex = 2;
            this.tabAdd.Text = "Add Question";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // tsTools
            // 
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFile,
            this.tsExport});
            this.tsTools.Location = new System.Drawing.Point(0, 0);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(668, 25);
            this.tsTools.TabIndex = 1;
            this.tsTools.Text = "toolStrip1";
            // 
            // tsFile
            // 
            this.tsFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsOpen,
            this.tsExit});
            this.tsFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFile.Image = ((System.Drawing.Image)(resources.GetObject("tsFile.Image")));
            this.tsFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFile.Name = "tsFile";
            this.tsFile.Size = new System.Drawing.Size(38, 22);
            this.tsFile.Text = "File";
            // 
            // tsNew
            // 
            this.tsNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(112, 22);
            this.tsNew.Text = "New";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // tsOpen
            // 
            this.tsOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(112, 22);
            this.tsOpen.Text = "Open...";
            // 
            // tsExit
            // 
            this.tsExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(112, 22);
            this.tsExit.Text = "Exit";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // tsExport
            // 
            this.tsExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsExport.Image = ((System.Drawing.Image)(resources.GetObject("tsExport.Image")));
            this.tsExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExport.Name = "tsExport";
            this.tsExport.Size = new System.Drawing.Size(45, 22);
            this.tsExport.Text = "Export";
            // 
            // frmQCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 362);
            this.Controls.Add(this.tsTools);
            this.Controls.Add(this.tctlQuestions);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmQCreator";
            this.Text = "Question Creator";
            this.tctlQuestions.ResumeLayout(false);
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tctlQuestions;
        private System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.ToolStripDropDownButton tsFile;
        private System.Windows.Forms.ToolStripMenuItem tsNew;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.ToolStripMenuItem tsOpen;
        private System.Windows.Forms.ToolStripButton tsExport;
    }
}

