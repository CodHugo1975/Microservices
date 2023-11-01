using MassTransit;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Threading.Tasks;

namespace AuthServiceAPI
{
    internal class MedicationConsumer: IConsumer<Medication>
    {
        private readonly ILogger<MedicationConsumer> logger;   
        public MedicationConsumer(ILogger<MedicationConsumer> logger)
        {
            this.logger= logger;
        }

      

        public async Task Consume(ConsumeContext<Medication> context)
        {
            await Console.Out.WriteLineAsync(context.Message.Name);
            logger.LogInformation($"New medication has been requested: {context.Message.Name}");

        }
    }
}