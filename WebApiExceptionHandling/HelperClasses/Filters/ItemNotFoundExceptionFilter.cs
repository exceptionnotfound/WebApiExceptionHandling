using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using WebApiExceptionHandling.Lib.Exceptions;

namespace WebApiExceptionHandling.HelperClasses.Filters
{
public class ItemNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(HttpActionExecutedContext context)
    {
        if (context.Exception is ItemNotFoundException)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(context.Exception.Message),
                ReasonPhrase = "ItemNotFound"
            };
            throw new HttpResponseException(resp);

        }
    }
}
}