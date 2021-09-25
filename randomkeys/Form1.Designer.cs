namespace randomkeys
{
    partial class randomnumber
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_megasena = new System.Windows.Forms.RadioButton();
            this.button_lotomania = new System.Windows.Forms.RadioButton();
            this.button_quina = new System.Windows.Forms.RadioButton();
            this.button_duplasena = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_continuar1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_duplasena);
            this.groupBox1.Controls.Add(this.button_quina);
            this.groupBox1.Controls.Add(this.button_lotomania);
            this.groupBox1.Controls.Add(this.button_megasena);
            this.groupBox1.Location = new System.Drawing.Point(21, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de jogo";
            // 
            // button_megasena
            // 
            this.button_megasena.AutoSize = true;
            this.button_megasena.Location = new System.Drawing.Point(6, 19);
            this.button_megasena.Name = "button_megasena";
            this.button_megasena.Size = new System.Drawing.Size(80, 17);
            this.button_megasena.TabIndex = 0;
            this.button_megasena.TabStop = true;
            this.button_megasena.Text = "Mega-Sena";
            this.button_megasena.UseVisualStyleBackColor = true;
            // 
            // button_lotomania
            // 
            this.button_lotomania.AutoSize = true;
            this.button_lotomania.Location = new System.Drawing.Point(6, 42);
            this.button_lotomania.Name = "button_lotomania";
            this.button_lotomania.Size = new System.Drawing.Size(74, 17);
            this.button_lotomania.TabIndex = 1;
            this.button_lotomania.TabStop = true;
            this.button_lotomania.Text = "Lotomania";
            this.button_lotomania.UseVisualStyleBackColor = true;
            // 
            // button_quina
            // 
            this.button_quina.AutoSize = true;
            this.button_quina.Location = new System.Drawing.Point(6, 65);
            this.button_quina.Name = "button_quina";
            this.button_quina.Size = new System.Drawing.Size(53, 17);
            this.button_quina.TabIndex = 2;
            this.button_quina.TabStop = true;
            this.button_quina.Text = "Quina";
            this.button_quina.UseVisualStyleBackColor = true;
            // 
            // button_duplasena
            // 
            this.button_duplasena.AutoSize = true;
            this.button_duplasena.Location = new System.Drawing.Point(6, 88);
            this.button_duplasena.Name = "button_duplasena";
            this.button_duplasena.Size = new System.Drawing.Size(81, 17);
            this.button_duplasena.TabIndex = 3;
            this.button_duplasena.TabStop = true;
            this.button_duplasena.Text = "Dupla-Sena";
            this.button_duplasena.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bem-Vindo(a), ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Para continuar, selecione o jogo de sua preferência";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Usuário";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button_continuar1
            // 
            this.button_continuar1.Location = new System.Drawing.Point(261, 177);
            this.button_continuar1.Name = "button_continuar1";
            this.button_continuar1.Size = new System.Drawing.Size(75, 23);
            this.button_continuar1.TabIndex = 4;
            this.button_continuar1.Text = "Continuar";
            this.button_continuar1.UseVisualStyleBackColor = true;
            // 
            // randomnumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 212);
            this.Controls.Add(this.button_continuar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "randomnumber";
            this.Text = "Naphatech - Numeros aleatorios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton button_duplasena;
        private System.Windows.Forms.RadioButton button_quina;
        private System.Windows.Forms.RadioButton button_lotomania;
        private System.Windows.Forms.RadioButton button_megasena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_continuar1;
    }
}

