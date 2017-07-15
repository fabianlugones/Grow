using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases;
using NpgsqlTypes;
using Npgsql;

namespace Datos
{
  public  class ArticuloAdap : Adaptador
    {   public void Insertar(Articulos art)
        {

            try
            {
                this.OpenConnection();

                NpgsqlCommand cmdSave = new NpgsqlCommand("insert into articulos(id,comentarios,nombre,categoria,stock,unidad,porcentaje_ganancia,stock_minimo,categoria_2,proveedor_habitual) " +
                    "values(@id,@comentarios,@nombre,@categoria,@stock,@unidad,@porcentaje_ganancia,@stock_min,@categoria_2,@proveedor_habitual)", npgsqlConn);


                cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = art.ID;
                cmdSave.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Nombre;
                cmdSave.Parameters.Add("@comentarios", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Comentarios;
                cmdSave.Parameters.Add("@categoria", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Categoria;
                cmdSave.Parameters.Add("@stock", NpgsqlTypes.NpgsqlDbType.Integer).Value = art.Stock;
                cmdSave.Parameters.Add("@unidad", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Unidad;
                cmdSave.Parameters.Add("@stock_min", NpgsqlTypes.NpgsqlDbType.Integer).Value = art.Stock_min;
                cmdSave.Parameters.Add("@porcentaje_ganancia", NpgsqlTypes.NpgsqlDbType.Double).Value = art.Porcentaje_ganancia;
                cmdSave.Parameters.Add("@categoria_2", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Categoria_2;
                cmdSave.Parameters.Add("@proveedor_habitual", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Proveedor_habitual;

                cmdSave.ExecuteNonQuery();

               
                
            }
            
            finally { CloseConnection(); }


        }
        public List<Articulos> GetAll()
        {

            try
            {
                List<Articulos> artList = new List<Articulos>();
                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from articulos order by nombre", npgsqlConn);
                NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();

                while (drHerramientas.Read())
                { 
                    Articulos art = new Articulos();
                    art.Proveedor_habitual = (string)drHerramientas["proveedor_habitual"];
                    art.Categoria_2 = (string)drHerramientas["categoria_2"];
                    art.Categoria = (string)drHerramientas["categoria"];
                    art.Nombre = (string)drHerramientas["nombre"];
                    art.ID = (string)drHerramientas["id"];
                    try { art.Comentarios = (string)drHerramientas["comentarios"]; }
                    catch { }
                    art.Stock = (int)drHerramientas["stock"];
                    art.Unidad = (string)drHerramientas["unidad"]; 
                    try
                    { art.Precio = (double)drHerramientas["precio"];
                    }
                    catch { }
                    art.Porcentaje_ganancia = (double)drHerramientas["porcentaje_ganancia"];
                    art.Stock_min = (int)drHerramientas["stock_minimo"];
                    artList.Add(art);
                
                }
                return artList;
            
            }
            finally { CloseConnection(); }
        
        }
        public List<Articulos> GetFiltro(string filtro)
        {

            try
            {
                List<Articulos> artList = new List<Articulos>();
                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("Select * from articulos where nombre LIKE '%' ||  @filtro || '%'  ORDER BY nombre ", npgsqlConn);
                  cmdSel.Parameters.Add("@filtro", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = filtro;
                 NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();

                while (drHerramientas.Read())
                {
                    Articulos art = new Articulos();
                    art.Proveedor_habitual = (string)drHerramientas["proveedor_habitual"];
                    art.Categoria_2 = (string)drHerramientas["categoria_2"];
                    art.Categoria = (string)drHerramientas["categoria"];
                    art.Nombre = (string)drHerramientas["nombre"];
                    art.ID = (string)drHerramientas["id"];
                    try { art.Comentarios = (string)drHerramientas["comentarios"]; }
                    catch { }
                    art.Stock = (int)drHerramientas["stock"];
                    art.Unidad = (string)drHerramientas["unidad"];
                    art.Precio = (double)drHerramientas["precio"];
                    art.Porcentaje_ganancia = (double)drHerramientas["porcentaje_ganancia"];
                    art.Stock_min = (int)drHerramientas["stock_minimo"];
                    artList.Add(art);

                }
                drHerramientas.Close();

                NpgsqlCommand cmdSel2 = new NpgsqlCommand("Select * from articulos hh where CAST(hh.id AS TEXT) LIKE '%' || @filtro || '%' "+
                    " and hh.id not in (Select h.id from articulos h where h.nombre LIKE '%' ||  @filtro || '%')    " +
                    "ORDER BY nombre ", npgsqlConn);
                cmdSel2.Parameters.Add("@filtro", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = filtro;
                NpgsqlDataReader drHerramientas2 = cmdSel2.ExecuteReader();

                while (drHerramientas2.Read())
                {
                    Articulos art = new Articulos();
                    art.Categoria = (string)drHerramientas2["categoria"];
                    art.Nombre = (string)drHerramientas2["nombre"];
                    art.ID = (string)drHerramientas2["id"];
                    art.Proveedor_habitual = (string)drHerramientas2["proveedor_habitual"];
                    art.Categoria_2 = (string)drHerramientas2["categoria_2"];
                    try
                    {
                        art.Comentarios = (string)drHerramientas2["comentarios"];
                    }
                    catch { }
                    art.Stock = (int)drHerramientas2["stock"];
                    art.Unidad = (string)drHerramientas2["unidad"];
                    art.Precio = (double)drHerramientas2["precio"];
                    art.Porcentaje_ganancia = (double)drHerramientas2["porcentaje_ganancia"];
                    artList.Add(art);

                }
                drHerramientas2.Close();
           
                return artList;

            }
            finally { CloseConnection(); }

        }
        public void Update(Articulos art)
        {

            try
            {
                this.OpenConnection();

                NpgsqlCommand cmdSave = new NpgsqlCommand("update articulos set comentarios = @comentarios,proveedor_habitual = @proveedor_habitual, categoria_2 = @categoria_2 "+
                    " ,nombre=@nombre ,categoria=@categoria,unidad=@unidad,stock=@stock,porcentaje_ganancia = @porcentaje_ganancia, stock_minimo = @stock_min where id=@id ", npgsqlConn);

                cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = art.ID;
                cmdSave.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Nombre;
                cmdSave.Parameters.Add("@comentarios", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Comentarios;
                cmdSave.Parameters.Add("@categoria", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Categoria;
                cmdSave.Parameters.Add("@stock", NpgsqlTypes.NpgsqlDbType.Integer).Value = art.Stock;
                cmdSave.Parameters.Add("@unidad", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Unidad;
                cmdSave.Parameters.Add("@stock_min", NpgsqlTypes.NpgsqlDbType.Integer).Value = art.Stock_min;
                cmdSave.Parameters.Add("@porcentaje_ganancia", NpgsqlTypes.NpgsqlDbType.Double).Value = art.Porcentaje_ganancia;
                cmdSave.Parameters.Add("@categoria_2", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Categoria_2;
                cmdSave.Parameters.Add("@proveedor_habitual", NpgsqlTypes.NpgsqlDbType.Text).Value = art.Proveedor_habitual;
                cmdSave.ExecuteNonQuery();

            }
            finally { CloseConnection(); }


        }
        public void UpdatePrecio(List<Articulos> artList)
        {

            try
            {
                this.OpenConnection();
                foreach (Articulos art in artList)
                {
                    NpgsqlCommand cmdSave = new NpgsqlCommand("update articulos set  " +
                        " precio=@precio where id=@id ", npgsqlConn);

                    cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = art.ID;
                    cmdSave.Parameters.Add("@precio", NpgsqlTypes.NpgsqlDbType.Double).Value = art.Precio;

                    cmdSave.ExecuteNonQuery();

                   

                    
                }
            }
            finally { CloseConnection();
                //actualizo cuenta corriente abierta para los articulos q aun estan abiertos
            try
            {
                foreach (Articulos art in artList)
                {
                    VentasAdap vAdap = new VentasAdap();
                    vAdap.ActualizarPrecioDeCuentasCorrientesConDeuda(art.ID, art.Precio);


                }
            }
            catch { }
            
            }


        }
        public string DevolverU(string id, string s)
        {
            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select unidad from articulos where id=@id", npgsqlConn);
                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                string unidad = (string)cmdSel.ExecuteScalar();
                return unidad;
            }
            finally { CloseConnection(); }


        }
        public Articulos GetOne(string id)
        {

            try
            {
             
                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from articulos where id=@id", npgsqlConn);
                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();

                Articulos art = new Articulos();
                while (drHerramientas.Read())
                {
                   
                    art.Categoria = (string)drHerramientas["categoria"];
                    art.Nombre = (string)drHerramientas["nombre"];
                    art.ID = (string)drHerramientas["id"];
                    try
                    {
                        art.Comentarios = (string)drHerramientas["comentarios"];
                    }
                    catch { }
                    art.Proveedor_habitual = (string)drHerramientas["proveedor_habitual"];
                    art.Categoria_2 = (string)drHerramientas["categoria_2"];
                    art.Stock = (int)drHerramientas["stock"];
                    art.Unidad = (string)drHerramientas["unidad"];
                    art.Precio = (double)drHerramientas["precio"];

                    art.Stock_min = (int)drHerramientas["stock_minimo"];
                    art.Porcentaje_ganancia = (double)drHerramientas["porcentaje_ganancia"];
                }
                return art;

            }
            finally { CloseConnection(); }

        }
        public void GetStock(int id, int cant)
        {

            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select stock from articulos where id=@id", npgsqlConn);
                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                int stoc = (int)cmdSel.ExecuteScalar();


                stoc = stoc + cant;
                
                NpgsqlCommand cmdUp = new NpgsqlCommand(" update articulos set stock = @stock where id=@id", npgsqlConn);
                cmdUp.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                cmdUp.Parameters.Add("@stock", NpgsqlTypes.NpgsqlDbType.Integer).Value = stoc;

                cmdUp.ExecuteNonQuery();





            }
            finally { CloseConnection(); }

        }
        public void RestaStock(int cant, string id, string obs, DateTime hoy)
        {

            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select stock from articulos where id=@id", npgsqlConn);
                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                int stoc = (int)cmdSel.ExecuteScalar();


                stoc = stoc - cant;

                NpgsqlCommand cmdUp = new NpgsqlCommand(" update articulos set stock = @stock where id=@id", npgsqlConn);
                cmdUp.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                cmdUp.Parameters.Add("@stock", NpgsqlTypes.NpgsqlDbType.Integer).Value = stoc;
                cmdUp.ExecuteNonQuery();

                NpgsqlCommand cmdPerdida = new NpgsqlCommand(" insert into perdida_stock (id_articulo, cantidad, observaciones, fecha_perdida,signo)" +
                    "values(@id,@cantidad,@observaciones,@hoy,'-')", npgsqlConn);
                cmdPerdida.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                cmdPerdida.Parameters.Add("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = cant;
                cmdPerdida.Parameters.Add("@observaciones", NpgsqlTypes.NpgsqlDbType.Text).Value = obs;
                cmdPerdida.Parameters.Add("@hoy", NpgsqlTypes.NpgsqlDbType.Date).Value = hoy;
                cmdPerdida.ExecuteNonQuery();




            }
            finally { CloseConnection(); }

        }
        public void SumaStockk(int cant, string id, string obs, DateTime hoy)
        {

            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select stock from articulos where id=@id", npgsqlConn);
                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                int stoc = (int)cmdSel.ExecuteScalar();


                stoc = stoc + cant;

                NpgsqlCommand cmdUp = new NpgsqlCommand(" update articulos set stock = @stock where id=@id", npgsqlConn);
                cmdUp.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                cmdUp.Parameters.Add("@stock", NpgsqlTypes.NpgsqlDbType.Integer).Value = stoc;
                cmdUp.ExecuteNonQuery();

                NpgsqlCommand cmdSuma = new NpgsqlCommand(" insert into suma_stock (id_articulo, cantidad, razon_de_suma, fecha_suma,signo)" +
                    "values(@id,@cantidad,@observaciones,@hoy,'+')", npgsqlConn);
                cmdSuma.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                cmdSuma.Parameters.Add("@cantidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = cant;
                cmdSuma.Parameters.Add("@observaciones", NpgsqlTypes.NpgsqlDbType.Text).Value = obs;
                cmdSuma.Parameters.Add("@hoy", NpgsqlTypes.NpgsqlDbType.Date).Value = hoy;
                cmdSuma.ExecuteNonQuery();






            }
            finally { CloseConnection(); }

        }
        public List<GestionArticulos> InformeGestionArticulos()
        {
            List<GestionArticulos> gaList = new List<GestionArticulos>();
            try
            {

                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select * from suma_stock " +
                    "inner join articulos on id = id_articulo where EXTRACT(YEAR FROM  fecha_suma) = EXTRACT(YEAR FROM current_date) " +
                    "UNION " +
                    " select * from perdida_stock " +
                     "inner join articulos on id = id_articulo where EXTRACT(YEAR FROM  fecha_perdida) = EXTRACT(YEAR FROM current_date) order by fecha_suma DESC ", npgsqlConn);

                NpgsqlDataReader drArt = cmdSel.ExecuteReader();

                while (drArt.Read())
                {
                    GestionArticulos ga = new GestionArticulos();
                    ga.ID = (string)drArt["id_articulo"];
                    ga.Nombre = (string)drArt["nombre"];
                    ga.Fecha_movimiento = (DateTime)drArt["fecha_suma"];
                    ga.Descripcion = (string)drArt["razon_de_suma"] + " (" + (int)drArt["cantidad"] + " " + (string)drArt["unidad"] + ")";
                    ga.Signo = Convert.ToChar((string)drArt["signo"]);
                    gaList.Add(ga);
                }


            }
            finally { CloseConnection(); }
            return gaList;
        }
        public List<GestionArticulos> InformeGestionArticulosFiltroArticulo(string articulo)
        {
            List<GestionArticulos> gaList = new List<GestionArticulos>();
            try
            {

                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select * from suma_stock " +
                    "inner join articulos on id = id_articulo " +
                    "where EXTRACT(YEAR FROM  fecha_suma) = EXTRACT(YEAR FROM current_date) and nombre LIKE '%' ||  @filtro || '%' " +
                    "UNION " +
                    "select * from perdida_stock " +
                    " inner join articulos on id = id_articulo " +
                    " where EXTRACT(YEAR FROM  fecha_perdida) = EXTRACT(YEAR FROM current_date) and nombre LIKE '%' ||  @filtro || '%' order by fecha_suma DESC ", npgsqlConn);
                cmdSel.Parameters.Add("@filtro", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = articulo;
                NpgsqlDataReader drArt = cmdSel.ExecuteReader();

                while (drArt.Read())
                {
                    GestionArticulos ga = new GestionArticulos();
                    ga.ID = (string)drArt["id_articulo"];
                    ga.Nombre = (string)drArt["nombre"];
                    ga.Fecha_movimiento = (DateTime)drArt["fecha_suma"];
                    ga.Descripcion = (string)drArt["razon_de_suma"] + " (" + (int)drArt["cantidad"] + " " + (string)drArt["unidad"] + ")";
                    ga.Signo = Convert.ToChar((string)drArt["signo"]);
                    gaList.Add(ga);
                }


            }
            finally { CloseConnection(); }
            return gaList;
        }
        public List<GestionArticulos> InformeGestionArticulosFiltroTiempo(DateTime desde, DateTime hasta)
        {
            List<GestionArticulos> gaList = new List<GestionArticulos>();
            try
            {

                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select * from suma_stock " +
                    "inner join articulos on id = id_articulo " +
                    "where   fecha_suma BETWEEN @desde and @hasta " +
                    "UNION " +
                    "select * from perdida_stock " +
                    " inner join articulos on id = id_articulo " +
                    " where fecha_perdida BETWEEN @desde and @hasta  order by fecha_suma DESC ", npgsqlConn);
                cmdSel.Parameters.Add("@desde", NpgsqlTypes.NpgsqlDbType.Date).Value = desde;
                cmdSel.Parameters.Add("@hasta", NpgsqlTypes.NpgsqlDbType.Date).Value = hasta;
                NpgsqlDataReader drArt = cmdSel.ExecuteReader();

                while (drArt.Read())
                {
                    GestionArticulos ga = new GestionArticulos();
                    ga.ID = (string)drArt["id_articulo"];
                    ga.Nombre = (string)drArt["nombre"];
                    ga.Fecha_movimiento = (DateTime)drArt["fecha_suma"];
                    ga.Descripcion = (string)drArt["razon_de_suma"] + " (" + (int)drArt["cantidad"] + " " + (string)drArt["unidad"] + ")";
                    ga.Signo = Convert.ToChar((string)drArt["signo"]);
                    gaList.Add(ga);
                }


            }
            finally { CloseConnection(); }
            return gaList;
        }
        public List<GestionArticulos> InformeGestionArticulosFiltroArticuloTiempo(string articulo, DateTime desde, DateTime hasta)
        {
            List<GestionArticulos> gaList = new List<GestionArticulos>();
            try
            {

                OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand("select * from suma_stock " +
                    "inner join articulos on id = id_articulo " +
                    "where fecha_suma BETWEEN @desde and @hasta and nombre LIKE '%' ||  @filtro || '%' " +
                    "UNION " +
                    "select * from perdida_stock " +
                    " inner join articulos on id = id_articulo " +
                    " where fecha_perdida BETWEEN @desde and @hasta and nombre LIKE '%' ||  @filtro || '%' order by fecha_suma DESC ", npgsqlConn);

                cmdSel.Parameters.Add("@filtro", NpgsqlTypes.NpgsqlDbType.Varchar, 50).Value = articulo;
                cmdSel.Parameters.Add("@desde", NpgsqlTypes.NpgsqlDbType.Date).Value = desde;
                cmdSel.Parameters.Add("@hasta", NpgsqlTypes.NpgsqlDbType.Date).Value = hasta;
                NpgsqlDataReader drArt = cmdSel.ExecuteReader();

                while (drArt.Read())
                {
                    GestionArticulos ga = new GestionArticulos();
                    ga.ID = (string)drArt["id_articulo"];
                    ga.Nombre = (string)drArt["nombre"];
                    ga.Fecha_movimiento = (DateTime)drArt["fecha_suma"];
                    ga.Descripcion = (string)drArt["razon_de_suma"] + " (" + (int)drArt["cantidad"] + " " + (string)drArt["unidad"] + ")";
                    ga.Signo = Convert.ToChar((string)drArt["signo"]);
                    gaList.Add(ga);
                }


            }
            finally { CloseConnection(); }
            return gaList;
        }
        public void UpdatePorcentajeGanancia(string id, double porcentaje)
        {
            try
            {
                this.OpenConnection();
                
               
                    NpgsqlCommand cmdSave = new NpgsqlCommand("update articulos set  " +
                        " porcentaje_ganancia=@porcentaje where id=@id ", npgsqlConn);

                    cmdSave.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                    cmdSave.Parameters.Add("@porcentaje", NpgsqlTypes.NpgsqlDbType.Double).Value = porcentaje;

                    cmdSave.ExecuteNonQuery();
                
            }
            finally
            {
                CloseConnection();
             
               

            }
        
        }
        public List<Articulos> GetCategorias()
        {
            try
            {
                List<Articulos> artList = new List<Articulos>();
                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select categoria from articulos group by categoria order by categoria ", npgsqlConn);
                NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();
                Articulos art1 = new Articulos();
                art1.Categoria = "TODAS";
                artList.Add(art1);

                while (drHerramientas.Read())
                {
                    Articulos art = new Articulos();
                    art.Categoria = (string)drHerramientas["categoria"];
                    artList.Add(art);

                }
                return artList;

            }
            finally { CloseConnection(); }
        
        }
        
        public int GetStock(string id)
        {
            try
            {

                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select stock from articulos where id=@id", npgsqlConn);
                cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
                int stoc = (int)cmdSel.ExecuteScalar();
                return stoc;
            }
            finally { CloseConnection(); }


        }
        public double GetPrecio(string id)
      {
          try
          {

              this.OpenConnection();
              NpgsqlCommand cmdSel = new NpgsqlCommand(" select precio from articulos where id=@id", npgsqlConn);
              cmdSel.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Text).Value = id;
              double precio = (double)cmdSel.ExecuteScalar();
              return precio;
          }
          finally { CloseConnection(); }


      }

        public List<Articulos> GetAllOrdenadosPorCategoria()
        {

            try
            {
                List<Articulos> artList = new List<Articulos>();
                this.OpenConnection();
                NpgsqlCommand cmdSel = new NpgsqlCommand(" select * from articulos order by categoria,categoria_2,nombre", npgsqlConn);
                NpgsqlDataReader drHerramientas = cmdSel.ExecuteReader();

                while (drHerramientas.Read())
                {   Articulos art = new Articulos();
                    art.Categoria_2 =       (string)drHerramientas["categoria_2"];
                    art.Categoria =         (string)drHerramientas["categoria"];
                    art.Nombre =            (string)drHerramientas["nombre"];
                    art.ID =                (string)drHerramientas["id"];
                    artList.Add(art);

                }
                return artList;

            }
            finally { CloseConnection(); }

        }
       
    }
}
