using ComicsPOO.Entidades;
using System.Xml.Serialization;

namespace ComicsPOO.Datos
{
    public class SerializadorXml : IArchivo<List<Producto>>
    {
        private string? nombreArchivo = "Productos.Xml";
        private string? nombreCarpeta = Environment.CurrentDirectory;
        private string? rutaCompleta;

        public SerializadorXml()
        {
            rutaCompleta = Path.Combine(nombreCarpeta, nombreArchivo);
        }

        public void GuardarDatos(List<Producto> dtos)
        {
            using(var escritor = new StreamWriter(rutaCompleta!))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Producto>));
                xml.Serialize(escritor, dtos);
            }
        }

        public List<Producto> LeerDatos()
        {
            if (File.Exists(rutaCompleta))
            {
                return new List<Producto>();
            }
            using(var lector = new StreamReader(rutaCompleta!))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Producto>));
                return (List<Producto>)xml.Deserialize(lector)!;
            }
        }
    }
}
