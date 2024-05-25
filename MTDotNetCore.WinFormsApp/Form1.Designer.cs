namespace MTDotNetCore.WinFormsApp
{
    partial class FrmBlog
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
            lblTitle = new Label();
            lblAuthor = new Label();
            lblContent = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(150, 37);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(81, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title :";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(150, 123);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(111, 37);
            lblAuthor.TabIndex = 1;
            lblAuthor.Text = "Author :";
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(150, 209);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(132, 37);
            lblContent.TabIndex = 2;
            lblContent.Text = "Content : ";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(150, 77);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(623, 43);
            txtTitle.TabIndex = 3;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(150, 163);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(623, 43);
            txtAuthor.TabIndex = 4;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(150, 249);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(623, 190);
            txtContent.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(67, 160, 71);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = SystemColors.HighlightText;
            btnSave.Location = new Point(310, 445);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(154, 51);
            btnSave.TabIndex = 6;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(84, 110, 122);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = SystemColors.HighlightText;
            btnCancel.Location = new Point(150, 445);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(154, 51);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 697);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblContent);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblAuthor;
        private Label lblContent;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnSave;
        private Button btnCancel;
    }
}
