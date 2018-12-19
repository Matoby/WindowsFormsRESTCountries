using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace PresentationLayer
{
    public partial class FormCountries : Form
    {
        private CountryRepository _countryRepository = new CountryRepository();
        private BindingSource _tableBindingSource = new BindingSource();

        public FormCountries()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tableBindingSource.DataSource = _countryRepository.ImportCountries();
        }

        private void FormCountries_Load(object sender, EventArgs e)
        {
            dataGridViewTable.DataSource = _tableBindingSource;    
        }

        private void dataGridViewTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sUrl = dataGridViewTable.Rows[e.RowIndex].Cells[10].Value.ToString();
            ProcessStartInfo sInfo = new ProcessStartInfo(sUrl);
            Process.Start(sInfo);
        }
    }
}
