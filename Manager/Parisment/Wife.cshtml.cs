using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static FinalHDT.Pages.Manager.Parisment.HusbandModel;
using static FinalHDT.Pages.Manager.Parisment.WifeModel;
using System.Data.SqlClient;

namespace FinalHDT.Pages.Manager.Parisment
{
  
    public class WifeModel : PageModel
    {
        public List<wifeinfo> Wife = new List<wifeinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Wife ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                wifeinfo Wifes = new wifeinfo();

                                Wifes.BookID = reader.GetString(1);
                                Wifes.Fullname = reader.GetString(2);
                                Wifes.HolyName = reader.GetString(3);
                                Wifes.FatherName = reader.GetString(4);
                                Wifes.MotherName = reader.GetString(5);
                                Wifes.HomeAddress = reader.GetString(6);
                                Wifes.dateOfbrid = reader.GetInt32(7);
                                Wifes.club = reader.GetString(8);
                                Wifes.Region = reader.GetString(9);
                                Wifes.Cathedral = reader.GetString(11);
                                Wifes.Catholic = reader.GetString(12);
                                Wifes.Children = reader.GetString(13);
                                Wifes.DateMr = reader.GetString(14);
                                Wifes.Priest = reader.GetString(15);
                                Wifes.Terrioty = reader.GetString(16);
                                Wifes.Priest = reader.GetString(17);
                                Wifes.BM1 = reader.GetString(18);
                                Wifes.BM2 = reader.GetString(19);


                                Wife.Add(Wifes);
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
        public class wifeinfo : Person
        {
        }
    }
}
