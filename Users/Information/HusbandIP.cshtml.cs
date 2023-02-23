using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static FinalHDT.Pages.Manager.Parisment.ChildrenModel;
using System.Data.SqlClient;
using static FinalHDT.Pages.Manager.Parisment.HusbandModel;

namespace FinalHDT.Pages.Users.Information
{
    public class HusbandIPModel : PageModel
    {
        public husbandInfo husband = new husbandInfo();
        public void OnGet()
        {

            husband.BookID = Request.Form["BookId"];
            husband.Fullname = Request.Form["Fullname"];
            husband.HolyName = Request.Form["HolyName"];
            husband.FatherName = Request.Form["FatherName"];
            husband.MotherName = Request.Form["MotherName"];
            husband.HomeAddress = Request.Form["HomeAddress"];
       
            husband.Region = Request.Form["Region"];
            husband.club = Request.Form["club"];
            husband.HomeAddress = Request.Form["HomeAddress"];
            husband.Catholic = Request.Form["Catholic"];
            husband.Children = Request.Form["Children"];
            husband.DateMr = Request.Form["DateMr"];
            husband.Terrioty = Request.Form["Terrioty"];
            husband.Cathedral = Request.Form["Cathedral"];
            husband.Priest = Request.Form["Priest"];
            husband.BM1 = Request.Form["BM1"];
            husband.BM2 = Request.Form["BM2"];
        
        }
        public void OnPost()
        {
            husband.BookID = Request.Form["BookId"];
            husband.Fullname = Request.Form["Fullname"];
            husband.HolyName = Request.Form["HolyName"];
            husband.FatherName = Request.Form["FatherName"];
            husband.MotherName = Request.Form["MotherName"];
            husband.HomeAddress = Request.Form["HomeAddress"];

            husband.Region = Request.Form["Region"];
            husband.club = Request.Form["club"];
            husband.HomeAddress = Request.Form["HomeAddress"];
            husband.Catholic = Request.Form["Catholic"];
            husband.Children = Request.Form["Children"];
            husband.DateMr = Request.Form["DateMr"];
            husband.Terrioty = Request.Form["Terrioty"];
            husband.Cathedral = Request.Form["Cathedral"];
            husband.Priest = Request.Form["Priest"];
            husband.BM1 = Request.Form["BM1"];
            husband.BM2 = Request.Form["BM2"];
            


            //save to data base
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Husband" +
                                  "(BookId,Fullname,HolyName,FatherName,MotherName,HomeAddress,Hospital,gender,Culture,Baptism,Cetechism,Communion,Confirmation) VALUES " +
                                  "(@BookId,@Fullname,@HolyName,@FatherName,@MotherName,@HomeAddress,@Hospital,@gender,@Culture,@Baptism,@Cetechism,@Communion,@Confirmation);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", husband.BookID);
                        command.Parameters.AddWithValue("@Fullname", husband.Fullname);
                        command.Parameters.AddWithValue("@HolyName", husband.HolyName);
                        command.Parameters.AddWithValue("@FatherName", husband.FatherName);
                        command.Parameters.AddWithValue("@MotherName", husband.MotherName);
                        command.Parameters.AddWithValue("@HomeAddress", husband.HomeAddress);
                        command.Parameters.AddWithValue("@Catholic", husband.Catholic);
                        command.Parameters.AddWithValue("@Children", husband.Children);
                        command.Parameters.AddWithValue("@DateMr", husband.DateMr);
                        command.Parameters.AddWithValue("@Terrioty", husband.Terrioty);
                        command.Parameters.AddWithValue("@Cathedral", husband.Cathedral);
                        command.Parameters.AddWithValue("@Priest", husband.Priest);
                        command.Parameters.AddWithValue("@Region", husband.Region);
                        command.Parameters.AddWithValue("@club", husband.club);
                        command.Parameters.AddWithValue("@BM1", husband.BM1);
                        command.Parameters.AddWithValue("@BM2", husband.BM2);
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
