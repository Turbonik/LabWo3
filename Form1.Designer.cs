namespace LabWo3
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
            this.button1 = new System.Windows.Forms.Button();
            this.Action_Description = new System.Windows.Forms.Label();
            this.exitgame = new System.Windows.Forms.Button();
            this.Action_Description2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 143);
            this.button1.TabIndex = 0;
            this.button1.Text = "Бросить кубик";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.rollDiceButtonClick);
            // 
            // Action_Description
            // 
            this.Action_Description.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Action_Description.Location = new System.Drawing.Point(286, 324);
            this.Action_Description.Name = "Action_Description";
            this.Action_Description.Size = new System.Drawing.Size(116, 34);
            this.Action_Description.TabIndex = 1;
            this.Action_Description.Text = "Ходит Игрок 1";
            // 
            // exitgame
            // 
            this.exitgame.Location = new System.Drawing.Point(12, 486);
            this.exitgame.Name = "exitgame";
            this.exitgame.Size = new System.Drawing.Size(215, 143);
            this.exitgame.TabIndex = 2;
            this.exitgame.Text = "Выйти и сохранить игру";
            this.exitgame.UseVisualStyleBackColor = true;
            this.exitgame.Click += new System.EventHandler(this.exitgame_Click);
            // 
            // Action_Description2
            // 
            this.Action_Description2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Action_Description2.Location = new System.Drawing.Point(286, 264);
            this.Action_Description2.Name = "Action_Description2";
            this.Action_Description2.Size = new System.Drawing.Size(116, 34);
            this.Action_Description2.TabIndex = 3;
            this.Action_Description2.Text = "Бросьте кубик для старта";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 651);
            this.Controls.Add(this.Action_Description2);
            this.Controls.Add(this.exitgame);
            this.Controls.Add(this.Action_Description);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label Action_Description;
        private System.Windows.Forms.Button exitgame;
        public System.Windows.Forms.Label Action_Description2;
    }
}

