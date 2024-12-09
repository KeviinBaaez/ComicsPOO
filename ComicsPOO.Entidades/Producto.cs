using System.Text;
using System.Xml.Serialization;

namespace ComicsPOO.Entidades
{
	[XmlInclude(typeof(Comic))]
	[XmlInclude(typeof(Figurita))]
    public abstract class Producto
    {
		private Guid codigo;
		private decimal precio;
		private int stock;

		public int Stock
		{
			get { return stock; }
			set { stock = value; }
		}


		public decimal Precio
		{
			get { return precio; }
			set { precio = value; }
		}

		public Guid Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}
        protected Producto()
        {
			codigo = new Guid();
        }

        public Producto(string descripcion, decimal precio, int stock)
        {
			Descripcion = descripcion;
			Precio = precio;
			Stock = stock;
        }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Descripcion: {Descripcion}");
			sb.AppendLine($"Codigo: {Codigo}");
			sb.AppendLine($"Precio: {Precio}");
			sb.AppendLine($"Stock: {Stock}");
			return sb.ToString();
		}


    }
}
