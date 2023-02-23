using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static FinalHDT.Pages.Manager.Parisment.ChildrenModel;
using System.Data.SqlClient;
using static FinalHDT.Pages.Manager.Parisment.WifeModel;

namespace FinalHDT.Pages.Users.Information
{
    public class WifeIPModel : PageModel
    {
        public wifeinfo Wifeinfo = new wifeinfo();
        public void OnGet()
        {

            Wifeinfo.BookID = Request.Form["BookId"];
            Wifeinfo.Fullname = Request.Form["Fullname"];
            Wifeinfo.HolyName = Request.Form["HolyName"];
            Wifeinfo.FatherName = Request.Form["FatherName"];
            Wifeinfo.MotherName = Request.Form["MotherName"];
            Wifeinfo.HomeAddress = Request.Form["HomeAddress"];

            Wifeinfo.Region = Request.Form["Region"];
            Wifeinfo.club = Request.Form["club"];
            Wifeinfo.HomeAddress = Request.Form["HomeAddress"];
            Wifeinfo.Catholic = Request.Form["Catholic"];
            Wifeinfo.Children = Request.Form["Children"];
            Wifeinfo.DateMr = Request.Form["DateMr"];
            Wifeinfo.Terrioty = Request.Form["Terrioty"];
            Wifeinfo.Cathedral = Request.Form["Cathedral"];
            Wifeinfo.Priest = Request.Form["Priest"];
            Wifeinfo.BM1 = Request.Form["BM1"];
            Wifeinfo.BM2 = Request.Form["BM2"];

        }
        public void OnPost()
        {
            Wifeinfo.BookID = Request.Form["BookId"];
            Wifeinfo.Fullname = Request.Form["Fullname"];
            Wifeinfo.HolyName = Request.Form["HolyName"];
            Wifeinfo.FatherName = Request.Form["FatherName"];
            Wifeinfo.MotherName = Request.Form["MotherName"];
            Wifeinfo.HomeAddress = Request.Form["HomeAddress"];
            Wifeinfo.Region = Request.Form["Region"];
            Wifeinfo.club = Request.Form["club"];
            Wifeinfo.HomeAddress = Request.Form["HomeAddress"];
            Wifeinfo.Catholic = Request.Form["Catholic"];
            Wifeinfo.Children = Request.Form["Children"];
            Wifeinfo.DateMr = Request.Form["DateMr"];
            Wifeinfo.Terrioty = Request.Form["Terrioty"];
            Wifeinfo.Cathedral = Request.Form["Cathedral"];
            Wifeinfo.Priest = Request.Form["Priest"];
            Wifeinfo.BM1 = Request.Form["BM1"];
            Wifeinfo.BM2 = Request.Form["BM2"];

            //save to data base
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=web;Integrated Security=True;Pooling=False ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Wife" +
                                  "(BookId,Fullname,HolyName,FatherName,MotherName,HomeAddress,Hospital,gender,Culture,Baptism,Cetechism,Communion,Confirmation) VALUES " +
                                  "(@BookId,@Fullname,@HolyName,@FatherName,@MotherName,@HomeAddress,@Hospital,@gender,@Culture,@Baptism,@Cetechism,@Communion,@Confirmation);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", Wifeinfo.BookID);
                        command.Parameters.AddWithValue("@Fullname", Wifeinfo.Fullname);
                        command.Parameters.AddWithValue("@HolyName", Wifeinfo.HolyName);
                        command.Parameters.AddWithValue("@FatherName", Wifeinfo.FatherName);
                        command.Parameters.AddWithValue("@MotherName", Wifeinfo.MotherName);
                        command.Parameters.AddWithValue("@HomeAddress", Wifeinfo.HomeAddress);
                        command.Parameters.AddWithValue("@Catholic", Wifeinfo.Catholic);
                        command.Parameters.AddWithValue("@Children", Wifeinfo.Children);
                        command.Parameters.AddWithValue("@DateMr", Wifeinfo.DateMr);
                        command.Parameters.AddWithValue("@Terrioty", Wifeinfo.Terrioty);
                        command.Parameters.AddWithValue("@Cathedral", Wifeinfo.Cathedral);
                        command.Parameters.AddWithValue("@Priest", Wifeinfo.Priest);
                        command.Parameters.AddWithValue("@Region", Wifeinfo.Region);
                        command.Parameters.AddWithValue("@club", Wifeinfo.club);
                        command.Parameters.AddWithValue("@BM1", Wifeinfo.BM1);
                        command.Parameters.AddWithValue("@BM2", Wifeinfo.BM2);
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
