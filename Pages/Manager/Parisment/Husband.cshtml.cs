using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static FinalHDT.Pages.Manager.Parisment.ChildrenModel;
using System.Data.SqlClient;
using static FinalHDT.Pages.Manager.Parisment.HusbandModel;

namespace FinalHDT.Pages.Manager.Parisment
{
    public class HusbandModel : PageModel
    {
        public List<husbandInfo> HusbandInfo = new List<husbandInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Husband";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                husbandInfo husbands = new husbandInfo();

                                husbands.BookID = reader.GetString(1);
                                husbands.Fullname = reader.GetString(2);
                                husbands.HolyName = reader.GetString(3);
                                husbands.FatherName = reader.GetString(4);
                                husbands.MotherName = reader.GetString(5);
                                husbands.HomeAddress = reader.GetString(6);
                                husbands.dateOfbrid = reader.GetInt32(7);
                                husbands.club = reader.GetString(8);
                                husbands.Region = reader.GetString(9);
                                husbands.Cathedral = reader.GetString(11);
                                husbands.Catholic = reader.GetString(12);
                                husbands.Children = reader.GetString(13);
                                husbands.DateMr = reader.GetString(14);
                                husbands.Priest = reader.GetString(15);
                                husbands.Terrioty = reader.GetString(16);
                                husbands.Priest = reader.GetString(17);
                                husbands.BM1 = reader.GetString(18);
                                husbands.BM2 = reader.GetString(19);


                                HusbandInfo.Add(husbands);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption: " + ex.ToString());
            }

        }
        public class husbandInfo
        {
            public string BookID;
            public string Fullname;
            public string HolyName;
            public string FatherName;
            public string MotherName;
            public int dateOfbrid;
            public int Phone;
            public string HomeAddress;      
            public string club;
            public string Region;
            public string Catholic;
            public string Children;
            public string DateMr;
            public string Terrioty;
            public string Cathedral;
            public string Priest;
            public string BM1;
            public string BM2;

        }
    }
}
