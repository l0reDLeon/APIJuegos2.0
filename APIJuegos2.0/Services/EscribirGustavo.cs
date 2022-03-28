namespace APIJuegos2._0.Services
{
    public class EscribirGustavo : IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string nombreArchivo = "ProfeGustavo.txt";
        private Timer timer;

        public EscribirGustavo(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(120));
            Escribir("Proceso iniciado");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
            Escribir("Proceso finalizado");
            return Task.CompletedTask;
        }
        private void Escribir(string msg)
        {
            var ruta = $@"{env.ContentRootPath}\wwwroot\{nombreArchivo}";
            using (StreamWriter writer = new StreamWriter(ruta, append: true)) { 
                writer.WriteLine(msg);
                writer.Close();
            }
        }

        private void DoWork(object state)
        {
            Escribir("El Profe Gustavo Rodriguez es el mejor.   " + DateTime.Now.ToString("hh:mm:ss"));
        }


    }
}