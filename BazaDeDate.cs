using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office;

namespace ProiectContabilitate
{
    public partial class BazaDeDate : Form
    {
        string connString;
        public BazaDeDate()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Conturi.accdb";
        }

        private void BazaDeDate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'conturiDataSet1.Conturi_analizate' table. You can move, or remove it, as needed.
            this.conturi_analizateTableAdapter1.Fill(this.conturiDataSet1.Conturi_analizate);
            // TODO: This line of code loads data into the 'conturiDataSet.Conturi_analizate' table. You can move, or remove it, as needed.
            this.conturi_analizateTableAdapter1.Fill(this.conturiDataSet1.Conturi_analizate);

        }

        private void ștergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                OleDbConnection conexiune = new OleDbConnection(connString);
                try
                {
                    conexiune.Open();
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = conexiune;
                    comanda.CommandText = "DELETE FROM Conturi_analizate WHERE Nr_cont_analizat=" + Convert.ToInt32(row.Cells[0].Value);
                    comanda.ExecuteNonQuery();
                    conexiune.Close();
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.conturi_analizateTableAdapter1.Fill(this.conturiDataSet1.Conturi_analizate);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.Update();
            dataGridView1.Refresh();
            this.conturi_analizateTableAdapter1.Fill(this.conturiDataSet1.Conturi_analizate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcel = new Microsoft.Office.Interop.Excel.Application();
                xcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    xcel.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        xcel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcel.Columns.AutoFit();
                xcel.Visible = true;
            }
        }
    }
}
