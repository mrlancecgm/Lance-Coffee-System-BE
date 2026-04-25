using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LanceCoffeeSystem.Application.Interfaces.Shared;
using LanceCoffeeSystem.Application.Exceptions;
using System;

namespace LanceCoffeeSystem.Application.Features.CoffeeSystem.Queries.BrewCoffee
{
    public class GetBrewCoffeeQuery : IRequest<GetBrewCoffeeResponse>
    {
        public class GetBrewCoffeeQueryHandler : IRequestHandler<GetBrewCoffeeQuery, GetBrewCoffeeResponse>
        {
            private readonly IDateTimeService _dateTimeService;
            private readonly ICoffeeCounterService _coffeeCounterService;
            public GetBrewCoffeeQueryHandler(IDateTimeService dateTimeService, ICoffeeCounterService coffeeCounterService)
            {
                _dateTimeService = dateTimeService;
                _coffeeCounterService = coffeeCounterService;
            }

            public async Task<GetBrewCoffeeResponse> Handle(GetBrewCoffeeQuery query, CancellationToken cancellationToken)
            {
                var count = _coffeeCounterService.Increment();
                string message = "Your piping hot coffee is ready.";
                var dateNowPH = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                    _dateTimeService.NowUtc,
                    "Singapore Standard Time");

                if (dateNowPH.Month == 4 && dateNowPH.Day == 1)
                {
                    throw new TeapotException();
                }

                if (count % 5 == 0)
                {
                    throw new CoffeeUnavailableException();
                }                

                GetBrewCoffeeResponse response = new GetBrewCoffeeResponse()
                {
                    message = message,
                    prepared =
                        $"{dateNowPH:yyyy-MM-ddTHH:mm:ss}" +
                        $"{dateNowPH:zzz}".Replace(":", "")
                };
                return response; 
            }
        }
    }
}