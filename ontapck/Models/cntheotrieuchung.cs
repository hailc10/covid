using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ontapck.Models
{
    public class cntheotrieuchung
    {
        private string tenCongNhan;
        private int namSinh;
        private string nuocVe;
        private int soTrieuChung;
        public cntheotrieuchung() { }
        public cntheotrieuchung(string tencn, int ns,string ncv,int stc)
        {
            this.tenCongNhan = tencn;
            this.namSinh = ns;
            this.nuocVe = ncv;
            this.soTrieuChung = stc;
        }

        public string TenCongNhan
        {
            get { return tenCongNhan; }
            set { tenCongNhan = value; }
        }

        public int NamSinh
        {
            get { return namSinh; }
            set { namSinh = value; }
        }

        public string NuocVe
        {
            get { return nuocVe; }
            set { nuocVe = value; }
        }

        public int SoTrieuChung
        {
            get { return soTrieuChung; }
            set { soTrieuChung = value; }
        }

    }
}
