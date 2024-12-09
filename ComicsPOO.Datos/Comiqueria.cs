using ComicsPOO.Entidades;
using System.Net.Http.Headers;

namespace ComicsPOO.Datos
{
    public class Comiqueria
    {
        public string? Nombre { get; set; }
        private Dictionary<Guid, Producto>? productos;
        private SerializadorXml? serializador;

        private Comiqueria()
        {
            productos = new Dictionary<Guid, Producto>();
            serializador = new SerializadorXml();
        }
        public Comiqueria(string nombre):this()
        {
            Nombre = nombre;
        }

        public (bool exito, string mensaje) AgregarProducto(Producto producto)
        {
            if (!EstaProducto(producto))
            {
                productos!.Add(producto.Codigo, producto);
                return (true, $"Producto agregado: {producto.ToString()}");
            }
            else
            {
                productos[producto.Codigo].Stock += producto.Stock;
                return (true, $"Stock agregado");

            }
        }

        public (bool exito, string mensaje) QuitarProducto(Guid nro)
        {
            var estaP = productos.ContainsKey(nro);
            if (estaP)
            {
                productos!.Remove(nro);
                return (true, $"Producto removido");
            }
            else
            {
                return (false, $"El producto no existe");

            }
        }

        private bool EstaProducto(Producto producto)
        {
            if (productos!.ContainsKey(producto.Codigo!))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Producto> GetLista()
        {
            List<Producto> lista = new List<Producto>();
            lista = productos!.Values.ToList();
            return lista;
        }

        public List<Producto> GetListaTipo(TipoProducto tipo)
        {
            

            List<Producto> lista = new List<Producto>();
            lista = productos!.Values.ToList();
            return lista.Where(l => l.GetType() == tipo.GetType()).ToList();
        }

        public void GuardarDatos()
        {
            serializador!.GuardarDatos(productos!.Values.ToList());
        }
        public int GetCantidad()
        {
            return productos!.Count();
        }

        public List<Producto> LeerDatos()
        {

            var lista = serializador.LeerDatos();
            foreach (var item in lista)
            {
                productos.Add(item.Codigo, item);
            }
            return lista;
        }
    }
}
