namespace TestFormsApp
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonExample2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(654, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "System tray should now show an example ⚠️ icon, \r\nincluding an example right clic" +
    "k context menu.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Example Task Dialog";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonExample2
            // 
            this.buttonExample2.Location = new System.Drawing.Point(116, 366);
            this.buttonExample2.Name = "buttonExample2";
            this.buttonExample2.Size = new System.Drawing.Size(174, 50);
            this.buttonExample2.TabIndex = 2;
            this.buttonExample2.Text = "Example 2";
            this.buttonExample2.UseVisualStyleBackColor = true;
            this.buttonExample2.Click += new System.EventHandler(this.buttonExample2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(387, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 50);
            this.button3.TabIndex = 3;
            this.button3.Text = "Example Flip Flop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonExample2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonExample2;
        private System.Windows.Forms.Button button3;
    }
}

