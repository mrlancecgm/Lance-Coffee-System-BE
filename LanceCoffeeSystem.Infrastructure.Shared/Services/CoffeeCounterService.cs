using LanceCoffeeSystem.Application.Interfaces.Shared;
using System.Threading;

namespace LanceCoffeeSystem.Infrastructure.Shared.Services
{
    public class CoffeeCounterService : ICoffeeCounterService
    {
        private int _count = 0;

        public int Increment()
        {
            return Interlocked.Increment(ref _count);
        }
    }
}