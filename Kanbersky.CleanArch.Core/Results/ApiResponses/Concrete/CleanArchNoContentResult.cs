using Kanbersky.CleanArch.Core.Results.ApiResponses.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.CleanArch.Core.Results.ApiResponses.Concrete
{
    public class CleanArchNoContentResult : StatusCodeResult, IBaseActionResult
    {
        public CleanArchNoContentResult() : base(StatusCodes.Status204NoContent)
        {
        }
    }
}
