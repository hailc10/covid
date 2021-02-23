using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ontapck.Models
{
    public class congnhan
    {
        private string maCongNhan;
        private string tenCongNhan;
        private bool gioiTinh;
        private int namSinh;
        private string nuocVe;
        private string maDiemCachLy;


        public congnhan()
        {
        }
        public congnhan(string macn, string tencn, bool gt,int Ns, string nuocve, string diemcachly)
        {
            this.maCongNhan = macn;
            this.tenCongNhan = tencn;
            this.gioiTinh = gt;
            this.namSinh = Ns;
            this.nuocVe = nuocve;
            this.maDiemCachLy = diemcachly;
        }
        public string MaCongNhan
        {
            get { return maCongNhan; }
            set { maCongNhan = value; }
        }

        public string TenCongNhan
        {
            get { return tenCongNhan; }
            set { tenCongNhan = value; }
        }

        public bool GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
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

        public string MaDiemCachLy
        {
            get { return maDiemCachLy; }
            set { maDiemCachLy = value; }
        }
    }
}
