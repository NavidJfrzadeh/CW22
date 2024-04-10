using System.ComponentModel.DataAnnotations;

namespace Core.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumberValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string phoneNumber)
            {
                return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.StartsWith("09");
            }
            return false;
        }
    }
}
