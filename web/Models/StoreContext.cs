using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace firstWeb.Models
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
        //lấy danh sách các khoa
        public List<Khoa> GetKhoas()
        {
            List<Khoa> list = new List<Khoa>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from KHOA";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Khoa()
                        {
                            MaKhoa = reader["MaKhoa"].ToString(),
                            TenKhoa = reader["TenKhoa"].ToString(),
                        });
                    }
                    reader.Close(); 
                }
                
                conn.Close();
                
            }
            return list;
        }
        public int InsertKhoa(Khoa kh)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into KHOA values(@makhoa, @tenkhoa)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("makhoa", kh.MaKhoa);
                cmd.Parameters.AddWithValue("tenkhoa", kh.TenKhoa);
                return (cmd.ExecuteNonQuery());

            }
        }
        public int UpdateKhoa(Khoa kh)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update KHOA set TenKhoa = @tenkhoa where MaKhoa=@makhoa";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("tenkhoa", kh.TenKhoa);
                cmd.Parameters.AddWithValue("makhoa", kh.MaKhoa);
                return (cmd.ExecuteNonQuery());
            }
        }
        
        public int XoaKhoa(string Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from KHOA where MaKhoa=@makhoa";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("makhoa", Id);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int InsertBoMon(BoMon bm)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into BOMON values(@mabomon, @tenbomon,@makhoa)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabomon", bm.MaBoMon);
                cmd.Parameters.AddWithValue("tenbomon", bm.TenBoMon);
                cmd.Parameters.AddWithValue("makhoa", bm.MaKhoa);
                return (cmd.ExecuteNonQuery());

            }
        }
        public Khoa ViewKhoa(string Id)
        {
            //Khoa kh = new Khoa("MK01","HTTT");
            Khoa kh = new Khoa();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from KHOA where MaKhoa=@makhoa";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("makhoa", Id);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    kh.MaKhoa=reader["MaKhoa"].ToString();
                    kh.TenKhoa = reader["TenKhoa"].ToString();
                }
            }
            return (kh);
        }
    
        public StoreContext()
        {
        }
    }
}
