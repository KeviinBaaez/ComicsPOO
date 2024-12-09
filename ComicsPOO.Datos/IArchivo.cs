namespace ComicsPOO.Datos
{
    public interface IArchivo<T> where T : class
    {
        void GuardarDatos(T dtos);
        T LeerDatos();
    }
}
