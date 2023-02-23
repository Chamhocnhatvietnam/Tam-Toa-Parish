using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static FinalHDT.Pages.Manager.Contact.ContactManagerModel;

namespace FinalHDT.Pages.Manager.Contact
{
    public class EditManagerModel : PageModel
    {
        public Contactinfo contacts = new Contactinfo();
        public string errorMessage = "";
        public string suscessMessage = "";
        public void OnGet()
        {

            string id = Request.Query["id"];
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT *FORM Table Where id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Contactinfo contacts = new Contactinfo();

                                contacts.FullName = reader.GetString(1);
                                contacts.Email = reader.GetString(2);
                                contacts.Phone = reader.GetString(3);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {
            contacts.FullName = Request.Form["Fullname"];
            contacts.Email = Request.Form["email"];
            contacts.Phone = Request.Form["phone"];
            if (contacts.Phone.Length == 0 || contacts.FullName.Length == 0 || contacts.Email.Length == 0)
            {

                errorMessage = " all field are required";
                return;
            }
            try
            {

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
    }
}
