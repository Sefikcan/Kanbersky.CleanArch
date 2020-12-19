using Kanbersky.CleanArch.Core.Results.ApiResponses.Abstract;
using Kanbersky.CleanArch.Core.Results.ApiResponses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.CleanArch.Core.Results.ApiResponses.Concrete
{
    public class CleanArchUpdatedObjectResult<T> : ObjectResult, IBaseActionResult
    {
        public CleanArchUpdatedObjectResult(T result): base(new BaseObjectModel<T>(result))
        {
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
