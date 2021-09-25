namespace softlotery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(randomnumber));
            this.button_megasena = new System.Windows.Forms.Button();
            this.button_lotomania = new System.Windows.Forms.Button();
            this.button_quina = new System.Windows.Forms.Button();
            this.button_duplasena = new System.Windows.Forms.Button();
            this.lbNome = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lbNumeros = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_megasena
            // 
            this.button_megasena.Location = new System.Drawing.Point(9, 19);
            this.button_megasena.Name = "button_megasena";
            this.button_megasena.Size = new System.Drawing.Size(75, 49);
            this.button_megasena.TabIndex = 4;
            this.button_megasena.Text = "Mega Sena";
            this.button_megasena.UseVisualStyleBackColor = true;
            this.button_megasena.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_lotomania
            // 
            this.button_lotomania.Location = new System.Drawing.Point(111, 19);
            this.button_lotomania.Name = "button_lotomania";
            this.button_lotomania.Size = new System.Drawing.Size(75, 49);
            this.button_lotomania.TabIndex = 5;
            this.button_lotomania.Text = "Lotomania";
            this.button_lotomania.UseVisualStyleBackColor = true;
            this.button_lotomania.Click += new System.EventHandler(this.button_lotomania_Click);
            // 
            // button_quina
            // 
            this.button_quina.Location = new System.Drawing.Point(210, 19);
            this.button_quina.Name = "button_quina";
            this.button_quina.Size = new System.Drawing.Size(75, 49);
            this.button_quina.TabIndex = 6;
            this.button_quina.Text = "Quina";
            this.button_quina.UseVisualStyleBackColor = true;
            this.button_quina.Click += new System.EventHandler(this.button_quina_Click);
            // 
            // button_duplasena
            // 
            this.button_duplasena.Location = new System.Drawing.Point(304, 19);
            this.button_duplasena.Name = "button_duplasena";
            this.button_duplasena.Size = new System.Drawing.Size(75, 49);
            this.button_duplasena.TabIndex = 7;
            this.button_duplasena.Text = "Dupla Sena";
            this.button_duplasena.UseVisualStyleBackColor = true;
            this.button_duplasena.Click += new System.EventHandler(this.button_duplasena_Click);
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.BackColor = System.Drawing.Color.Transparent;
            this.lbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNome.Location = new System.Drawing.Point(112, 26);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(55, 16);
            this.lbNome.TabIndex = 12;
            this.lbNome.Text = "Usuário";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(78, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Para continuar, selecione o jogo de sua preferência.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Bem-Vindo(a):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_megasena);
            this.groupBox2.Controls.Add(this.button_lotomania);
            this.groupBox2.Controls.Add(this.button_quina);
            this.groupBox2.Controls.Add(this.button_duplasena);
            this.groupBox2.Location = new System.Drawing.Point(11, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 84);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selecione seu tipo de Jogo:";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(333, 334);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(71, 21);
            this.btnCopy.TabIndex = 19;
            this.btnCopy.Text = "Copiar";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lbNumeros
            // 
            this.lbNumeros.AutoSize = true;
            this.lbNumeros.Location = new System.Drawing.Point(6, 16);
            this.lbNumeros.Name = "lbNumeros";
            this.lbNumeros.Size = new System.Drawing.Size(145, 13);
            this.lbNumeros.TabIndex = 22;
            this.lbNumeros.Text = "Nenhum número encontrado.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbNumeros);
            this.groupBox1.Location = new System.Drawing.Point(11, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 108);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Últimos números que foram salvos:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pictureBox3.Location = new System.Drawing.Point(-13, -46);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(437, 50);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(-13, 361);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(437, 24);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "v1.0.0";
            // 
            // randomnumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(413, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "randomnumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Números Aleatórios";
            this.TransparencyKey = System.Drawing.Color.OrangeRed;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.randomnumber_FormClosed);
            this.Load += new System.EventHandler(this.randomnumber_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_megasena;
        private System.Windows.Forms.Button button_lotomania;
        private System.Windows.Forms.Button button_quina;
        private System.Windows.Forms.Button button_duplasena;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lbNumeros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}

