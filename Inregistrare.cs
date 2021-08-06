using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;



namespace ProiectContabilitate
{
    public partial class Inregistrare : Form
    {
        List<Cont> listaConturiDebit = new List<Cont>();
        List<Cont> listaConturiCredit = new List<Cont>();
        List<OperatiuneContabila> operatiuniContabile;
        int rulajDebitor = 0;
        int rulajCreditor = 0;
        int soldFinalDebitor = 0;
        int soldFinalCreditor = 0;
        ListViewItem itm;
        public Inregistrare(ListViewItem itm, List<OperatiuneContabila> operatiuniContabile)
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            this.itm = itm;
            if (operatiuniContabile != null)
                this.operatiuniContabile = operatiuniContabile;
            else
                this.operatiuniContabile = new List<OperatiuneContabila>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int soldInitial = Convert.ToInt32(txtSoldInitial.Text);
                int nrCont = Convert.ToInt32(txtContComponent.Text);
                int suma = Convert.ToInt32(txtSuma.Text);
                char naturaCont;
                if (lbTip.Text == "Debit")
                    naturaCont = 'D';
                else
                    naturaCont = 'C';
                int k = 0;
                foreach (Cont cnt in listaConturiDebit)
                    if (cnt.NrCont == nrCont)
                    {
                        cnt.Suma = suma;
                        cnt.NaturaCont = naturaCont;
                        refreshToolStripMenuItem_Click(sender, e);
                    }
                    else
                        k++;
                int l = 0;
                foreach (Cont cnt in listaConturiCredit)
                    if (cnt.NrCont == nrCont)
                    {
                        cnt.Suma = suma;
                        cnt.NaturaCont = naturaCont;
                        refreshToolStripMenuItem_Click(sender, e);
                    }
                    else
                        l++;
                if(k==listaConturiDebit.Count&& l==listaConturiCredit.Count)
                {
                    Cont c = new Cont(nrCont, suma, naturaCont);
                    if (c.NaturaCont == 'D')
                        listaConturiDebit.Add(c);
                    else
                        listaConturiCredit.Add(c);
                    refreshToolStripMenuItem_Click(sender, e);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Datele nu au fost introduse corespunzător !");
            }
            finally
            {
                txtContComponent.Clear();
                txtSuma.Clear();
                lbTip.SelectedIndex=-1;
            }

        }
        public bool IsFormOpen(Type formType)
        {
            foreach (Form form in Application.OpenForms)
                if (form.GetType().Name == form.Name)
                    return true;
            return false;
        }

        public delegate void ActualizareListView(object sender, EventArgs e);

        public event ActualizareListView AdaugareInLista;

        protected virtual void OnAdaugareInLista()
        {
            AdaugareInLista?.Invoke(this, EventArgs.Empty);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int k = 0;
            foreach(OperatiuneContabila op in operatiuniContabile)
            {
                if (op.NrCont.ToString() == txtCont.Text)
                    k = 1;
            }

            if (k == 0)
            {
                try
                {
                    int nrCont = Convert.ToInt32(txtCont.Text);
                    char tip;
                    if (lbNaturaContAnalizat.Text == "Debit")
                        tip = 'D';
                    else
                        tip = 'C';
                    string perioada = txtPerioada.Text;
                    int soldInitial = Convert.ToInt32(txtSoldInitial.Text);
                    if (listaConturiCredit != null || listaConturiDebit != null)
                    {
                        OperatiuneContabila oc = new OperatiuneContabila(nrCont, tip, perioada, soldInitial, listaConturiDebit, listaConturiCredit);
                        operatiuniContabile.Add(oc);

                        FormCollection fc = Application.OpenForms;
                        foreach (Form frm in fc)
                        {
                            if (frm.Name == "Situatie")
                            {
                                AdaugareInLista(sender, e);
                            }
                        }

                        MessageBox.Show("Înregistrarea a fost adaugată în situație !");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Datele nu au fost introduse corespunzător !");
                }
                finally
                {
                    txtCont.Clear();
                    lbNaturaContAnalizat.Text = "";
                    txtPerioada.Clear();
                    txtSoldInitial.Clear();
                    listaConturiCredit.Clear();
                    listaConturiDebit.Clear();
                    refreshToolStripMenuItem_Click(sender, e);
                }
            }
            else
            {
                try
                {
                    int nrCont = Convert.ToInt32(txtCont.Text);
                    char tip;
                    if (lbNaturaContAnalizat.Text == "Debit")
                        tip = 'D';
                    else
                        tip = 'C';
                    string perioada = txtPerioada.Text;
                    int soldInitial = Convert.ToInt32(txtSoldInitial.Text);
                    if (listaConturiCredit != null || listaConturiDebit != null)
                    {
                        int pozitie = operatiuniContabile.FindIndex(item => item.NrCont.ToString() == txtCont.Text);
                        operatiuniContabile[pozitie].NrCont = nrCont;
                        operatiuniContabile[pozitie].TipCont = tip;
                        operatiuniContabile[pozitie].Perioada = perioada;
                        operatiuniContabile[pozitie].SoldInitial = soldInitial;
                        List<Cont> tempDebit = new List<Cont>();
                        foreach (Cont c in listaConturiDebit)
                            tempDebit.Add(c);
                        operatiuniContabile[pozitie].ConturiDebit = tempDebit;

                        List<Cont> tempCredit = new List<Cont>();
                        foreach (Cont c in listaConturiCredit)
                            tempCredit.Add(c);
                        operatiuniContabile[pozitie].ConturiCredit = tempCredit;

                        txtCont.Enabled = true;

                        FormCollection fc = Application.OpenForms;
                        foreach (Form frm in fc)
                        {
                            if (frm.Name == "Situatie")
                            {
                                Situatie master = (Situatie)Application.OpenForms["Situatie"];
                                master.refreshToolStripMenuItem_Click(sender, e);
                            }
                        }

                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    txtCont.Clear();
                    lbNaturaContAnalizat.Text = "";
                    txtPerioada.Clear();
                    txtSoldInitial.Clear();
                    listaConturiCredit.Clear();
                    listaConturiDebit.Clear();
                    refreshToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listaConturiDebit.Clear();
            listaConturiCredit.Clear();
            refreshToolStripMenuItem_Click(sender, e);
        }

        private  void button3_Click(object sender, EventArgs e)
        {
            Situatie frm = new Situatie(operatiuniContabile);
            frm.Show();
            this.AdaugareInLista += frm.OnAdaugareInLista;
        }

        private void txtCont_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoldInitial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtContComponent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtSuma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int soldInitial;
            try
            {
                soldInitial = Convert.ToInt32(txtSoldInitial.Text);
            }
            catch(Exception)
            {
                soldInitial = 0;
            }
            txtSoldInitial.Text = Convert.ToString(soldInitial);
            rulajCreditor = 0;
            rulajDebitor = 0;
            soldFinalDebitor = 0;
            soldFinalCreditor = 0;
            listView1.Items.Clear();
            listView2.Items.Clear();
            lblRulajDebitor.Text = "";
            lblRulajCreditor.Text = "";
            lblSoldFinalCreditor.Text = "";
            lblSoldFinalDebitor.Text = "";

            foreach (Cont cnt in listaConturiDebit)
            {
                ListViewItem itm=new ListViewItem(cnt.NrCont.ToString());
                itm.SubItems.Add(cnt.Suma.ToString());
                listView1.Items.Add(itm);
                rulajDebitor = rulajDebitor + cnt.Suma;
            }
            lblRulajDebitor.Text = Convert.ToString(rulajDebitor);

            foreach (Cont cnt in listaConturiCredit)
            {
                ListViewItem itm = new ListViewItem(cnt.NrCont.ToString());
                itm.SubItems.Add(cnt.Suma.ToString());
                listView2.Items.Add(itm);
                rulajCreditor = rulajCreditor + cnt.Suma;
            }
            lblRulajCreditor.Text = Convert.ToString(rulajCreditor);

            if (lbNaturaContAnalizat.Text == "Debit")
            {
                soldFinalDebitor = soldInitial - rulajDebitor + rulajCreditor;
                if (soldFinalDebitor < 0)
                {
                    soldFinalDebitor = 0;
                    lblSoldFinalDebitor.Text = Convert.ToString(soldFinalDebitor);
                    MessageBox.Show("Nu se poate un sold negativ ! Goliți lista de conturi și încercați din nou...");
                }
                lblSoldFinalDebitor.Text = Convert.ToString(soldFinalDebitor);
                soldFinalCreditor = 0;
                lblSoldFinalCreditor.Text = Convert.ToString(soldFinalCreditor);
            }

            else
            {
                soldFinalDebitor = 0;
                lblSoldFinalDebitor.Text = Convert.ToString(soldFinalDebitor);
                soldFinalCreditor = soldInitial + rulajDebitor - rulajCreditor;
                if (soldFinalCreditor < 0)
                {
                    soldFinalCreditor = 0;
                    lblSoldFinalCreditor.Text = Convert.ToString(soldFinalCreditor);
                    MessageBox.Show("Nu se poate un sold negativ ! Goliți lista de conturi și încercați din nou...");
                }
                lblSoldFinalCreditor.Text = Convert.ToString(soldFinalCreditor);
            }
        }

        private void formatTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(dlg.FileName);
                sw.WriteLine(txtCont.Text);
                sw.WriteLine(lbNaturaContAnalizat.Text);
                sw.WriteLine(txtPerioada.Text);
                sw.WriteLine(txtSoldInitial.Text);
                sw.WriteLine(listaConturiDebit.Count);
                foreach(Cont c in listaConturiDebit)
                {
                    sw.WriteLine(c.NrCont);
                    sw.WriteLine(c.NaturaCont);
                    sw.WriteLine(c.Suma);
                }
                sw.WriteLine(listaConturiCredit.Count);
                foreach (Cont c in listaConturiCredit)
                {
                    sw.WriteLine(c.NrCont);
                    sw.WriteLine(c.NaturaCont);
                    sw.WriteLine(c.Suma);
                }
                    
                sw.Close();
                txtCont.Clear();
                lbNaturaContAnalizat.Text = "";
                txtPerioada.Clear();
                txtSoldInitial.Clear();
                listaConturiCredit.Clear();
                listaConturiDebit.Clear();
                refreshToolStripMenuItem_Click(sender, e);
                MessageBox.Show("Înregistrarea a fost salvată în fișier text ! ");
            }
        }

        private void formatTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int nrConturiDebit;
            int nrConturiCredit;
            int nrCont;
            char tipCont;
            int sumaCont;
            List<Cont> clonaConturiDebit=new List<Cont>();
            List<Cont> clonaConturiCredit=new List<Cont>();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dlg.FileName);
                txtCont.Text = sr.ReadLine();
                lbNaturaContAnalizat.Text = sr.ReadLine();
                txtPerioada.Text = sr.ReadLine();
                txtSoldInitial.Text = sr.ReadLine();
                nrConturiDebit = Convert.ToInt32(sr.ReadLine());
                for(int i=0;i<nrConturiDebit*3;i=i+3)
                {
                    nrCont = Convert.ToInt32(sr.ReadLine());
                    tipCont =Convert.ToChar(sr.ReadLine());
                    sumaCont = Convert.ToInt32(sr.ReadLine());
                    Cont c = new Cont(nrCont, sumaCont, tipCont);
                    clonaConturiDebit.Add(c);
                }
                nrConturiCredit = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < nrConturiCredit*3; i = i + 3)
                {
                    nrCont = Convert.ToInt32(sr.ReadLine());
                    tipCont = Convert.ToChar(sr.ReadLine());
                    sumaCont = Convert.ToInt32(sr.ReadLine());
                    Cont c = new Cont(nrCont,sumaCont, tipCont);
                    clonaConturiCredit.Add(c);
                }
                listaConturiDebit = clonaConturiDebit;
                listaConturiCredit = clonaConturiCredit;
                sr.Close();
                refreshToolStripMenuItem_Click(sender, e);
            }
        }

        private void afișareAnalizăToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int nrCont = Convert.ToInt32(txtCont.Text);
                char tip;
                if (lbNaturaContAnalizat.Text == "Debit")
                    tip = 'D';
                else
                    tip = 'C';
                int soldInitial = Convert.ToInt32(txtSoldInitial.Text);
                AfisareAnaliza frm = new AfisareAnaliza(nrCont, tip, soldInitial, listaConturiDebit, listaConturiCredit);
                frm.Show();
            }
            catch(Exception)
            {
                MessageBox.Show("Nu există suficiente date pentru a genera un raport !");
            }
        }

        private void formatBinarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int nrCont = Convert.ToInt32(txtCont.Text);
                char tip;
                if (lbNaturaContAnalizat.Text == "Debit")
                    tip = 'D';
                else
                    tip = 'C';
                string perioada = txtPerioada.Text;
                int soldInitial = Convert.ToInt32(txtSoldInitial.Text);
                OperatiuneContabila oc = new OperatiuneContabila(nrCont, tip, perioada, soldInitial, listaConturiDebit, listaConturiCredit);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "(*.binary)|*.binary";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, oc);
                    fs.Close();
                    txtCont.Clear();
                    lbNaturaContAnalizat.Text = "";
                    txtPerioada.Clear();
                    txtSoldInitial.Clear();
                    listaConturiCredit.Clear();
                    listaConturiDebit.Clear();
                    refreshToolStripMenuItem_Click(sender, e);
                    MessageBox.Show("Înregistrarea a fost salvată în fișier binar ! ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatBinarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.binary)|*.binary";
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                OperatiuneContabila oc = (OperatiuneContabila)bf.Deserialize(fs);
                txtCont.Text = Convert.ToString(oc.NrCont);
                lbNaturaContAnalizat.Text = Convert.ToString(oc.TipCont);
                txtPerioada.Text = oc.Perioada;
                txtSoldInitial.Text = Convert.ToString(oc.SoldInitial);
                listaConturiDebit = oc.ConturiDebit;
                listaConturiCredit = oc.ConturiCredit;
                fs.Close();
                refreshToolStripMenuItem_Click(sender, e);
            }

        }

        private void ajutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help frm = new Help();
            frm.Show();
        }

        private void editeazăToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in listView1.Items)
            if(itm.Selected)
                {
                    txtContComponent.Text = itm.SubItems[0].Text;
                    txtSuma.Text = itm.SubItems[1].Text;
                    lbTip.SelectedIndex = -1;
                }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView2.Items)
                if (itm.Selected)
                {
                    txtContComponent.Text = itm.SubItems[0].Text;
                    txtSuma.Text = itm.SubItems[1].Text;
                    lbTip.Text = itm.SubItems[2].Text;
                }
        }

        private void ștergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in listView1.Items)
                if(itm.Selected)
                {
                    int pozitie = listaConturiDebit.FindIndex(item => item.NrCont.ToString() == itm.SubItems[0].Text);
                    listaConturiDebit.RemoveAt(pozitie);
                    refreshToolStripMenuItem_Click(sender, e);
                }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView2.Items)
                if (itm.Selected)
                {
                    int pozitie = listaConturiCredit.FindIndex(item => item.NrCont.ToString() == itm.SubItems[0].Text);
                    listaConturiCredit.RemoveAt(pozitie);
                    refreshToolStripMenuItem_Click(sender, e);
                }
        }

        private void Inregistrare_Load(object sender, EventArgs e)
        {
            if(itm!=null)
            {
                int pozitie = operatiuniContabile.FindIndex(item => item.NrCont.ToString() == itm.SubItems[0].Text);
                OperatiuneContabila oc = operatiuniContabile[pozitie];
                txtCont.Text = oc.NrCont.ToString();
                lbNaturaContAnalizat.Text = oc.TipCont.ToString();
                txtPerioada.Text = oc.Perioada.ToString();
                txtSoldInitial.Text = oc.SoldInitial.ToString();
                listaConturiDebit = oc.ConturiDebit;
                listaConturiCredit = oc.ConturiCredit;
                refreshToolStripMenuItem_Click(sender, e);
                txtCont.Enabled = false;
            }
            else
            {
                List<OperatiuneContabila> listaPreluata = new List<OperatiuneContabila>();
                FileStream fs = new FileStream("Situatie.binarylist", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                listaPreluata = (List<OperatiuneContabila>)bf.Deserialize(fs);
                operatiuniContabile = operatiuniContabile.Concat(listaPreluata).ToList();
                fs.Close();
                refreshToolStripMenuItem_Click(sender, e);
            }
        }

        private void inchidereAplicatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main master = (Main)Application.OpenForms["Main"];
            master.Close();
        }
    }
}
