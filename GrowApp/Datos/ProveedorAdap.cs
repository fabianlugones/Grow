using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpgsqlTypes;
using Npgsql;
using Clases;

namespace Datos
{
   public  class ProveedorAdap:Adaptador
    {
       public List<Proveedor> GetAll()
       {
           try
           {
               List<Proveedor> provList = new List<Proveedor>();
               this.OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from proveedores where estado = 'alta' order by razon_social", npgsqlConn);
               NpgsqlDataReader drProveedor = cmdSel.ExecuteReader();

               while (drProveedor.Read())
               {
                   Proveedor prov = new Proveedor();
                   prov.Razon_social = (string)drProveedor["razon_social"];
                   prov.Telefono1 = (string)drProveedor["telefono_1"];
                   prov.Telefono2 = (string)drProveedor["telefono_2"];
                   prov.Email = (string)drProveedor["email"];
                   prov.Direccion = (string)drProveedor["direccion"];
                   prov.Nombre_contacto = (string)drProveedor["nombre_contacto"];
                   prov.Categoria = (string)drProveedor["categoria"];
                   prov.Id = (int)drProveedor["id"];
                   provList.Add(prov);

               }
               return provList;
           
           
           }
           finally { CloseConnection(); }


            
       
       }

       public void DarDeBaja(string razon)
       {
           try
           {

               this.OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("update proveedores set estado = 'baja' where razon_social = @razon and estado = 'alta'", npgsqlConn);
               cmdSel.Parameters.Add("@razon", NpgsqlTypes.NpgsqlDbType.Text).Value = razon;
               cmdSel.ExecuteNonQuery();
           }
           finally { CloseConnection(); }
       
       }

       public string GetEmail(string razon)
       {
           try
           {
               this.OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("select email from proveedores where estado = 'alta' and razon_social  = @razon", npgsqlConn);
               cmdSel.Parameters.Add("@razon", NpgsqlTypes.NpgsqlDbType.Text).Value = razon;
               return ((string)cmdSel.ExecuteScalar());
           }
           finally { CloseConnection(); }

       }

       public int ExisteProveedor(string razon)
       {
           try
           {
            
               this.OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand(" select COUNT(*) from proveedores where razon_social = @razon and estado = 'alta'", npgsqlConn);
               cmdSel.Parameters.Add("@razon",NpgsqlTypes.NpgsqlDbType.Text).Value = razon;
               int count = Convert.ToInt32((long)cmdSel.ExecuteScalar());
               return count;
       
           }
           finally { CloseConnection(); }
       }

       public void Insert(Proveedor prov)
       {
           try
           {

               this.OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("Insert into proveedores (razon_social, telefono_1,telefono_2,direccion,email,nombre_contacto,categoria,estado)" +
                   " values(@razon,@tel1,@tel2,@direccion,@email,@nombre_contacto,@categoria,'alta')", npgsqlConn);
               cmdSel.Parameters.Add("@razon", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Razon_social;
               cmdSel.Parameters.Add("@tel1", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Telefono1;
               cmdSel.Parameters.Add("@tel2", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Telefono2;
               cmdSel.Parameters.Add("@direccion", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Direccion;
               cmdSel.Parameters.Add("@nombre_contacto", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Nombre_contacto;
               cmdSel.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Email;
               cmdSel.Parameters.Add("@categoria", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Categoria;
               cmdSel.ExecuteNonQuery();



           }
           finally { CloseConnection(); }

       }

       public void Update(Proveedor prov)
       {
           try
           {

               this.OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("UPDATE proveedores set telefono_1 = @tel1,telefono_2 = @tel2,direccion=@direccion,email=@email "+
               " ,nombre_contacto = @nombre_contacto,categoria=@categoria where razon_social = @razon and estado = 'alta'", npgsqlConn);
               cmdSel.Parameters.Add("@razon", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Razon_social;
               cmdSel.Parameters.Add("@tel1", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Telefono1;
               cmdSel.Parameters.Add("@tel2", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Telefono2;
               cmdSel.Parameters.Add("@direccion", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Direccion;
               cmdSel.Parameters.Add("@nombre_contacto", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Nombre_contacto;
               cmdSel.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Email;
               cmdSel.Parameters.Add("@categoria", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Categoria;
               cmdSel.ExecuteNonQuery();

           }
           finally { CloseConnection(); }

       }

       public string GetDireccion(string razon)
       {
           try
           {

               this.OpenConnection();
               NpgsqlCommand cmdSel = new NpgsqlCommand("select direccion from proveedores where razon_social = @razon and estado = 'alta'", npgsqlConn);
               cmdSel.Parameters.Add("@razon", NpgsqlTypes.NpgsqlDbType.Text).Value = razon;
               return (string)cmdSel.ExecuteScalar();

           }
              

           finally { CloseConnection(); }
       
       
       
       }
    }
}
