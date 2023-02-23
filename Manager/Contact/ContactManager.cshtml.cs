using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FinalHDT.Pages.Manager.Contact
{
    public class ContactManagerModel : PageModel
    {
        public List<Contactinfo> listContacts = new List<Contactinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Table";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contactinfo contacts = new Contactinfo();

                                contacts.FullName = reader.GetString(1);
                                contacts.Email = reader.GetString(2);
                                contacts.Phone = reader.GetString(3);
                                listContacts.Add(contacts);
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
        public class Contactinfo
        {
            public string FullName;
            public string Email;
            public string Phone;
        }

    }
}

