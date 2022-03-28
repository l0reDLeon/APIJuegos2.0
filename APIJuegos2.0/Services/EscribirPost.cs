namespace APIJuegos2._0.Services
{
    public class EscribirPost
    {
        public IWebHostEnvironment env;
        public EscribirPost(string nombre, string mensaje, IWebHostEnvironment entorno)
        {
            this.env = entorno;
            write(nombre,mensaje);
        }

        private void write(string msg, string nombre)
        {
            var ruta = $@"{env.ContentRootPath}\wwwroot\{nombre}";
            using (StreamWriter writer = new StreamWriter(ruta, append: true)) { 
                writer.WriteLine(msg);
                writer.Close();
            }
        }
    }
}
