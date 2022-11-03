using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RocketProcess.Shared.Utilidades;
using System.Configuration;
using System.Dynamic;
using System.Threading;

namespace RocketProcess.Server.AutomaticServices
{
    public class RobotUsuarios : IHostedService, IDisposable
    {
        private Timer _timer;
        private double _Periodicidad;
        string appSettingsPath;
        string json;
        dynamic _config;

        public RobotUsuarios(IConfiguration configuration)
        {

            //var Alarmas1 = configuration.GetSection("Alarmas").Get<Alarmas>();
            //_Periodicidad = ;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public async void Revision(object state)
        {
            /*
             * Para que funcione el servicio se tiene que activar lo siguiente en IIS:
             * Al grupo de aplicaciones que pertenezca el sitio, se le debe activar la opción :
             *       Grupo de Aplicaciones -> “Grupo del sitio” -> Configuración Avanzada -> Start Mode en inglés o Modo de inicio en español = "AlwaysRunning"
             * Al sitio se le debe configurar la opción :
             *      Sitios -> “Sitio de la aplicación” -> Configuración avanzada -> Preload Enabled en inglés o carga previa activada en español = "true"
             *      
                Se creará un archivo nuevo cada día, para que no tenga problemas al abrir por tamaño del archivo.
             */

            var _state = state;
            string nombreArchivo = DateTime.Now.ToShortDateString() + "_log" + ".txt";
            string directorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RocketLogs");
            string path = Path.Combine(directorio, nombreArchivo);

            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            if (!File.Exists(path))
                File.Create(path);

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        await sw.WriteLineAsync(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " - Registro automatico");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var token = cancellationToken;
            var valor = _Periodicidad;
            double cadaCuanto = 10;

            _timer =
                new Timer(callback: Revision,
                          state: null,
                          dueTime: TimeSpan.Zero,
                          period: TimeSpan.FromSeconds(cadaCuanto)
                          );

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        void ValidarAppSettings()
        {
            appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            json = File.ReadAllText(appSettingsPath);
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new ExpandoObjectConverter());
            jsonSettings.Converters.Add(new StringEnumConverter());

            _config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);
            _config.Alarmas1 = "Alarmas";
            _config.Alarmas.Periodicidad1 = 30;
            _config.DebugEnabled = true;

            var newJson = JsonConvert.SerializeObject(_config, Formatting.Indented, jsonSettings);
            File.WriteAllText(appSettingsPath, newJson);
        }
    }
}
