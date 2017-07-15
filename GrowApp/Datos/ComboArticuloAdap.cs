using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using Npgsql;
using NpgsqlTypes;
namespace Datos
{
    public class ComboArticuloAdap : Adaptador
    {
        public int ValidoNombreCombro(string nombre)
        { try{
            OpenConnection();
            int count=0;
            NpgsqlCommand cmdSel = new NpgsqlCommand("select COUNT(*) from caja_herramienta where nombre=@nombre", npgsqlConn);
            cmdSel.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;
            count = Convert.ToInt32((long)cmdSel.ExecuteScalar());

            return count;

        }
        finally { CloseConnection(); }


        }
        public List<ComboArticulos> GetAll()
        {
            try
            {
                List<ComboArticulos> listCombo = new List<ComboArticulos>();
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select* from caja_herramienta", npgsqlConn);

                NpgsqlDataReader drCombos= cmdSel.ExecuteReader();
                while (drCombos.Read())
                {
                    ComboArticulos comb = new ComboArticulos();
                    comb.ID = (int)drCombos["id_caja"];
                    comb.Nombre = (string)drCombos["nombre"];
                    listCombo.Add(comb);
                }

                return listCombo;
                  }
            finally { CloseConnection(); }


        }
        public List<ComboArticulos_Articulos> GetArticulos(int id_caja)
        {
            try
            {
                List<ComboArticulos_Articulos> listCombo = new List<ComboArticulos_Articulos>();
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select c.id_herramienta,c.cantidad, h.nombre, h.stock from caja_herramienta_herramientas c "+
                    "inner join articulos h on h.id = c.id_herramienta" +
                    " where id_caja = @id", npgsqlConn);
                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                NpgsqlDataReader drCombos = cmdSel.ExecuteReader();
                while (drCombos.Read())
                {
                    ComboArticulos_Articulos comb = new ComboArticulos_Articulos();
                    comb.Id_articulo = (string)drCombos["id_herramienta"];
                    comb.Nombre_articulo = (string)drCombos["nombre"];
                    comb.Cantidad_articulo = (int)drCombos["cantidad"];
                    comb.Stock = (int)drCombos["stock"];
                    listCombo.Add(comb);
                }

                return listCombo;
            }
            finally { CloseConnection(); }


        }
        public List<ComboArticulos_ArticulosPromo> GetArticulosPromocionados(int id_caja)
        {
            try
            {
                List<ComboArticulos_ArticulosPromo> listCombo = new List<ComboArticulos_ArticulosPromo>();
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select c.id_producto,c.cant_producto_promocional,h.nombre,h.stock from caja_herramientas_promocion c " +
                    "inner join articulos h on h.id = c.id_producto" +
                    " where id_caja = @id", npgsqlConn);
                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                NpgsqlDataReader drCombos = cmdSel.ExecuteReader();
                while (drCombos.Read())
                {
                    ComboArticulos_ArticulosPromo comb = new ComboArticulos_ArticulosPromo();
                    comb.Id_articulo = (string)drCombos["id_producto"];
                    comb.Nombre_articulo = (string)drCombos["nombre"];
                    comb.Cantidad_articulo = (int)drCombos["cant_producto_promocional"];
                    comb.Stock = (int)drCombos["stock"];
                    listCombo.Add(comb);
                }

                return listCombo;
            }
            finally { CloseConnection(); }


        }
       
            public List<ComboArticulos_Articulos> GetArticulosCombos()
        {
            try
            {
                List<ComboArticulos_Articulos> listCombo = new List<ComboArticulos_Articulos>();
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select c.id_caja,c.cantidad,c.id_herramienta "+
                    "from caja_herramienta_herramientas c " +
                    "inner join caja_herramienta h on h.id_caja = c.id_caja" +
                    " where h.activa = true order by h.id_caja ", npgsqlConn);

                NpgsqlDataReader drCombos = cmdSel.ExecuteReader();
                while (drCombos.Read())
                {
                    ComboArticulos_Articulos comb = new ComboArticulos_Articulos();
                   comb.Id_combo = (int)drCombos["id_caja"];
                    comb.Cantidad_articulo = (int)drCombos["cantidad"];
                    comb.Id_articulo = (string)drCombos["id_herramienta"];
                   
                    listCombo.Add(comb);
                }

                return listCombo;
            }
            finally { CloseConnection(); }


        }
        public List<ComboArticulos_ArticulosPromo> GetArticulosPromoCombos()
        {
            try
            {
                List<ComboArticulos_ArticulosPromo> listCombo = new List<ComboArticulos_ArticulosPromo>();
                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select c.id_caja,c.cant_producto_promocional,c.id_producto " +
                    "from caja_herramientas_promocion c " +
                    "inner join caja_herramienta h on h.id_caja = c.id_caja" +
                    " where h.activa = true order by h.id_caja ", npgsqlConn);

                NpgsqlDataReader drCombos = cmdSel.ExecuteReader();
                while (drCombos.Read())
                {
                    ComboArticulos_ArticulosPromo comb = new ComboArticulos_ArticulosPromo();
                    comb.Id_combo = (int)drCombos["id_caja"];
                    comb.Cantidad_articulo = (int)drCombos["cant_producto_promocional"];
                    comb.Id_articulo = (string)drCombos["id_producto"];

                    listCombo.Add(comb);
                }

                return listCombo;
            }
            finally { CloseConnection(); }


        }
        public Actividades GetPromocionInforme(int id_caja)
        {
             string producto_cantidad="a";
            string lleva_gratis="a";
            try
            {
                List<ComboArticulos_Articulos> listCombo = new List<ComboArticulos_Articulos>();
              
                OpenConnection();


                NpgsqlCommand cmdSel = new NpgsqlCommand("select ch.nombre as nombre_combo, c.id_herramienta,h.unidad,c.cantidad, h.nombre " +
                "from caja_herramienta_herramientas c " +
                    "inner join caja_herramienta ch on ch.id_caja = c.id_caja " +
                    "inner join articulos h on h.id = c.id_herramienta" +
                    " where c.id_caja = @id", npgsqlConn);

                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;

                NpgsqlDataReader drCombos = cmdSel.ExecuteReader();

                Actividades act = new Actividades();

                producto_cantidad = "";
                while (drCombos.Read())
                {
                    act.Actividad = "¡¡¡¡ "+(string)drCombos["nombre_combo"] + ":" ;
                    producto_cantidad = producto_cantidad + " "+ Convert.ToString((int)drCombos["cantidad"])+" "+(string)drCombos["unidad"] + " " + (string)drCombos["nombre"] + " +";
                   
                    
                }
                drCombos.Close();
                producto_cantidad = producto_cantidad.Remove(producto_cantidad.Length - 1) ;
                act.Actividad = act.Actividad + producto_cantidad + " . LLEVA GRATIS: ";

                
                NpgsqlCommand cmdSel1 = new NpgsqlCommand("select c.cant_producto_promocional, h.nombre,h.unidad "+
                "from caja_herramientas_promocion c " +
                    "inner join articulos h on h.id = c.id_producto" +
                    " where c.id_caja = @id", npgsqlConn);

                cmdSel1.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;

                NpgsqlDataReader drCombos1 = cmdSel1.ExecuteReader();

                lleva_gratis = "";
                while (drCombos1.Read())
                {
                    lleva_gratis =  lleva_gratis + Convert.ToString((int)drCombos1["cant_producto_promocional"])+" " +  (string)drCombos1["unidad"]+" " + (string)drCombos1["nombre"] + " +";
                }
                drCombos1.Close();
              
                lleva_gratis = lleva_gratis.Remove(lleva_gratis.Length - 1);
           
                act.Actividad = act.Actividad + lleva_gratis + "!!!!!";

                return act;
                
            }
            finally { CloseConnection(); }


        }
        public int Insertar(string nombre)
        {

            try
            {
                int id_caja;
                this.OpenConnection();

                NpgsqlCommand cmdSave = new NpgsqlCommand("insert into caja_herramienta(nombre,activa) " +
                    "values(@nombre,true) RETURNING id_caja", npgsqlConn);
                cmdSave.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;
                id_caja=(int)cmdSave.ExecuteScalar();
                return id_caja;
            }
            finally { CloseConnection(); }

        }
        public int GetId(string nombre)
        {
             int id_caja;
            try
            {
           
                this.OpenConnection();

                NpgsqlCommand cmdSave = new NpgsqlCommand("select id_caja from caja_herramienta " +
                    "where nombre = @nombre", npgsqlConn);

                cmdSave.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;

                id_caja = (int)cmdSave.ExecuteScalar();
                return id_caja;
            }
            catch { return 0; }
            finally { CloseConnection(); }
        
        
        }
        public void InsertarArticulosACombo(ComboArticulos_Articulos ca_a)
        {
            try
            {
             
                this.OpenConnection();

                NpgsqlCommand cmdSave = new NpgsqlCommand("insert into caja_herramienta_herramientas(id_caja,id_herramienta,cantidad) " +
                    "values(@id_caja,@id_herramienta,@cantidad)", npgsqlConn);
                cmdSave.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = ca_a.Id_combo;
                cmdSave.Parameters.Add("@id_herramienta", NpgsqlTypes.NpgsqlDbType.Text).Value = ca_a.Id_articulo;
                cmdSave.Parameters.Add("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = ca_a.Cantidad_articulo;
                cmdSave.ExecuteNonQuery();
                
            }
            finally { CloseConnection(); }
        
        
        }
        public void InsertarArticulosAPromo(ComboArticulos_Articulos ca_a)
        {
            try
            {

                this.OpenConnection();

                NpgsqlCommand cmdSave = new NpgsqlCommand("insert into caja_herramientas_promocion(id_caja,id_producto,cant_producto_promocional) " +
                    "values(@id_caja,@id_herramienta,@cantidad)", npgsqlConn);
                cmdSave.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = ca_a.Id_combo;
                cmdSave.Parameters.Add("@id_herramienta", NpgsqlTypes.NpgsqlDbType.Text).Value = ca_a.Id_articulo;
                cmdSave.Parameters.Add("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = ca_a.Cantidad_articulo;
                cmdSave.ExecuteNonQuery();

            }
            finally { CloseConnection(); }


        }
        public void EliminarArticulos(int id_caja)
        {
            try
            {

                this.OpenConnection();

                NpgsqlCommand cmdSave = new NpgsqlCommand("DELETE FROM caja_herramienta_herramientas WHERE id_caja = @id_caja", npgsqlConn);
                cmdSave.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                cmdSave.ExecuteNonQuery();
                NpgsqlCommand cmdSave1 = new NpgsqlCommand("DELETE FROM caja_herramientas_promocion WHERE id_caja = @id_caja", npgsqlConn);
                cmdSave1.Parameters.Add("@id_caja", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_caja;
                cmdSave1.ExecuteNonQuery();

            }
            finally { CloseConnection(); }


        }
        public void DeletePromo(int id_promo)
        {
            try
            {
                OpenConnection();
                NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE FROM caja_herramienta where id_caja = @id", npgsqlConn);
                cmdDel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_promo;
                cmdDel.ExecuteNonQuery();
                NpgsqlCommand cmdDel1 = new NpgsqlCommand("DELETE FROM caja_herramientas_promocion where id_caja = @id", npgsqlConn);
                cmdDel1.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_promo;
                cmdDel1.ExecuteNonQuery();
            }
            finally { CloseConnection(); }
        
        
        }

    }
}
