using AuditingMicroservice.Consumers;
using MassTransit;

public class EmployeeCreatedConsumerDefinition :
    ConsumerDefinition<EmployeeCreatedMessageConsumer>
{
    public EmployeeCreatedConsumerDefinition()
    {
        ConcurrentMessageLimit = 4;
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<EmployeeCreatedMessageConsumer> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(r =>
        {
            r.Handle(typeof(NotImplementedException));
            r.Interval(5, 1000);
            }
        ); ;
    }
}
