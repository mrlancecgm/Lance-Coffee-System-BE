using System;
using System.Globalization;

namespace LanceCoffeeSystem.Application.Exceptions
{
    public class CoffeeUnavailableException : Exception
    {
        public CoffeeUnavailableException() : base()
        {
        }

        public CoffeeUnavailableException(string message) : base(message)
        {
        }

        public CoffeeUnavailableException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}