namespace algoritmosdebusquedaui
{
    partial class Grafos
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
            this.cb_origen = new System.Windows.Forms.ComboBox();
            this.cb_destino = new System.Windows.Forms.ComboBox();
            this.lb_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_algoritmo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_resultados = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gm_ciudades = new GMap.NET.WindowsForms.GMapControl();
            this.label6 = new System.Windows.Forms.Label();
            this.dg_robot = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dg_robot)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_origen
            // 
            this.cb_origen.FormattingEnabled = true;
            this.cb_origen.Location = new System.Drawing.Point(119, 91);
            this.cb_origen.Name = "cb_origen";
            this.cb_origen.Size = new System.Drawing.Size(199, 21);
            this.cb_origen.TabIndex = 1;
            // 
            // cb_destino
            // 
            this.cb_destino.FormattingEnabled = true;
            this.cb_destino.Location = new System.Drawing.Point(119, 131);
            this.cb_destino.Name = "cb_destino";
            this.cb_destino.Size = new System.Drawing.Size(199, 21);
            this.cb_destino.TabIndex = 2;
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.Location = new System.Drawing.Point(92, 12);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(246, 25);
            this.lb_title.TabIndex = 3;
            this.lb_title.Text = "Algoritmos de Busqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destino";
            // 
            // cb_algoritmo
            // 
            this.cb_algoritmo.FormattingEnabled = true;
            this.cb_algoritmo.Location = new System.Drawing.Point(119, 170);
            this.cb_algoritmo.Name = "cb_algoritmo";
            this.cb_algoritmo.Size = new System.Drawing.Size(199, 21);
            this.cb_algoritmo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Algoritmo";
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_buscar.Location = new System.Drawing.Point(170, 197);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 8;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_resultados
            // 
            this.txt_resultados.Location = new System.Drawing.Point(17, 258);
            this.txt_resultados.Multiline = true;
            this.txt_resultados.Name = "txt_resultados";
            this.txt_resultados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_resultados.Size = new System.Drawing.Size(435, 284);
            this.txt_resultados.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Resultados:";
            // 
            // gm_ciudades
            // 
            this.gm_ciudades.Bearing = 0F;
            this.gm_ciudades.CanDragMap = true;
            this.gm_ciudades.EmptyTileColor = System.Drawing.Color.Navy;
            this.gm_ciudades.GrayScaleMode = false;
            this.gm_ciudades.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gm_ciudades.LevelsKeepInMemmory = 5;
            this.gm_ciudades.Location = new System.Drawing.Point(474, 37);
            this.gm_ciudades.MarkersEnabled = true;
            this.gm_ciudades.MaxZoom = 18;
            this.gm_ciudades.MinZoom = 0;
            this.gm_ciudades.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gm_ciudades.Name = "gm_ciudades";
            this.gm_ciudades.NegativeMode = false;
            this.gm_ciudades.PolygonsEnabled = true;
            this.gm_ciudades.RetryLoadTile = 0;
            this.gm_ciudades.RoutesEnabled = true;
            this.gm_ciudades.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gm_ciudades.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gm_ciudades.ShowTileGridLines = false;
            this.gm_ciudades.Size = new System.Drawing.Size(611, 505);
            this.gm_ciudades.TabIndex = 11;
            this.gm_ciudades.Zoom = 2D;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Trazado de camino";
            // 
            // dg_robot
            // 
            this.dg_robot.AllowUserToAddRows = false;
            this.dg_robot.AllowUserToDeleteRows = false;
            this.dg_robot.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dg_robot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_robot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_robot.ColumnHeadersVisible = false;
            this.dg_robot.Location = new System.Drawing.Point(474, 37);
            this.dg_robot.Name = "dg_robot";
            this.dg_robot.ReadOnly = true;
            this.dg_robot.Size = new System.Drawing.Size(611, 505);
            this.dg_robot.TabIndex = 15;
            // 
            // Grafos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1097, 554);
            this.Controls.Add(this.dg_robot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gm_ciudades);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_resultados);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_algoritmo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.cb_destino);
            this.Controls.Add(this.cb_origen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Grafos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grafos";
            ((System.ComponentModel.ISupportInitialize)(this.dg_robot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_origen;
        private System.Windows.Forms.ComboBox cb_destino;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_algoritmo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_resultados;
        private System.Windows.Forms.Label label4;
        private GMap.NET.WindowsForms.GMapControl gm_ciudades;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dg_robot;
    }
}

