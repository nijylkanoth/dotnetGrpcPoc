using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using TemperatureGrpcService;
using TemperatureStandardTypes;

namespace GrpcService.Services
{
    public class TemperatureService : Temperature.TemperatureBase
    {
        private readonly ILogger<TemperatureService> _logger;
        public TemperatureService(ILogger<TemperatureService> logger)
        {
            _logger = logger;
        }

        public override Task<TemperatureResponse> GetTemperature(TemperatureRequest request, ServerCallContext context)
        {

            return Task.FromResult(new TemperatureResponse
            {
                Reply = TemperatureConversion(request, request.Value)
            });
        }


        private float TemperatureConversion(TemperatureRequest temperatureRequest, float temperature)
        {

            return (temperatureRequest.Unit, temperatureRequest.ConvertTo) switch
            {
                (Unit: UnitOfTemperature.Celsius, ConvertTo: UnitOfTemperature.Fahrenheit) => temperature * 9f,
                (Unit: UnitOfTemperature.Celsius, ConvertTo: UnitOfTemperature.Kelvin) => temperature + 273.15f,

                (Unit: UnitOfTemperature.Fahrenheit, ConvertTo: UnitOfTemperature.Celsius) => (temperature - 32f) * 5f / 9f,
                (Unit: UnitOfTemperature.Fahrenheit, ConvertTo: UnitOfTemperature.Kelvin) => ((temperature - 32f) * 5f / 9f) + 273.15f,

                (Unit: UnitOfTemperature.Kelvin, ConvertTo: UnitOfTemperature.Celsius) => temperature - 273.15f,
                (Unit: UnitOfTemperature.Kelvin, ConvertTo: UnitOfTemperature.Fahrenheit) => ((temperature - 273.15f) * 9f) / 5f + 32f,

                _ => temperature
            };

        }

    }
}
