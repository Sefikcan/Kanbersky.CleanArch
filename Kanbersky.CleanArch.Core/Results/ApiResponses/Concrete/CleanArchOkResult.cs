using Kanbersky.CleanArch.Core.Results.ApiResponses.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.CleanArch.Core.Results.ApiResponses.Concrete
{
    public class CleanArchOkResult : StatusCodeResult, IBaseActionResult
    {
        public CleanArchOkResult() : base(StatusCodes.Status200OK)
        {
        }
    }
}
