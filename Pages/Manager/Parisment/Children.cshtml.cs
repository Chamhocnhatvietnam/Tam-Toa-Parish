using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static FinalHDT.Pages.Manager.Contact.ContactManagerModel;
using System.Data.SqlClient;
using static FinalHDT.Pages.Manager.Parisment.ChildrenModel;
using System.Data;

namespace FinalHDT.Pages.Manager.Parisment
{
    public class ChildrenModel : PageModel
    {
        public List<ChildInfo> Childinfo = new List<ChildInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Children";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChildInfo child = new ChildInfo();

                                child.BookID = reader.GetString(1);
                                child.Fullname = reader.GetString(2);
                                child.HolyName = reader.GetString(3);
                                child.FatherName = reader.GetString(4);
                                child.MotherName = reader.GetString(5);
                                child.HomeAddress = reader.GetString(6);
                                child.dateOfbrid = reader.GetInt32(7);
                                child.gender = reader.GetString(8);
                                child.Hospital = reader.GetString(9);                          
                                child.Cetechism = reader.GetString(10);
                                child.Communion = reader.GetString(11);
                                child.Confirmation = reader.GetString(12);
                               
                                Childinfo.Add(child);
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
        public class ChildInfo
        {
            public string BookID;
            public string Fullname;
            public string HolyName;
            public string FatherName;
            public string MotherName;
            public int dateOfbrid;
            public string HomeAddress;
            public string gender;
            public string Hospital;
            public string Culture;
            public string Cetechism;
            public string Baptism;
            public string Communion;
            public string Confirmation;

        }
    }
}
