﻿namespace ArraysTraining
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxArrayView = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.groupBoxTasks = new System.Windows.Forms.GroupBox();
            this.radioButtonTask1 = new System.Windows.Forms.RadioButton();
            this.radioButtonTask2 = new System.Windows.Forms.RadioButton();
            this.radioButtonTask3 = new System.Windows.Forms.RadioButton();
            this.groupBoxTask1 = new System.Windows.Forms.GroupBox();
            this.groupBoxTask2 = new System.Windows.Forms.GroupBox();
            this.radioButtonTask1Directon = new System.Windows.Forms.RadioButton();
            this.textBoxTask1Amount = new System.Windows.Forms.TextBox();
            this.groupBoxTasks.SuspendLayout();
            this.groupBoxTask1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество/Мин/Макс";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInput.Location = new System.Drawing.Point(190, 12);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(486, 23);
            this.textBoxInput.TabIndex = 1;
            this.textBoxInput.Text = "10/1/14";
            // 
            // textBoxArrayView
            // 
            this.textBoxArrayView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArrayView.Location = new System.Drawing.Point(21, 44);
            this.textBoxArrayView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxArrayView.Name = "textBoxArrayView";
            this.textBoxArrayView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxArrayView.Size = new System.Drawing.Size(943, 23);
            this.textBoxArrayView.TabIndex = 2;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(16, 422);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxOutput.Size = new System.Drawing.Size(948, 23);
            this.textBoxOutput.TabIndex = 3;
            // 
            // groupBoxTasks
            // 
            this.groupBoxTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTasks.Controls.Add(this.groupBoxTask2);
            this.groupBoxTasks.Controls.Add(this.groupBoxTask1);
            this.groupBoxTasks.Controls.Add(this.radioButtonTask3);
            this.groupBoxTasks.Controls.Add(this.radioButtonTask2);
            this.groupBoxTasks.Controls.Add(this.radioButtonTask1);
            this.groupBoxTasks.Location = new System.Drawing.Point(21, 75);
            this.groupBoxTasks.Name = "groupBoxTasks";
            this.groupBoxTasks.Size = new System.Drawing.Size(944, 340);
            this.groupBoxTasks.TabIndex = 4;
            this.groupBoxTasks.TabStop = false;
            this.groupBoxTasks.Text = "Tasks";
            // 
            // radioButtonTask1
            // 
            this.radioButtonTask1.AutoSize = true;
            this.radioButtonTask1.Checked = true;
            this.radioButtonTask1.Location = new System.Drawing.Point(7, 23);
            this.radioButtonTask1.Name = "radioButtonTask1";
            this.radioButtonTask1.Size = new System.Drawing.Size(60, 21);
            this.radioButtonTask1.TabIndex = 0;
            this.radioButtonTask1.TabStop = true;
            this.radioButtonTask1.Text = "task1";
            this.radioButtonTask1.UseVisualStyleBackColor = true;
            // 
            // radioButtonTask2
            // 
            this.radioButtonTask2.AutoSize = true;
            this.radioButtonTask2.Location = new System.Drawing.Point(7, 50);
            this.radioButtonTask2.Name = "radioButtonTask2";
            this.radioButtonTask2.Size = new System.Drawing.Size(60, 21);
            this.radioButtonTask2.TabIndex = 1;
            this.radioButtonTask2.TabStop = true;
            this.radioButtonTask2.Text = "task2";
            this.radioButtonTask2.UseVisualStyleBackColor = true;
            // 
            // radioButtonTask3
            // 
            this.radioButtonTask3.AutoSize = true;
            this.radioButtonTask3.Location = new System.Drawing.Point(7, 77);
            this.radioButtonTask3.Name = "radioButtonTask3";
            this.radioButtonTask3.Size = new System.Drawing.Size(60, 21);
            this.radioButtonTask3.TabIndex = 2;
            this.radioButtonTask3.TabStop = true;
            this.radioButtonTask3.Text = "task3";
            this.radioButtonTask3.UseVisualStyleBackColor = true;
            // 
            // groupBoxTask1
            // 
            this.groupBoxTask1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTask1.Controls.Add(this.textBoxTask1Amount);
            this.groupBoxTask1.Controls.Add(this.radioButtonTask1Directon);
            this.groupBoxTask1.Location = new System.Drawing.Point(73, 22);
            this.groupBoxTask1.Name = "groupBoxTask1";
            this.groupBoxTask1.Size = new System.Drawing.Size(225, 312);
            this.groupBoxTask1.TabIndex = 3;
            this.groupBoxTask1.TabStop = false;
            this.groupBoxTask1.Text = "Task1";
            // 
            // groupBoxTask2
            // 
            this.groupBoxTask2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTask2.Location = new System.Drawing.Point(304, 22);
            this.groupBoxTask2.Name = "groupBoxTask2";
            this.groupBoxTask2.Size = new System.Drawing.Size(225, 318);
            this.groupBoxTask2.TabIndex = 4;
            this.groupBoxTask2.TabStop = false;
            this.groupBoxTask2.Text = "Task2";
            // 
            // radioButtonTask1Directon
            // 
            this.radioButtonTask1Directon.AutoSize = true;
            this.radioButtonTask1Directon.Location = new System.Drawing.Point(7, 23);
            this.radioButtonTask1Directon.Name = "radioButtonTask1Directon";
            this.radioButtonTask1Directon.Size = new System.Drawing.Size(110, 21);
            this.radioButtonTask1Directon.TabIndex = 0;
            this.radioButtonTask1Directon.TabStop = true;
            this.radioButtonTask1Directon.Text = "rightDirection";
            this.radioButtonTask1Directon.UseVisualStyleBackColor = true;
            // 
            // textBoxTask1Amount
            // 
            this.textBoxTask1Amount.Location = new System.Drawing.Point(7, 51);
            this.textBoxTask1Amount.Name = "textBoxTask1Amount";
            this.textBoxTask1Amount.Size = new System.Drawing.Size(100, 23);
            this.textBoxTask1Amount.TabIndex = 1;
            this.textBoxTask1Amount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 462);
            this.Controls.Add(this.groupBoxTasks);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxArrayView);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxTasks.ResumeLayout(false);
            this.groupBoxTasks.PerformLayout();
            this.groupBoxTask1.ResumeLayout(false);
            this.groupBoxTask1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxArrayView;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.GroupBox groupBoxTasks;
        private System.Windows.Forms.RadioButton radioButtonTask3;
        private System.Windows.Forms.RadioButton radioButtonTask2;
        private System.Windows.Forms.RadioButton radioButtonTask1;
        private System.Windows.Forms.GroupBox groupBoxTask1;
        private System.Windows.Forms.GroupBox groupBoxTask2;
        private System.Windows.Forms.RadioButton radioButtonTask1Directon;
        private System.Windows.Forms.TextBox textBoxTask1Amount;
    }
}
