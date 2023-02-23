using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static FinalHDT.Pages.Manager.Edu.EducationModel;
using System.Data.SqlClient;


namespace FinalHDT.Pages.Users.Edu
{
    public class EduModel : PageModel
    {
        public eduInfo edu = new eduInfo();
        public void OnGet()
        {

            edu.ID = Request.Form["ID"];
            edu.Class = Request.Form["Class"];
            edu.Lecture = Request.Form["Lecture"];
            edu.Year = Request.Form["Year"];
        }
        public void OnPost()
        {
            edu.ID = Request.Form["ID"];
            edu.Class = Request.Form["Class"];
            edu.Lecture = Request.Form["Lecture"];
            edu.Year = Request.Form["Year"];

            //save to data base
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Education" +
                                  "(ID,Class,Lecture,Year) VALUES " +
                                  "(@ID,@Class,@Year,@Lecture);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", edu.ID);
                        command.Parameters.AddWithValue("@Class", edu.Class);
                        command.Parameters.AddWithValue("@Lecure", edu.Lecture);
                        command.Parameters.AddWithValue("@Year", edu.Year);
                        command.ExecuteNonQuery();
                    }
                }


            }
            catch (Exception ex)
            {

                return;
            }

            Response.Redirect("/Clients/Index");
        }
    }
}
