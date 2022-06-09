using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace AgricolaMVC.App_Start
{
    public class HangFireService : IRegisteredObject
    {
        public static readonly HangFireService Instance = new HangFireService();

        private readonly object _lockObject = new object();
        private bool _started;
        private BackgroundJobServer _backgroundJobServer;

        public HangFireService()
        {

        }

        public void Start()
        {
            lock (_lockObject)
            {
                if (_started) return;
                _started = true;


                HostingEnvironment.RegisterObject(this);

                GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

                _backgroundJobServer = new BackgroundJobServer();

                //RecurringJob.AddOrUpdate("Verificar Vigencia", () => this.VigenciaTask(), cronExpression: Cron.HourInterval(12));
                //RecurringJob.AddOrUpdate("Correo Notificacion", () => this.CorreoNotifTask(), cronExpression: Cron.HourInterval(12));
                //RecurringJob.AddOrUpdate("Recargar Sitio", () => this.CargarSitio(), Cron.MinuteInterval(10));
                //RecurringJob.AddOrUpdate("Determinar Vigencia", () => this.DeterminarVigenciaCotizaciones(), cronExpression: Cron.HourInterval(24));
                //RecurringJob.AddOrUpdate("Enviar Notificaciones Automaticas", () => this.NotificacionesAutomaticas(), cronExpression: Cron.HourInterval(24));

            }
        }

        public void Stop()
        {
            lock (_lockObject)
            {
                _backgroundJobServer?.Dispose();

                HostingEnvironment.UnregisterObject(this);
            }
        }
        void IRegisteredObject.Stop(bool immediate)
        {
            Stop();
        }


    }
}