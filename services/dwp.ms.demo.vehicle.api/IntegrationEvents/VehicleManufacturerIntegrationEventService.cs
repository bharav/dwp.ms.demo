using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Abstractions;
using Microsoft.Extensions.Logging;
using EventBus.Events;
using EventBus.IntegrationEventLogEF.Services;
using System.Data.Common;
using dwp.ms.demo.vehicle.api.Infrastructure;
using EventBus.IntegrationEventLogEF.Utilities;

namespace dwp.ms.demo.vehicle.api.IntegrationEvents
{
    public class VehicleManufacturerIntegrationEventService : IVehicleManufacturerIntegrationEventService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<VehicleManufacturerIntegrationEventService> _logger;
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly VehicleContext _vehicleContext;
        private readonly IIntegrationEventLogService _eventLogService;
        

        public VehicleManufacturerIntegrationEventService(ILogger<VehicleManufacturerIntegrationEventService> logger,
            IEventBus eventBus,
            VehicleContext vehicleContext,
            Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _vehicleContext = vehicleContext ?? throw new ArgumentNullException(nameof(vehicleContext));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventLogServiceFactory(_vehicleContext.Database.GetDbConnection());
        }

        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            try
            {
                _logger.LogInformation("----- Publishing integration event: {IntegrationEventId_published} from {AppName} - ({@IntegrationEvent})", evt.Id, Program.AppName, evt);

                await _eventLogService.MarkEventAsInProgressAsync(evt.Id);
                _eventBus.Publish(evt);
                await _eventLogService.MarkEventAsPublishedAsync(evt.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", evt.Id, Program.AppName, evt);
               await _eventLogService.MarkEventAsFailedAsync(evt.Id);
            }
        }

        public async Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt)
        {
            _logger.LogInformation("----- CatalogIntegrationEventService - Saving changes and integrationEvent: {IntegrationEventId}", evt.Id);

            //Use of an EF Core resiliency strategy when using multiple DbContexts within an explicit BeginTransaction():
            //See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
            await ResilientTransaction.New(_vehicleContext).ExecuteAsync(async () =>
            {
                // Achieving atomicity between original catalog database operation and the IntegrationEventLog thanks to a local transaction
                await _vehicleContext.SaveChangesAsync();
                await _eventLogService.SaveEventAsync(evt, _vehicleContext.Database.CurrentTransaction);
            });
        }

    }
}
