using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ontapck.Models
{
    public class cn_tc
    {
        private string maTrieuChung;
        private string maCongNhan;

        public cn_tc() { }
        public cn_tc(string matc,string macn) {
            this.maTrieuChung = matc;
            this.maCongNhan = macn;
        }

        public string MaTrieuChung
        {
            get { return maTrieuChung; }
            set { maTrieuChung = value; }
        }

        public string MaCongNhan
        {
            get { return maCongNhan; }
            set { maCongNhan = value; }
        }
    }
}
