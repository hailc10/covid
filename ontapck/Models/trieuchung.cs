using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ontapck.Models
{
    public class trieuchung
    {
        private string maTrieuChung;
        private string tenTrieuChung;

        public trieuchung()
        {

        }

        public trieuchung(string matc,string ttc)
        {
            this.maTrieuChung = matc;
            this.tenTrieuChung = ttc;
        } 

        public string MaTrieuChung {
            get { return maTrieuChung; }
            set { maTrieuChung = value; }
        }

        public string TenTrieuChung
        {
            get { return tenTrieuChung; }
            set { tenTrieuChung = value; }
        }
    }
}
