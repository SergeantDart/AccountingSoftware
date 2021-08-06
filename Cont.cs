using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectContabilitate
{
    [Serializable]
    public class Cont
    {
        private int nrCont;
        private int suma;
        private char naturaCont;

        public Cont()
        {
            this.nrCont = 0;
            this.suma = 0;
            this.naturaCont = 'N';
        }
         
        public Cont(int nrCont, int suma, char naturaCont)
        {
            this.nrCont = nrCont;
            this.suma = suma;
            this.naturaCont = naturaCont;
        }

        public int NrCont
        {
            get
            {
                return this.nrCont;
            }
            set
            {
                if (value != 0)
                    this.nrCont = value;
            }
        }

        public int Suma
        {
            get
            {
                return this.suma;
            }
            set
            {
                if (value != 0)
                    this.suma = value;
            }
        }
        public char NaturaCont
        {
            get
            {
                return this.naturaCont;
            }
            set
            {
                if (value != 0)
                    this.naturaCont = value;
            }
        }

        public override string ToString()
        {
            return "         " + this.nrCont + "                             " + this.suma;
        }
    }

}
