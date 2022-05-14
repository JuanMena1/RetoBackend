namespace RetoBackend.Modelos
{
    public class Vehiculo
    {
        public int Id { get; set; }

        public string Ubicacion { get; set; }

        public string Historial { get; set; }

        public int? ID_Pedido { get; set; }
    }
}
