using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static FinalHDT.Pages.Manager.Parisment.ChildrenModel;
using System.Data.SqlClient;

namespace FinalHDT.Pages.Manager.Edu
{
    public class EducationModel : PageModel
    {
        public List<eduInfo> Edu = new List<eduInfo>();
       
        public void OnGet()
        {

            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Education";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                eduInfo edu = new eduInfo();

                                edu.ID = reader.GetString(1);
                                edu.Year = reader.GetString(2);
                                edu.Lecture = reader.GetString(3);
                                edu.Class = reader.GetString(4);
                                eduInfo.Add(edu);
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
        public class eduInfo
        {
            public string ID;
            public string Year;
            public string Lecture;
            public string Class;


        }
    }
}
