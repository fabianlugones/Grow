using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
namespace Datos
{
    public class FuncionesAdapcs : Adaptador
    {

        public void Reinicio()
        {

            try
            {
                this.OpenConnection();

               
                NpgsqlCommand cmdSave222 = new NpgsqlCommand("DELETE FROM articulos_costos", npgsqlConn);
                cmdSave222.ExecuteNonQuery();
               

                NpgsqlCommand cmdSave34 = new NpgsqlCommand("DELETE FROM ventas", npgsqlConn);
                cmdSave34.ExecuteNonQuery();
                NpgsqlCommand cmdSave35 = new NpgsqlCommand("DELETE FROM pago_venta", npgsqlConn);
                cmdSave35.ExecuteNonQuery();

                NpgsqlCommand cmdSave36 = new NpgsqlCommand("DELETE FROM venta_productos", npgsqlConn);
                cmdSave36.ExecuteNonQuery();

                

                NpgsqlCommand cmdSave3 = new NpgsqlCommand("DELETE FROM orden_compra_articulos", npgsqlConn);
                cmdSave3.ExecuteNonQuery();

                NpgsqlCommand cmdSave4 = new NpgsqlCommand("DELETE FROM orden_de_compra", npgsqlConn);
                cmdSave4.ExecuteNonQuery();

                NpgsqlCommand cmdSave5 = new NpgsqlCommand("DELETE FROM pedido_cotizacion", npgsqlConn);
                cmdSave5.ExecuteNonQuery();

                NpgsqlCommand cmdSave6 = new NpgsqlCommand("DELETE FROM pedido_cotizacion_articulos", npgsqlConn);
                cmdSave6.ExecuteNonQuery();

            

                NpgsqlCommand cmdSave9 = new NpgsqlCommand("DELETE FROM perdida_stock", npgsqlConn);
                cmdSave9.ExecuteNonQuery();


                NpgsqlCommand cmdSave112 = new NpgsqlCommand("DELETE FROM movimientos_de_banco", npgsqlConn);
                cmdSave112.ExecuteNonQuery();          

                NpgsqlCommand cmdSave11 = new NpgsqlCommand("DELETE FROM suma_stock", npgsqlConn);
                cmdSave11.ExecuteNonQuery();
                NpgsqlCommand cmdSave13 = new NpgsqlCommand("DELETE FROM pago_orden_compra", npgsqlConn);
                cmdSave13.ExecuteNonQuery();

                NpgsqlCommand cmdSave55 = new NpgsqlCommand("DELETE FROM registradora where id_registradora <> 0", npgsqlConn);
                cmdSave55.ExecuteNonQuery();
                NpgsqlCommand cmdSave54 = new NpgsqlCommand("DELETE FROM retiro_deposito", npgsqlConn);
                cmdSave54.ExecuteNonQuery();
            }
            finally { CloseConnection(); }


        }

    }
}
