namespace DDEX
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.mrLabel1 = new Framework.UI.Controls.MRLabel(this.components);
            this.mrTextBox1 = new Framework.UI.Controls.MRTextBox(this.components);
            this.btnOk = new Framework.UI.Controls.MRButton(this.components);
            this.btnCancel = new Framework.UI.Controls.MRButton(this.components);
            this.SuspendLayout();
            // 
            // mrLabel1
            // 
            this.mrLabel1.AutoSize = true;
            this.mrLabel1.Location = new System.Drawing.Point(12, 20);
            this.mrLabel1.Name = "mrLabel1";
            this.mrLabel1.Size = new System.Drawing.Size(87, 13);
            this.mrLabel1.TabIndex = 0;
            this.mrLabel1.Text = "Your Party Name";
            // 
            // mrTextBox1
            // 
            this.mrTextBox1.Location = new System.Drawing.Point(119, 17);
            this.mrTextBox1.Name = "mrTextBox1";
            this.mrTextBox1.Size = new System.Drawing.Size(247, 20);
            this.mrTextBox1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(119, 62);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(229, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 90);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.mrTextBox1);
            this.Controls.Add(this.mrLabel1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.UI.Controls.MRLabel mrLabel1;
        private Framework.UI.Controls.MRTextBox mrTextBox1;
        private Framework.UI.Controls.MRButton btnOk;
        private Framework.UI.Controls.MRButton btnCancel;
    }
}