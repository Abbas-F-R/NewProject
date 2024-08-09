using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using FileResult = dotnet.DTOs.Files.FileResult;

namespace dotnet.Controllers;

public class BaseController : ControllerBase
{

    protected Guid Id => Guid.TryParse(GetClaim("Id"), out var id) ? id : Guid.Empty;
    protected string Role => GetClaim("Role");
    protected Guid? ParentId
    {
        get
        {
            var idString = GetClaim("ParentId");
            Guid? re;
            if (!string.Equals(idString, null, StringComparison.Ordinal) &&
                !string.Equals(idString, "null", StringComparison.Ordinal))
                re = Guid.Parse(idString);
            else
                re = null;
            return re;
        }
    }
    protected string MethodType => HttpContext.Request.Method;
    protected virtual string GetClaim(string claimName)
    {
        var claims = (User.Identity as ClaimsIdentity)?.Claims;
        var claim = claims?.FirstOrDefault(c =>
            string.Equals(c.Type, claimName, StringComparison.CurrentCultureIgnoreCase) &&
            !string.Equals(c.Type, "null", StringComparison.CurrentCultureIgnoreCase));
        var rr = claim?.Value!.Replace("\"", "");

        return rr ?? "";
    }

    protected ObjectResult OkObject<T>((T? data, string? error) result)
    {
        return result.error != null
            ? base.BadRequest(new { Message = result.error })
            : base.Ok(result.data);
    }

    protected ObjectResult Ok<T>((List<T>? data, int? totalCount, string? error) result,
        int pageNumber = 0, int pageSize = 10
    )
    {
        return result.error != null
            ? base.BadRequest(new { Message = result.error })
            : base.Ok(new Respons<T>
            {
                Data = result.data,
                PagesCount = (result.totalCount - 1) / 10 + 1,
                CurrentPage = pageNumber,
                TotalCount = result.totalCount,
                IsLast = pageNumber == (result.totalCount - 1) / 10 + 1
            });
    }

    protected ObjectResult Ok<T>((T obj, string? error) result)
    {
        return result.error != null
            ? base.BadRequest(new { Message = result.error })
            : base.Ok(result.obj);
    }
    protected IActionResult OkFile((FileResult? data, string? error) result)
    {
        return result.error != null
            ? base.BadRequest(new { Message = result.error })
            : File(result.data!.FileBytes, result.data.ContentType, result.data.FileName);
    }


}