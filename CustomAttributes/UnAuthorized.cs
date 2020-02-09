﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace iQurban.CustomAttributes
{
    public class UnAuthorizedAttribute : TypeFilterAttribute
    {
        public UnAuthorizedAttribute() : base(typeof(UnauthorizedFilter))
        {
            //Empty constructor
        }
    }

    internal class UnauthorizedFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            if (!IsAuthenticated)
            {
                if (context.HttpContext.Request.IsAjaxRequest())
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden; //Set HTTP 403 - JRozario
                }
                else
                {
                    context.Result = new RedirectResult("~/Home/Index");
                }
            }
        }
    }
}
