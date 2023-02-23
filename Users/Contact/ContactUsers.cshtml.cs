using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static FinalHDT.Pages.Manager.Contact.ContactManagerModel;

namespace FinalHDT.Pages.Contact
{
    public class ContactUsersModel : PageModel
    {
        public Contactinfo contacts = new Contactinfo();
        public String errorMessage = "";
        public String suscessMessage = "";
            public void OnGet()
        {

            contacts.FullName = Request.Form["Fullname"];
            contacts.Email = Request.Form["email"];
            contacts.Phone = Request.Form["phone"];
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
            //save to data base
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Table" +
                                  "(FullName,Email,Phone) VALUES " +
                                  "(@FullName,@Email,@Phone);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FulNname", contacts.FullName);
                        command.Parameters.AddWithValue("@Email", contacts.Email);
                        command.Parameters.AddWithValue("@Phone", contacts.FullName);
                        command.ExecuteNonQuery();
                    }
                }


            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            contacts.FullName = "";
            contacts.Email = "";

            contacts.Phone = "";
            suscessMessage = "New Client added correctly";
            Response.Redirect("/Clients/Index");
        }
    }
}
