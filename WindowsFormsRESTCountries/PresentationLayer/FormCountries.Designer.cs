namespace PresentationLayer
{
    partial class FormCountries
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
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.countryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryAlpha3Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countrySubregion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryPopulation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryLatLng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDemonym = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryTimeZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryFlag = new System.Windows.Forms.DataGridViewLinkColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.countryName,
            this.countryAlpha3Code,
            this.countryCapital,
            this.countryRegion,
            this.countrySubregion,
            this.countryPopulation,
            this.countryLatLng,
            this.countryArea,
            this.countryDemonym,
            this.countryTimeZone,
            this.countryFlag});
            this.dataGridViewTable.Location = new System.Drawing.Point(153, 28);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.Size = new System.Drawing.Size(1143, 550);
            this.dataGridViewTable.TabIndex = 0;
            this.dataGridViewTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTable_CellContentClick);
            // 
            // countryName
            // 
            this.countryName.DataPropertyName = "name";
            this.countryName.HeaderText = "Name";
            this.countryName.Name = "countryName";
            // 
            // countryAlpha3Code
            // 
            this.countryAlpha3Code.DataPropertyName = "alpha3Code";
            this.countryAlpha3Code.HeaderText = "Alpha3Code";
            this.countryAlpha3Code.Name = "countryAlpha3Code";
            // 
            // countryCapital
            // 
            this.countryCapital.DataPropertyName = "capital";
            this.countryCapital.HeaderText = "Capital";
            this.countryCapital.Name = "countryCapital";
            // 
            // countryRegion
            // 
            this.countryRegion.DataPropertyName = "region";
            this.countryRegion.HeaderText = "Region";
            this.countryRegion.Name = "countryRegion";
            // 
            // countrySubregion
            // 
            this.countrySubregion.DataPropertyName = "subregion";
            this.countrySubregion.HeaderText = "Subregion";
            this.countrySubregion.Name = "countrySubregion";
            // 
            // countryPopulation
            // 
            this.countryPopulation.DataPropertyName = "population";
            this.countryPopulation.HeaderText = "Population";
            this.countryPopulation.Name = "countryPopulation";
            // 
            // countryLatLng
            // 
            this.countryLatLng.DataPropertyName = "latlng";
            this.countryLatLng.HeaderText = "Lat & Lng";
            this.countryLatLng.Name = "countryLatLng";
            // 
            // countryArea
            // 
            this.countryArea.DataPropertyName = "area";
            this.countryArea.HeaderText = "Area";
            this.countryArea.Name = "countryArea";
            // 
            // countryDemonym
            // 
            this.countryDemonym.DataPropertyName = "demonym";
            this.countryDemonym.HeaderText = "Demonym";
            this.countryDemonym.Name = "countryDemonym";
            // 
            // countryTimeZone
            // 
            this.countryTimeZone.DataPropertyName = "timeZone";
            this.countryTimeZone.HeaderText = "Time Zone";
            this.countryTimeZone.Name = "countryTimeZone";
            // 
            // countryFlag
            // 
            this.countryFlag.DataPropertyName = "flag";
            this.countryFlag.HeaderText = "Flag";
            this.countryFlag.Name = "countryFlag";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(34, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCountries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 611);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewTable);
            this.Name = "FormCountries";
            this.Text = "Countries";
            this.Load += new System.EventHandler(this.FormCountries_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryAlpha3Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn countrySubregion;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryPopulation;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryLatLng;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDemonym;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryTimeZone;
        private System.Windows.Forms.DataGridViewLinkColumn countryFlag;
    }
}

