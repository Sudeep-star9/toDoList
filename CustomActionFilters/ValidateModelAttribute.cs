using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Nzwalks.API.CustomActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly ILogger<ValidateModelAttribute> _logger;

        public ValidateModelAttribute(ILogger<ValidateModelAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                                    .Where(e => e.Value.Errors.Count > 0)
                                    .Select(e => new
                                    {
                                        e.Key,
                                        Errors = e.Value.Errors.Select(err => err.ErrorMessage)
                                    });

            
                _logger.LogWarning("Validation failed with errors: {Errors}", errors);

                context.Result = new BadRequestObjectResult(new
                {
                    Message = "Validation failed.",
                    Errors = errors
                });
            }
        }
    }
}
