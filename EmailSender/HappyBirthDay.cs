using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public class HappyBirthDay
{
    public static void sendEmail()
    {
        var path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", "") + "/Template/Index.html";
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(path))
        {
            body = reader.ReadToEnd();
        }

        SqlConnection conn = new SqlConnection("Data Source=.;Database=Person;Integrated Security=True");
        conn.Open();
        SqlCommand cmd = new SqlCommand(" SELECT *, [BirthDate] FROM[Person].[dbo].[Users] WHERE DAY([BirthDate]) = DAY(GETDATE())   AND MONTH([BirthDate]) = MONTH(GETDATE())", conn);

        SqlDataReader sqlReader = cmd.ExecuteReader();
        while (sqlReader.Read())
        {
            string email = sqlReader.GetString(5);
            string name = sqlReader.GetString(1);
            using (MailMessage mail = new MailMessage())
            {

                body = body.Replace("{FirstName}", name);
                mail.From = new MailAddress("email.sender.123455@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Happy Birthday";
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("email.sender.123455@gmail.com", "sfce omrm oyua sdbl");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}