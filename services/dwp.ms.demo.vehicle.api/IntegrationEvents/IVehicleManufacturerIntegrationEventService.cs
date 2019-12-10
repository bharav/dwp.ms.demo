using EventBus.Events;
using System.Threading.Tasks;

namespace dwp.ms.demo.vehicle.api.IntegrationEvents
{
    public interface IVehicleManufacturerIntegrationEventService
    {
        Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt);
        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
