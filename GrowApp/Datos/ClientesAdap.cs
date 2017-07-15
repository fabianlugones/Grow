using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Npgsql;
using NpgsqlTypes;
namespace Datos
{
   public class ClientesAdap : Adaptador
    {
        public List<Clientes> GetAll()
        {
            try
            {
                List<Clientes> provList = new List<Clientes>();
                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from clientes where estado = 'alta' order by nombre_apellido", npgsqlConn);
                NpgsqlDataReader drClientes = cmdSel.ExecuteReader();

                while (drClientes.Read())
                {
                    Clientes prov = new Clientes();
                    prov.Razon_social = (string)drClientes["nombre_apellido"];
                    prov.Telefono1 = (string)drClientes["telefono_1"];
                    prov.Telefono2 = (string)drClientes["telefono_2"];
                    prov.Email = (string)drClientes["email"];
                    prov.Direccion = (string)drClientes["direccion"];
            
                    prov.DNI = (string)drClientes["dni"];
                    provList.Add(prov);

                }
                return provList;


            }
            finally { CloseConnection(); }




        }
        public Clientes GetOne(string dni)
        {
            try
            {
                Clientes cli = new Clientes();
                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from clientes where estado = 'alta' and dni = @dni", npgsqlConn);
                cmdSel.Parameters.Add("@dni", NpgsqlTypes.NpgsqlDbType.Text).Value = dni;
                NpgsqlDataReader drClientes = cmdSel.ExecuteReader();

                while (drClientes.Read())
                {
                   
                    cli.Razon_social = (string)drClientes["nombre_apellido"];
                    cli.Telefono1 = (string)drClientes["telefono_1"];
                    cli.Telefono2 = (string)drClientes["telefono_2"];
                    cli.Email = (string)drClientes["email"];
                    cli.Direccion = (string)drClientes["direccion"];
                    cli.Id = (int)drClientes["id"];
                    cli.DNI = (string)drClientes["dni"];
                  

                }
                return cli;


            }
            finally { CloseConnection(); }




        }

        public void DarDeBaja(string dni)
        {
            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("update Clientes set estado = 'baja' where dni = @dni and estado = 'alta'", npgsqlConn);
                cmdSel.Parameters.Add("@dni", NpgsqlTypes.NpgsqlDbType.Text).Value = dni;
                cmdSel.ExecuteNonQuery();
            }
            finally { CloseConnection(); }

        }


        public string GetEmail(string dni)
        {
            try
            {
                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select email from Clientes where estado = 'alta' and dni  = @dni", npgsqlConn);
                cmdSel.Parameters.Add("@dni", NpgsqlTypes.NpgsqlDbType.Text).Value = dni;
                return ((string)cmdSel.ExecuteScalar());
            }
            finally { CloseConnection(); }

        }

        public int ExisteClientes(string dni)
        {
            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select COUNT(*) from Clientes where dni = @dni and estado = 'alta'", npgsqlConn);
                cmdSel.Parameters.Add("@dni", NpgsqlTypes.NpgsqlDbType.Text).Value = dni;
                int count = Convert.ToInt32((long)cmdSel.ExecuteScalar());
                return count;

            }
            finally { CloseConnection(); }
        }

        public void Insert(Clientes prov)
        {
            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("Insert into Clientes (nombre_apellido, telefono_1,telefono_2,direccion,email,dni,estado)" +
                    " values(@razon,@tel1,@tel2,@direccion,@email,@dni,'alta')", npgsqlConn);
                cmdSel.Parameters.Add("@razon", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Razon_social;
                cmdSel.Parameters.Add("@tel1", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Telefono1;
                cmdSel.Parameters.Add("@tel2", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Telefono2;
                cmdSel.Parameters.Add("@direccion", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Direccion;
               
                cmdSel.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Email;
                cmdSel.Parameters.Add("@dni", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.DNI;
                cmdSel.ExecuteNonQuery();



            }
            finally { CloseConnection(); }

        }

        public void Update(Clientes prov)
        {
            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("UPDATE Clientes set nombre_apellido = @razon, telefono_1 = @tel1,telefono_2 = @tel2,direccion=@direccion,email=@email " +
                "  where dni = @dni and estado = 'alta'", npgsqlConn);
                cmdSel.Parameters.Add("@razon", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Razon_social;
                cmdSel.Parameters.Add("@tel1", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Telefono1;
                cmdSel.Parameters.Add("@tel2", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Telefono2;
                cmdSel.Parameters.Add("@direccion", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Direccion;
              
                cmdSel.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.Email;
                cmdSel.Parameters.Add("@dni", NpgsqlTypes.NpgsqlDbType.Text).Value = prov.DNI;
                cmdSel.ExecuteNonQuery();

            }
            finally { CloseConnection(); }

        }

       


    }
}
