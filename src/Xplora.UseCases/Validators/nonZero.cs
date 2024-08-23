using System;
using System.ComponentModel.DataAnnotations;

namespace Xplora.UseCases.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NonZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is decimal decimalValue)
            {
                return decimalValue > 0;
            }

            if (value is int intValue)
            {
                return intValue > 0;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} debe ser un valor mayor que cero.";
        }
    }

}

