using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;

namespace Datos
{
   public class Adaptador
    {
        private NpgsqlConnection _npgsqlConn;
        public NpgsqlConnection npgsqlConn
        {
            get
            {
                return _npgsqlConn;
            }
            set
            {
                _npgsqlConn = value;
            }
        }

        public void OpenConnection()
        {
            try
            {
                npgsqlConn = new NpgsqlConnection();
                if (npgsqlConn.State == System.Data.ConnectionState.Closed)
                {
                    npgsqlConn.ConnectionString = "Server=localhost;Port=5433;Database=Grow ;User Id=postgres;Password=admin123;";

                    npgsqlConn.Open();
                }
            }
            catch { }
            //}


        }
        public void CloseConnection()
        {
            try
            {
                if (npgsqlConn.State == System.Data.ConnectionState.Open)
                {
                    npgsqlConn.Close();
                    npgsqlConn = null;
                }
            }
            catch { }

        }

        public void OpenConnectionUsuarios()
        {
            try
            {
                npgsqlConn = new NpgsqlConnection();
                 if (npgsqlConn.State == System.Data.ConnectionState.Closed)
                 {
                npgsqlConn.ConnectionString = "Server=localhost;Port=5433;Database=Grow_usuarios ;User Id=postgres;Password=admin123;";

                npgsqlConn.Open();}
            }
            catch { }
            }


    
        public void CloseConnectionUsuarios()
        {
            try
            {
                if (npgsqlConn.State == System.Data.ConnectionState.Open)
                {
                    npgsqlConn.Close();
                    npgsqlConn = null;
                }
            }
            catch { }

        }

    }
}
