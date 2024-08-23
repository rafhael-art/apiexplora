using System;
using System.ComponentModel.DataAnnotations;

namespace Xplora.UseCases.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NonNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is decimal decimalValue)
            {
                return decimalValue >= 0;
            }

            if (value is int intValue)
            {
                return intValue >= 0;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} no puede ser un valor negativo.";
        }
    }
}

