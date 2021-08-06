using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectContabilitate
{
    public partial class AfisareAnaliza : Form
    {
        int nrCont;
        char tip;
        int soldInitial;
        List<Cont> listaConturiDebit;
        List<Cont> listaConturiCredit;
        public AfisareAnaliza(int nrCont, char tip, int soldInitial, List<Cont> listaConturiDebit, List<Cont> listaConturiCredit)
        {
            InitializeComponent();
            this.nrCont = nrCont;
            this.tip = tip;
            this.soldInitial = soldInitial;
            this.listaConturiDebit = listaConturiDebit;
            this.listaConturiCredit = listaConturiCredit;
        }

        private void salvareFisier(Control c)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.bmp)|*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Graphics g = c.CreateGraphics();
                Bitmap bmp = new Bitmap(c.Width, c.Height);
                c.DrawToBitmap(bmp, new Rectangle(c.ClientRectangle.X, c.ClientRectangle.Y, c.Width, c.Height));
                bmp.Save(dlg.FileName);
                bmp.Dispose();
            }
        }

        private void formatBitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvareFisier(pnl);
        }

        private void AfisareAnaliza_Activated(object sender, EventArgs e)
        {
            int rulajDebitor = 0;
            int rulajCreditor = 0;
            int SFD = 0;
            int SFC = 0;
            lblCont.Text = Convert.ToString(nrCont);
            if (tip == 'D')
            {
                lblSICredit.Text = "";
                lblSID.Text = Convert.ToString(soldInitial);
                lblSIC.Text = "";
            }
            else
            {
                lblSIDebit.Text = "";
                lblSID.Text = "";
                lblSIC.Text = Convert.ToString(soldInitial);
            }
            lblDebit.Text = "";
            lblCredit.Text = "";
            foreach (Cont c in listaConturiDebit)
            {
                lblDebit.Text = lblDebit.Text + Convert.ToString(c.Suma) + Environment.NewLine;
                rulajDebitor = rulajDebitor + c.Suma;
            }
            foreach (Cont c in listaConturiCredit)
            {
                lblCredit.Text = lblCredit.Text + Convert.ToString(c.Suma) + Environment.NewLine;
                rulajCreditor = rulajCreditor + c.Suma;
            }
            lblRD.Text = Convert.ToString(rulajDebitor);
            lblRC.Text = Convert.ToString(rulajCreditor);
            if (tip == 'D')
            {
                lblSFCredit.Text = "";
                SFD = soldInitial - rulajDebitor + rulajCreditor;
                lblSFD.Text = Convert.ToString(SFD);
                lblSFC.Text = "";
            }
            else
            {
                lblSFDebit.Text = "";
                lblSFD.Text = "";
                SFC = soldInitial + rulajDebitor - rulajCreditor;
                lblSFC.Text = Convert.ToString(SFC);
            }

        }
    }
}
