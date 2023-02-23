using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static FinalHDT.Pages.Manager.Contact.ContactManagerModel;
using static FinalHDT.Pages.Manager.Parisment.ChildrenModel;
using System.Data.SqlClient;

namespace FinalHDT.Pages.Users.Information
{
    public class ChildInputModel : PageModel
    {
        public ChildInfo child = new ChildInfo();
        public void OnGet()
            {

            child.BookID = Request.Form["BookId"];
            child.Fullname = Request.Form["Fullname"];
            child.HolyName = Request.Form["HolyName"];
            child.FatherName = Request.Form["FatherName"];
            child.MotherName = Request.Form["MotherName"];
            child.HomeAddress = Request.Form["HomeAddress"];
            child.Hospital = Request.Form["Hospital"];
            child.gender = Request.Form["gender"];
            child.Culture = Request.Form["Culture"];
            child.Baptism = Request.Form["Baptism"];
            child.Cetechism = Request.Form["Cetechism"];
            child.Communion = Request.Form["Communion"];
            child.Confirmation = Request.Form["Confirmation"];
        }
        public void OnPost()
        {
            child.BookID = Request.Form["BookId"];
            child.Fullname = Request.Form["Fullname"];
            child.HolyName = Request.Form["HolyName"];
            child.FatherName = Request.Form["FatherName"];
            child.MotherName = Request.Form["MotherName"];
            child.HomeAddress = Request.Form["HomeAddress"];
            child.Hospital = Request.Form["Hospital"];
            child.gender = Request.Form["gender"];
            child.Culture = Request.Form["Culture"];
            child.Baptism = Request.Form["Baptism"];
            child.Cetechism = Request.Form["Cetechism"];
            child.Communion = Request.Form["Communion"];
            child.Confirmation = Request.Form["Confirmation"];
        
           
            //save to data base
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Child" +
                                  "(BookId,Fullname,HolyName,FatherName,MotherName,HomeAddress,Hospital,gender,Culture,Baptism,Cetechism,Communion,Confirmation) VALUES " +
                                  "(@BookId,@Fullname,@HolyName,@FatherName,@MotherName,@HomeAddress,@Hospital,@gender,@Culture,@Baptism,@Cetechism,@Communion,@Confirmation);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", child.BookID);
                        command.Parameters.AddWithValue("@Fullname", child.Fullname);
                        command.Parameters.AddWithValue("@HolyName", child.HolyName);
                        command.Parameters.AddWithValue("@FatherName", child.FatherName);
                        command.Parameters.AddWithValue("@MotherName", child.MotherName);
                        command.Parameters.AddWithValue("@HomeAddress", child.HomeAddress);
                        command.Parameters.AddWithValue("@Hospital", child.Hospital);
                        command.Parameters.AddWithValue("@gender", child.gender);
                        command.Parameters.AddWithValue("@Culture", child.Culture);
                        command.Parameters.AddWithValue("@Baptism", child.Baptism);
                        command.Parameters.AddWithValue("@Cetechism", child.Cetechism);
                        command.Parameters.AddWithValue("@Communion", child.Communion);
                        command.Parameters.AddWithValue("@Confirmation", child.Confirmation);
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

