using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectContabilitate
{
    [Serializable]
     public class OperatiuneContabila:ICloneable,IComparable
    {
        private int nrCont;
        private char tipCont;
        private string perioada;
        private int soldInitial;
        private List<Cont> conturiDebit;
        private List<Cont> conturiCredit;

        public OperatiuneContabila()
        {
            this.nrCont = 0;
            this.tipCont = 'N';
            this.perioada = "N/A";
            this.soldInitial = 0;
            this.conturiDebit = null;
            this.conturiCredit = null;
        }

        public OperatiuneContabila(int nrCont,char tipCont, string perioada, int soldInitial, List<Cont> conturiDebit, List<Cont> conturiCredit)
        {
            this.nrCont = nrCont;
            this.tipCont = tipCont;
            this.perioada = perioada;
            this.soldInitial = soldInitial;
            this.conturiDebit = new List<Cont>();
            foreach (Cont c in conturiDebit)
                this.conturiDebit.Add(c);
            this.conturiCredit = new List<Cont>();
            foreach (Cont c in conturiCredit)
                this.conturiCredit.Add(c);
        }

        public int NrCont
        {
            get
            {
                return this.nrCont;
            }
            set
            {
                if (value > 0)
                    this.nrCont = value;
            }
        }
        public char TipCont
        {
            get
            {
                return this.tipCont;
            }
            set
            {
                if (value == 'D' || value == 'C')
                    this.tipCont = value;
            }
        }

        public string Perioada
        {
            get
            {
                return this.perioada;
            }
            set
            {
                if (value != "")
                    this.perioada = value;
            }
        }
        public int SoldInitial
        {
            get
            {
                return this.soldInitial;
            }
            set
            {
                if (value > 0)
                    this.soldInitial = value;
            }
        }

        public List<Cont> ConturiDebit
        {
            get
            {
                return this.conturiDebit;
            }
            set
            {
                if (conturiDebit != null)
                    this.conturiDebit = value;
            }
        }

        public List<Cont> ConturiCredit
        {
            get
            {
                return this.conturiCredit;
            }
            set
            {
                if (conturiCredit != null)
                    this.conturiCredit = value;
            }
        }

        public int rulajDebitor()
        {
            int rulajDebitor = 0;
            foreach (Cont c in conturiDebit)
                rulajDebitor = rulajDebitor + c.Suma;
            return rulajDebitor;
        }

        public int rulajCreditor()
        {
            int rulajCreditor = 0;
            foreach (Cont c in conturiCredit)
                rulajCreditor = rulajCreditor + c.Suma;
            return rulajCreditor;
        }

        public int soldFinalDebitor()
        {
            int soldFinalDebitor = SoldInitial - rulajDebitor() + rulajCreditor();
            return soldFinalDebitor;
        }

        public int soldFinalCreditor()
        {
            int soldFinalCreditor = SoldInitial + rulajDebitor() - rulajCreditor();
            return soldFinalCreditor;
        }
        public override string ToString()
        {
            string result = "";
            result = result + "Cont: " + this.nrCont + "   " + Environment.NewLine + "Perioada: " + this.perioada + Environment.NewLine + "Sold initial creditor: " + this.soldInitial + Environment.NewLine;
            result = result + "Conturi debit: " + Environment.NewLine;
            foreach (Cont c in this.conturiDebit)
                result = result + c.ToString() + Environment.NewLine;
            result = result + "Conturi credit: "+ Environment.NewLine;
            foreach (Cont c in this.conturiCredit)
                result = result + c.ToString() + Environment.NewLine;
            return result;
        }


        
        public object Clone()
        {
            OperatiuneContabila oc = (OperatiuneContabila)this.MemberwiseClone();
            List<Cont> clonaConturiDebit = new List<Cont>();
            foreach (Cont c in this.conturiDebit)
                clonaConturiDebit.Add(c);
            oc.conturiDebit = clonaConturiDebit;
            List<Cont> clonaConturiCredit = new List<Cont>();
            foreach (Cont c in this.conturiCredit)
                clonaConturiCredit.Add(c);
            oc.conturiCredit = clonaConturiCredit;
            return oc;

        }

        public int CompareTo(object obj)
        {
            OperatiuneContabila oc = (OperatiuneContabila)obj;
            if (this.SoldInitial < oc.SoldInitial)
                return -1;
            else
                if (this.SoldInitial>oc.SoldInitial)
                return 1;
            else
                return this.NrCont.CompareTo(oc.NrCont);
        }
    }
}
