using Ordering.Api.RabitMQ;

namespace Ordering.Api.Extensions
{
    public static class IApplicationBuilderExtension
    {
        public static EventBusRabbitMQConsumer Listener { get; set; }

        public static IApplicationBuilder UseRabitMQListner(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<EventBusRabbitMQConsumer>();
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarting);
            life.ApplicationStopping.Register(OnStopping);

            return app;
            return app;
        }

        public static void OnStarting()
        {
            Listener.Consume();
        }

        public static void OnStopping()
        {
            Listener.Disconnect();
        }
    }
}