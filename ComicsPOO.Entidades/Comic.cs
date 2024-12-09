using System.Text;

namespace ComicsPOO.Entidades
{
    public class Comic : Producto
    {
		private string? autor;
		private TipoComic tipo;

		public TipoComic Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}

		public string? Autor
		{
			get { return autor; }
			set { autor = value; }
		}

		public Comic() : base()
        {
            
        }

        public Comic(string autor, TipoComic tipo, string  descripcion, decimal  precio, int stock): 
			base(descripcion, precio, stock)
        {
			Autor = autor;
			Tipo = tipo;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Descripcion: {Descripcion}");
            sb.AppendLine($"Codigo: {Codigo}");
            sb.AppendLine($"Precio: {Precio}");
            sb.AppendLine($"Stock: {Stock}");
            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Tipo: {Tipo}");
            return sb.ToString();
        }

    }
}
