namespace WeatherStation.UI
{
  partial class Form1
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
      if (disposing && (components != null)) {
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.temperatures = new System.Windows.Forms.MaskedTextBox();
      this.save = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.cities = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.averageTemperatures = new System.Windows.Forms.DataGridView();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.averageTemperatures)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(30, 19);
      this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(886, 42);
      this.label1.TabIndex = 0;
      this.label1.Text = "Diese UI soll keinen Schönheitwettbewerb gewinnen";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.temperatures);
      this.groupBox1.Controls.Add(this.save);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.cities);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(19, 104);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.groupBox1.Size = new System.Drawing.Size(904, 266);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Temperaturerfassung";
      // 
      // temperatures
      // 
      this.temperatures.Location = new System.Drawing.Point(323, 107);
      this.temperatures.Mask = "00.0";
      this.temperatures.Name = "temperatures";
      this.temperatures.Size = new System.Drawing.Size(126, 38);
      this.temperatures.TabIndex = 5;
      // 
      // save
      // 
      this.save.Location = new System.Drawing.Point(323, 174);
      this.save.Name = "save";
      this.save.Size = new System.Drawing.Size(297, 57);
      this.save.TabIndex = 4;
      this.save.Text = "Speichern";
      this.save.UseVisualStyleBackColor = true;
      this.save.Click += new System.EventHandler(this.save_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(92, 107);
      this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(183, 37);
      this.label3.TabIndex = 2;
      this.label3.Text = "Temperatur";
      // 
      // cities
      // 
      this.cities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cities.FormattingEnabled = true;
      this.cities.Location = new System.Drawing.Point(323, 48);
      this.cities.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.cities.Name = "cities";
      this.cities.Size = new System.Drawing.Size(476, 45);
      this.cities.Sorted = true;
      this.cities.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(92, 51);
      this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(92, 37);
      this.label2.TabIndex = 0;
      this.label2.Text = "Stadt";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.averageTemperatures);
      this.groupBox3.Location = new System.Drawing.Point(19, 377);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(906, 428);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      // 
      // statusStrip1
      // 
      this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
      this.statusStrip1.Location = new System.Drawing.Point(0, 808);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(937, 22);
      this.statusStrip1.TabIndex = 4;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // averageTemperatures
      // 
      this.averageTemperatures.AllowUserToAddRows = false;
      this.averageTemperatures.AllowUserToDeleteRows = false;
      this.averageTemperatures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.averageTemperatures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.averageTemperatures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.averageTemperatures.Location = new System.Drawing.Point(6, 27);
      this.averageTemperatures.Name = "averageTemperatures";
      this.averageTemperatures.ReadOnly = true;
      this.averageTemperatures.RowTemplate.Height = 33;
      this.averageTemperatures.Size = new System.Drawing.Size(894, 395);
      this.averageTemperatures.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(937, 830);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.Name = "Form1";
      this.Text = "Form1";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.averageTemperatures)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cities;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button save;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.MaskedTextBox temperatures;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    private System.Windows.Forms.DataGridView averageTemperatures;
  }
}

