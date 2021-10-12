using System;

namespace ProjectModels.ViewModels
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }
}
