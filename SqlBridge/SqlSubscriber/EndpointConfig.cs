namespace SqlSubscriber
{
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, UsingTransport<SqlServerTransport>
	{
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.Conventions().DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith("Events"));
        }
    }
}