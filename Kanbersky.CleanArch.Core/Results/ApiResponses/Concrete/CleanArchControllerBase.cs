using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.CleanArch.Core.Results.ApiResponses.Concrete
{
    public class CleanArchControllerBase : ControllerBase
    {
        [NonAction]
        public CleanArchCreatedObjectResult<TResult> ApiCreated<TResult>(TResult result) where TResult : class
        {
            return new CleanArchCreatedObjectResult<TResult>(result);
        }

        [NonAction]
        public CleanArchOkResult ApiOk()
        {
            return new CleanArchOkResult();
        }

        [NonAction]
        public CleanArchOkObjectResult<TResult> ApiOk<TResult>(TResult result) where TResult : class
        {
            return new CleanArchOkObjectResult<TResult>(result);
        }

        [NonAction]
        public CleanArchNoContentResult ApiNoContent()
        {
            return new CleanArchNoContentResult();
        }

        [NonAction]
        public CleanArchUpdatedObjectResult<TResult> ApiUpdated<TResult>(TResult result) where TResult : class
        {
            return new CleanArchUpdatedObjectResult<TResult>(result);
        }
    }
}
