using LanceCoffeeSystem.Application.Interfaces.Shared;
using System;

namespace LanceCoffeeSystem.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}