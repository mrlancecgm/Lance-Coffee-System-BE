using System;
using System.Globalization;

namespace LanceCoffeeSystem.Application.Exceptions
{
    public class TeapotException : Exception
    {
        public TeapotException() : base()
        {
        }

        public TeapotException(string message) : base(message)
        {
        }

        public TeapotException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}