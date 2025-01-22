namespace Technological_Future_AI.Telas
{
    partial class Form_ADM
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
            this.btn_criar = new System.Windows.Forms.Button();
            this.texBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_criar
            // 
            this.btn_criar.FlatAppearance.BorderSize = 0;
            this.btn_criar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_criar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_criar.ForeColor = System.Drawing.Color.White;
            this.btn_criar.Location = new System.Drawing.Point(76, 181);
            this.btn_criar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_criar.Name = "btn_criar";
            this.btn_criar.Size = new System.Drawing.Size(152, 28);
            this.btn_criar.TabIndex = 0;
            this.btn_criar.Text = "Acesso";
            this.btn_criar.UseVisualStyleBackColor = true;
            this.btn_criar.Click += new System.EventHandler(this.btn_criar_Click);
            // 
            // texBox1
            // 
            this.texBox1.Location = new System.Drawing.Point(133, 112);
            this.texBox1.Margin = new System.Windows.Forms.Padding(2);
            this.texBox1.Name = "texBox1";
            this.texBox1.Size = new System.Drawing.Size(180, 20);
            this.texBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.FlatAppearance.BorderSize = 0;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(88, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "CRIAR SENHA E SALT";
            this.label1.UseVisualStyleBackColor = true;          
            // 
            // Form_ADM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(328, 230);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.texBox1);
            this.Controls.Add(this.btn_criar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_ADM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_ADM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_criar;
        private System.Windows.Forms.TextBox texBox1;
        private System.Windows.Forms.Button label1;
    }
}