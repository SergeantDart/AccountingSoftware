using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectContabilitate
{
    public partial class GraficSituatie : Form
    {
        List<OperatiuneContabila> lista;
        public GraficSituatie(List<OperatiuneContabila> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        private void GraficSituatie_Load(object sender, EventArgs e)
        {
            foreach(OperatiuneContabila oc in lista)
            {
                chart1.Series["Rulaj debitor"].Points.AddXY(oc.NrCont.ToString(),oc.rulajDebitor());
                chart1.Series["Rulaj creditor"].Points.AddXY(oc.NrCont.ToString(),oc.rulajCreditor());
                chart1.ChartAreas.FirstOrDefault().AxisX.Interval = 1;

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
