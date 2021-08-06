using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing.Printing;
using System.Windows.Forms.VisualStyles;
using System.Data.OleDb;

namespace ProiectContabilitate
{
    public partial class Situatie : Form
    {
        string connString;
        List<OperatiuneContabila> lista;
        int rulajDebitor;
        int rulajCreditor;
        int soldFinalDebitor;
        int soldFinalCreditor;
        int totalSFD = 0;
        int totalSFC = 0;
        public Situatie(List<OperatiuneContabila> listaOp)
        {
            
            InitializeComponent();
            lista = listaOp;
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Conturi.accdb";
            this.Location = new Point(Inregistrare.ActiveForm.Location.X + 887, Inregistrare.ActiveForm.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GraficSituatie frm = new GraficSituatie(lista);
            frm.Show();
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            lista.Clear();
            refreshToolStripMenuItem_Click(sender, e);
        }

        internal void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach(OperatiuneContabila oc in lista)
            {
                ListViewItem itm = new ListViewItem(oc.NrCont.ToString());
                itm.SubItems.Add(oc.TipCont.ToString());
                itm.SubItems.Add(oc.Perioada);
                itm.SubItems.Add(oc.SoldInitial.ToString());
                itm.SubItems.Add(oc.rulajDebitor().ToString());
                itm.SubItems.Add(oc.rulajCreditor().ToString());
                if (oc.TipCont == 'D')
                {
                    itm.SubItems.Add(oc.soldFinalDebitor().ToString());
                    itm.SubItems.Add(0.ToString());
                }
                else
                {
                    itm.SubItems.Add(0.ToString());
                    itm.SubItems.Add(oc.soldFinalCreditor().ToString());
                }

                listView1.Items.Add(itm);
            }

            textBox1.Clear();
            totalSFD = 0;
            totalSFC = 0;
            foreach (OperatiuneContabila oc in lista)
            {
                rulajDebitor = oc.rulajDebitor();
                rulajCreditor = oc.rulajCreditor();
                if (oc.TipCont == 'D')
                {
                    soldFinalDebitor = oc.soldFinalDebitor();
                    soldFinalCreditor = 0;
                }
                else
                {
                    soldFinalDebitor = 0;
                    soldFinalCreditor = oc.soldFinalCreditor();
                }
                totalSFD = totalSFD + soldFinalDebitor;
                totalSFC = totalSFC + soldFinalCreditor;
                
            }
            lblTotalSFD.Text = Convert.ToString(totalSFD);
            lblTotalSFC.Text = Convert.ToString(totalSFC);
            if (totalSFD == totalSFC)
                lblRezultat.Text = "Totalul pasivelor este egal cu totalul activelor !";
            else
                lblRezultat.Text = "Totalul pasivelor NU este egal cu totalul activelor, recompletați situația ! ";
        }

        private void salvareFisier1(Control c)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter="(*.bmp)|*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK) 
            {
                Graphics g = c.CreateGraphics();
                Bitmap bmp = new Bitmap(c.Width, c.Height);
                c.DrawToBitmap(bmp, new Rectangle(c.ClientRectangle.X, c.ClientRectangle.Y, c.Width, c.Height));
                bmp.Save(dlg.FileName);
                bmp.Dispose();
            }         
        }

        public static explicit operator Situatie(int v)
        {
            throw new NotImplementedException();
        }

        private void printareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvareFisier1(pnl);
        }

        private void formatBinarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.binarylist)|*.binarylist";
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, lista);
                fs.Close();
                button2_Click(sender, e);
            }
        }

        private void formatBinarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.binarylist)|*.binarylist";
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                List<OperatiuneContabila> listaPreluata = new List<OperatiuneContabila>();
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                listaPreluata = (List<OperatiuneContabila>)bf.Deserialize(fs);
                lista = lista.Concat(listaPreluata).ToList();
                fs.Close();
                refreshToolStripMenuItem_Click(sender, e);
            }
        }

        private void ajutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help frm = new Help();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lista.Sort();
            refreshToolStripMenuItem_Click(sender, e);
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

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
                listView1.DoDragDrop(listView1.SelectedItems[0], DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (((e.KeyState & 8) == 8) && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else
                if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            textBox1.Clear();
            ListViewItem itm = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            int nrCont = Convert.ToInt32(itm.SubItems[0].Text);
            string perioada = itm.SubItems[2].Text;
            int pozitie = lista.FindIndex(item => item.NrCont == nrCont && item.Perioada == perioada);
            textBox1.Text = textBox1.Text + lista[pozitie].ToString()+Environment.NewLine;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Situatia contabila pentru firma noastra:", new Font(FontFamily.GenericSansSerif,30), new SolidBrush(Color.Black), new Point(e.PageBounds.X / 2, 0));
            Bitmap img = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(img, new Rectangle(0, 0, pnl.Width, pnl.Height));
            e.Graphics.DrawImage(img, new Point(e.PageBounds.X,e.PageBounds.Y+350));
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }

        private void ștergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView1.SelectedItems)

            {
                OleDbConnection conexiune = new OleDbConnection(connString);
                try
                {
                    conexiune.Open();
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = conexiune;
                    comanda.CommandText = "DELETE FROM Conturi_analizate WHERE Nr_cont_analizat=" + Convert.ToInt32(itm.SubItems[0].Text) + " AND Perioada='" + itm.SubItems[2].Text + "'";
                    comanda.ExecuteNonQuery();
                    int pozitie = lista.FindIndex(item => item.NrCont.ToString() == itm.SubItems[0].Text && item.Perioada == itm.SubItems[2].Text);
                    lista.RemoveAt(pozitie);
                    refreshToolStripMenuItem_Click(sender, e);
                    conexiune.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }

        public void stergeItem(ListViewItem itm)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "DELETE FROM Conturi_analizate WHERE Nr_cont_analizat=" + Convert.ToInt32(itm.SubItems[0].Text) + " AND Perioada='" + itm.SubItems[2].Text + "'";
                comanda.ExecuteNonQuery();
                int pozitie = lista.FindIndex(item => item.NrCont.ToString() == itm.SubItems[0].Text && item.Perioada == itm.SubItems[2].Text);
                lista.RemoveAt(pozitie);
                conexiune.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                foreach (OperatiuneContabila oc in lista)
                {
                    try
                    {
                        OleDbCommand comanda = new OleDbCommand();
                        comanda.Connection = conexiune;
                        comanda.CommandText = "INSERT INTO Conturi_analizate(Nr_cont_analizat,Tip_cont_analizat,Perioada,Sold_initial,Rulaj_debitor,Rulaj_creditor,Sold_final_debitor,Sold_final_creditor) VALUES(?,?,?,?,?,?,?,?)";
                        comanda.Parameters.Add("Nr_cont_analizat", OleDbType.Integer).Value = oc.NrCont;
                        comanda.Parameters.Add("Tip_cont_analizat", OleDbType.Char).Value = oc.TipCont.ToString();
                        comanda.Parameters.Add("Perioada", OleDbType.Char).Value = oc.Perioada.ToString();
                        comanda.Parameters.Add("Sold_initial", OleDbType.Integer).Value = oc.SoldInitial;
                        comanda.Parameters.Add("Rulaj_debitor", OleDbType.Integer).Value = oc.rulajDebitor();
                        comanda.Parameters.Add("Rulaj_creditor", OleDbType.Integer).Value = oc.rulajCreditor();
                        if (oc.TipCont == 'D')
                        {
                            comanda.Parameters.Add("Sold_final_debitor", OleDbType.Integer).Value = oc.soldFinalDebitor();
                            comanda.Parameters.Add("Sold_final_creditor", OleDbType.Integer).Value = 0;

                        }
                        else
                        {
                            comanda.Parameters.Add("Sold_final_debitor", OleDbType.Integer).Value = 0;
                            comanda.Parameters.Add("Sold_final_creditor", OleDbType.Integer).Value = oc.soldFinalCreditor();
                        }
                        comanda.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        try
                        {
                            OleDbCommand comanda = new OleDbCommand();
                            comanda.Connection = conexiune;
                            comanda.CommandText = "UPDATE Conturi_analizate SET Tip_cont_analizat='" + oc.TipCont.ToString() + "' WHERE Nr_cont_analizat=" + oc.NrCont;
                            comanda.ExecuteNonQuery();
                            comanda.CommandText = "UPDATE Conturi_analizate SET Perioada='" + oc.Perioada + "' WHERE Nr_cont_analizat=" + oc.NrCont;
                            comanda.ExecuteNonQuery();
                            comanda.CommandText = "UPDATE Conturi_analizate SET Sold_initial=" + oc.SoldInitial + " WHERE Nr_cont_analizat=" + oc.NrCont;
                            comanda.ExecuteNonQuery();
                            comanda.CommandText = "UPDATE Conturi_analizate SET Rulaj_debitor=" + oc.rulajDebitor() + " WHERE Nr_cont_analizat=" + oc.NrCont;
                            comanda.ExecuteNonQuery();
                            comanda.CommandText = "UPDATE Conturi_analizate SET Rulaj_creditor=" + oc.rulajCreditor() + " WHERE Nr_cont_analizat=" + oc.NrCont;
                            comanda.ExecuteNonQuery();
                            if (oc.TipCont == 'D')
                            {
                                comanda.CommandText = "UPDATE Conturi_analizate SET Sold_final_debitor=" + oc.soldFinalDebitor() + " WHERE Nr_cont_analizat=" + oc.NrCont;
                                comanda.ExecuteNonQuery();
                                comanda.CommandText = "UPDATE Conturi_analizate SET Sold_final_creditor=0 WHERE Nr_cont_analizat=" + oc.NrCont;
                                comanda.ExecuteNonQuery();
                            }
                            else
                            {
                                comanda.CommandText = "UPDATE Conturi_analizate SET Sold_final_debitor=0 WHERE Nr_cont_analizat=" + oc.NrCont;
                                comanda.ExecuteNonQuery();
                                comanda.CommandText = "UPDATE Conturi_analizate SET Sold_final_creditor=" + oc.soldFinalCreditor() + " WHERE Nr_cont_analizat=" + oc.NrCont;
                                comanda.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                conexiune.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                MessageBox.Show("Baza de date a fost actualizata!");
            }
        }

        public void OnAdaugareInLista(object sender,EventArgs e)
        {
            refreshToolStripMenuItem_Click(sender, e);
        }

        private void Situatie_Load(object sender, EventArgs e)
        {
            refreshToolStripMenuItem_Click(sender, e);
        }

        public bool IsFormOpen(Type formType)
        {
            foreach (Form form in Application.OpenForms)
                if (form.GetType().Name == form.Name)
                    return true;
            return false;
        }
        public void editeazăToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = 0;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "Inregistrare")
                {
                    k = 1;
                }
            }
            if (k == 1) 
            {
                Application.OpenForms["Inregistrare"].Close();
                Inregistrare inr = new Inregistrare(listView1.SelectedItems[0],lista);
                inr.Show();
            }
            else
            {
                Inregistrare inr = new Inregistrare(listView1.SelectedItems[0],lista);
                inr.Show();
            }
        }

        private void vizualizareBazăDeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BazaDeDate frm = new BazaDeDate();
            frm.Show();
        }

        private void închidereAplicațieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main master = (Main)Application.OpenForms["Main"];
            master.Close();
        }
    }
}
