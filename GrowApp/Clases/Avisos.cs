using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
   public class Avisos
    {
       private string _aviso;
       private int _hora_activa;
       private DateTime _fecha_activa;
       private int _id_aviso;
       private string _emisor;
       private int _id_usuario_emisor;

       public string Emisor
       {
           get { return _emisor; }
           set { _emisor = value; }
       }
       public string Aviso
       {
           get { return _aviso; }
           set { _aviso = value; }
       
       }
       public int Hora_activa
       {
           get { return _hora_activa; }
           set { _hora_activa = value; }
       
       }
       public DateTime Fecha_activa
       {
           get { return _fecha_activa; }
           set { _fecha_activa = value; }

       }
       public int Id_aviso
       {
           get { return _id_aviso; }
           set { _id_aviso = value; }

       }
       public int Id_usuario_emisor
       {
           get { return _id_usuario_emisor; }
           set { _id_usuario_emisor = value; }
       }

    }
   public class Avisos_usuarios : Avisos
   {
       
       private int _id_usuario;
       private bool _aviso_activo;
       public int Id_usuario
       {
           get { return _id_usuario; }
           set { _id_usuario = value; }

       }            
       public bool Aviso_activo
       {
           get { return _aviso_activo; }
           set { _aviso_activo = value; }

       }
   
   
   }
}
