using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Mail;

namespace Clases
{
    public class Email
    {
        /*
        * Cliente SMTP
        * Gmail:  smtp.gmail.com  puerto:587
        * Hotmail: smtp.liva.com  puerto:25
         * Sinergia: mail.sinergiaservicios.com.ar   puerto:26
        *"smtp.mail.yahoo.com", 587
         */
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);

        public Email(string email, string pass)
        {
            /*
             * Autenticacion en el Servidor
             * Utilizaremos nuestra cuenta de correo
             *
             * Direccion de Correo (Gmail o Hotmail)
             * y Contrasena correspondiente
             */
            server.Credentials = new System.Net.NetworkCredential(email, pass);
            server.EnableSsl = true;
            
        }

        public void MandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }
    }
}
