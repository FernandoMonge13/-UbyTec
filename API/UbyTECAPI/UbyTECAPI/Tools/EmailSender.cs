using System;
using System.Net;
using System.Net.Mail;
using UbyTECAPI.Connection;
namespace UbyTECAPI.Tools
{
    /// <summary>
    /// Clase encargada del manejo del envío de correos
    /// </summary>
    public class EmailSender
    {
        /// <summary>
        /// Función que emvía un correo a un destinatario específico
        /// </summary>
        /// <param name="email">Dirección de correo a la cual se desea realizar el envío</param>
        /// <param name="usuario">Nombre del usuario al que se le envía el correo</param>
        /// <param name="pass">Contraseña que se envía al usuario</param>
        /// <param name="tipo">Tipo de usuario</param>
        /// <returns></returns>
        public static bool sendEmail(string email, string usuario, string pass, string tipo)
        {
            try
            {
                MailMessage mmsg = new MailMessage();
                mmsg.To.Add(email);
                mmsg.Subject = $"Contraseña UbyTEC para {tipo}";
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

                mmsg.Body = $"<h1>Hola, {usuario} </h1>" +
                    $"<h2>Su contraseña para {tipo} es {pass}</h2>";
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.From = new MailAddress(Connection.Connection.email);

                SmtpClient client = new SmtpClient();

                client.Credentials = new NetworkCredential(Connection.Connection.email, Connection.Connection.emailPass);

                client.Port = 587;
                client.EnableSsl = true;

                client.Host = "smtp.gmail.com";
                client.Send(mmsg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
