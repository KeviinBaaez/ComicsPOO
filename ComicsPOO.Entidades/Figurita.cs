namespace ComicsPOO.Entidades
{
    public class Figurita : Producto
    {
		private float altura;

		public float Altura
		{
			get { return altura; }
			set { altura = value; }

		}

        public Figurita():base()
        {

        }
        public Figurita(decimal precio, int stock, float altura):this($"Figura de {altura}cm", precio, stock, altura)
        {
            
        }
        public Figurita(string descripcion, decimal precio, int stock, float altura):
            base(descripcion, precio, stock)
        {
            Altura = altura;
        }
    }
}
