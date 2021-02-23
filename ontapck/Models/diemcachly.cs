using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ontapck.Models
{
    public class diemcachly
    {
        private string maDiemCachLy;
        private string tenDiemCachLy;
        private string diaChi;

        public diemcachly()
        {

        }

        public diemcachly(string mcl,string tcl,string dichi) {
            this.maDiemCachLy = mcl;
            this.tenDiemCachLy = tcl;
            this.diaChi = dichi;
        }

        public string MaDiemCachLy
        {
            get { return maDiemCachLy; }
            set { maDiemCachLy = value; }
        }

        public string TenDiemCachLy
        {
            get { return tenDiemCachLy; }
            set { tenDiemCachLy = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

    }
}
