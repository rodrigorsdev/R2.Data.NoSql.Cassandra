using Microsoft.AspNetCore.Mvc;
using System;

namespace R2.Data.NoSql.Cassandra.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        protected new IActionResult Response(object result = null, Exception e = null)
        {
            if (e == null)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                error = e
            });
        }
    }
}