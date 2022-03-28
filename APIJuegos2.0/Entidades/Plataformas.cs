namespace APIJuegos2._0.Entidades
{
    public class Plataformas
    {
        public int Id {get; set;}
        public string Nombre {get; set;}

        public int JuegoId { get; set;}
        public Juegos Juego { get; set;}
    }
}
