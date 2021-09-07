using System;

namespace WebAPI_Core_Proj.Models.ViewModels
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }
}
