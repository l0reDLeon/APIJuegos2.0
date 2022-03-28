//using APIJuegos2._0.DTOs;
using APIJuegos2._0.Entidades;

namespace APIJuegos2._0.Services
{
    public class EscribirGet
    {
        public IWebHostEnvironment env;
        private readonly string nombre = "GET.txt";
        //private List<GetJuegosDTO> listaGet;

        public EscribirGet(List<Juegos> lista, string pattern, IWebHostEnvironment entorno)
        {
            this.env= entorno;
            write("Consultando coincidencias con: '" + pattern + "' a las " + 
                DateTime.Now.ToString("hh:mm:ss") + " del día " + DateTime.Now.ToString("dd/MM/yyyy"));
            foreach (Juegos juego in lista)
            {
                write("\t"+juego.Nombre);
            }
        }

        private void write(string msg)
        {
            var ruta = $@"{env.ContentRootPath}\wwwroot\{nombre}";
            using (StreamWriter writer = new StreamWriter(ruta, append: true))
            {
                writer.WriteLine(msg);
                writer.Close();
            }
        }

    }
}
