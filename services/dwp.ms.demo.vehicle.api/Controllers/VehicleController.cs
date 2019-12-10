using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using dwp.ms.demo.vehicle.api.Infrastructure;
using dwp.ms.demo.vehicle.api.IntegrationEvents;
using dwp.ms.demo.vehicle.api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using dwp.ms.demo.vehicle.api.IntegrationEvents.Event;

namespace dwp.ms.demo.vehicle.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleContext _vehicleContext;
        private readonly VehicleSettings _settings;
        private readonly IVehicleManufacturerIntegrationEventService _vehicleManufacturerIntegrationEventService;

        public VehicleController(VehicleContext context, IOptionsSnapshot<VehicleSettings> settings, IVehicleManufacturerIntegrationEventService vehicleManufacturerIntegrationEventService)
        {
            _vehicleContext = context ?? throw new ArgumentNullException(nameof(context));
            _vehicleManufacturerIntegrationEventService = vehicleManufacturerIntegrationEventService ?? throw new ArgumentNullException(nameof(vehicleManufacturerIntegrationEventService));
            _settings = settings.Value;

            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        [HttpGet]
        [Route("{engineNo}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Vehicle), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Vehicle>> GetByEngineNoAsync(string engineNo)
        {
            var vehicle = await _vehicleContext.Vehicles.SingleOrDefaultAsync(ci => ci.EngineNo == engineNo);
            return vehicle;
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> AddVehicleAsync([FromBody]Vehicle vehicle)
        {
            var catalogItem = _vehicleContext.Vehicles.Add(vehicle);

           
                //Create Integration Event to be published through the Event Bus
                var vehicleAddedEvent = new VehicleAddedIntegrationEvent(vehicle.EngineNo);

                // Achieving atomicity between original Catalog database operation and the IntegrationEventLog thanks to a local transaction
                await _vehicleManufacturerIntegrationEventService.SaveEventAndCatalogContextChangesAsync(vehicleAddedEvent);

                // Publish through the Event Bus and mark the saved event as published
                await _vehicleManufacturerIntegrationEventService.PublishThroughEventBusAsync(vehicleAddedEvent);

            return CreatedAtAction("GetByEngineNoAsync", new { engineNo = vehicle.EngineNo }, null);

        }
    }
}