using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Voluntariese.Api.WebApi.Controllers
{
    public class ApiController : Controller
    {
        public long IdUsuarioAutenticado
        {
            get
            {
                var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                return Convert.ToInt64(claim?.Value);
            }
        }
    }
}
