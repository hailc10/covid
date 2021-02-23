using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace ontapck.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }//biết thành viên 

        public StoreContext(string connectionString) //phuong thuc khoi tao
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection() //lấy connection 
        {
            return new MySqlConnection(ConnectionString);
        }

        public int InsertDCL(diemcachly dcl)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into DIEMCACHLY values(@madiemcachly, @tendiemcachly,@diachi)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("madiemcachly", dcl.MaDiemCachLy);
                cmd.Parameters.AddWithValue("tendiemcachly", dcl.TenDiemCachLy);
                cmd.Parameters.AddWithValue("diachi", dcl.DiaChi);
                return (cmd.ExecuteNonQuery());

            }
        }

        public List<cntheotrieuchung> GetCNtheotrieuchung(int SoTrieuChung)
        {
            List<cntheotrieuchung> list = new List<cntheotrieuchung>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT congnhan.TenCongNhan,congnhan.NamSinh,congnhan.NuocVe,COUNT(*) as 'SoTrieuChung'" +
                    " FROM `cn_tc`,`congnhan` WHERE cn_tc.MaCongNhan = congnhan.MaCongNhan GROUP BY congnhan.MaCongNhan HAVING SoTrieuChung >= @sotrieuchung";
                MySqlCommand cmd = new MySqlCommand(str, conn); // THUC HIEN CAU TRUY VAN
                cmd.Parameters.AddWithValue("sotrieuchung", SoTrieuChung);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new cntheotrieuchung()
                        {

                            // DOC DU LIEU TU BIEN DATABASE LUU VAO BIEN CLASS
                            TenCongNhan = reader["TenCongNhan"].ToString(),
                            NamSinh = int.Parse(reader["NamSinh"].ToString()),
                            NuocVe = reader["NuocVe"].ToString(),
                            SoTrieuChung = int.Parse(reader["SoTrieuChung"].ToString()),
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }

        public List<diemcachly> GetDiemCachLy()
        {
            List<diemcachly> list = new List<diemcachly>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT * FROM diemcachly";

                MySqlCommand cmd = new MySqlCommand(str, conn); // THUC HIEN CAU TRUY VAN

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new diemcachly()
                        {

                            // DOC DU LIEU TU BIEN DATABASE LUU VAO BIEN CLASS
                            MaDiemCachLy = reader["MaDiemCachLy"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            TenDiemCachLy = reader["TenDiemCachLy"].ToString(),

                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }


        public List<congnhan> GetCongNhanByMaDiem(string MaDiemCachLy)
        {
            List<congnhan> list = new List<congnhan>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT * FROM congnhan WHERE MaDiemCachLy = @madiemcachly";

                MySqlCommand cmd = new MySqlCommand(str, conn); // THUC HIEN CAU TRUY VAN
                cmd.Parameters.AddWithValue("madiemcachly", MaDiemCachLy);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new congnhan()
                        {

                            // DOC DU LIEU TU BIEN DATABASE LUU VAO BIEN CLASS
                            MaCongNhan = reader["MaCongNhan"].ToString(),
                            TenCongNhan = reader["TenCongNhan"].ToString(),

                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        
        
        public int XoaCongNhan(string Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str= "DELETE FROM `cn_tc` WHERE MaCongNhan = @mcn;"+
                         "DELETE FROM `congnhan` WHERE MaCongNhan = @mcn ";
               
                MySqlCommand cmd = new MySqlCommand(str, conn);
               
                cmd.Parameters.AddWithValue("mcn", Id);

                return (cmd.ExecuteNonQuery());
               
            }
        }
   
        public congnhan ViewCongNhan(string Id) {
         congnhan cn = new congnhan();

        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            var str = "select * from congnhan where MaCongNhan=@mcn";
            MySqlCommand cmd = new MySqlCommand(str, conn);
            cmd.Parameters.AddWithValue("mcn", Id);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                    cn.MaCongNhan = reader["MaCongNhan"].ToString();
                    cn.TenCongNhan = reader["TenCongNhan"].ToString();
                    cn.GioiTinh = bool.Parse(reader["GioiTinh"].ToString());
                    cn.NamSinh = int.Parse(reader["NamSinh"].ToString());
                    cn.NuocVe = reader["NuocVe"].ToString();
            }
        }

        return (cn);
       }

        public int UpdateCongNhan(congnhan cn)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update CONGNHAN set TenCongNhan = @tencongnhan, GioiTinh = @gt, NamSinh = @ns, NuocVe = @nv where MaCongNhan=@macongnhan";
                MySqlCommand cmd = new MySqlCommand(str, conn);     
                cmd.Parameters.AddWithValue("macongnhan", cn.MaCongNhan);
                cmd.Parameters.AddWithValue("tencongnhan", cn.TenCongNhan);
                  cmd.Parameters.AddWithValue("gt", cn.GioiTinh);
                cmd.Parameters.AddWithValue("ns", cn.NamSinh);
                cmd.Parameters.AddWithValue("nv", cn.NuocVe);
                return (cmd.ExecuteNonQuery());
            }
        }


    }
}





