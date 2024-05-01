using MassTransit;
using Mentoring.Employees.Shared.SharedMessages;

namespace AuditingMicroservice.Consumers
{
    public class EmployeeCreatedMessageConsumer : IConsumer<EmployeeCreated>
    {
        public async Task Consume(ConsumeContext<EmployeeCreated> context)
        {
            Console.WriteLine($"A new employee created, {context.Message.Id}");

            throw new NotImplementedException();
        }
    }
}
