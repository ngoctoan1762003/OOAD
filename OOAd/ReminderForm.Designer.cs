
namespace OOAd
{
    partial class ReminderForm
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
            this.lsvAppointment = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(279, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bảng ghi nhớ";
            // 
            // lsvAppointment
            // 
            this.lsvAppointment.Font = new System.Drawing.Font("Corbel", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvAppointment.HideSelection = false;
            this.lsvAppointment.Location = new System.Drawing.Point(12, 92);
            this.lsvAppointment.Name = "lsvAppointment";
            this.lsvAppointment.Size = new System.Drawing.Size(776, 346);
            this.lsvAppointment.TabIndex = 1;
            this.lsvAppointment.UseCompatibleStateImageBehavior = false;
            // 
            // ReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lsvAppointment);
            this.Controls.Add(this.label1);
            this.Name = "ReminderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReminderForm";
            this.Load += new System.EventHandler(this.ReminderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvAppointment;
    }
}