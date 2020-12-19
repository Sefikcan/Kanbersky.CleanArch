using Kanbersky.CleanArch.Core.Results.ApiResponses.Abstract;
using Kanbersky.CleanArch.Core.Results.ApiResponses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.CleanArch.Core.Results.ApiResponses.Concrete
{
    public class CleanArchOkObjectResult<T> : ObjectResult, IBaseActionResult
    {
        public CleanArchOkObjectResult(T result) : base(new BaseObjectModel<T>(result))
        {
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
