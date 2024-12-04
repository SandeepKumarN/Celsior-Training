using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LifeInsuranceApplication.Misc
{
    internal class ErrorResponseDTO : ModelStateDictionary
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public int ErrorNumber { get; set; }
    }
}