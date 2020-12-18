using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App.Core.BusinessExceptions
{
   public class BusinessRuleException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<object> Errors  { get; set; }
        public BusinessRuleException(String message):base(message)
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }

        public BusinessRuleException(String message, HttpStatusCode httpStatusCode  ) 
            : base(message)
        {
            this.StatusCode = httpStatusCode;
        }

        public BusinessRuleException(String message, List<object> Errors, HttpStatusCode httpStatusCode) 
            : base(message)
        {
            this.StatusCode = httpStatusCode;
            this.Errors = Errors;
        }

        public BusinessRuleException(String message, List<object> Errors) : base(message)
        {
            this.StatusCode = HttpStatusCode.BadRequest;
            this.Errors = Errors;
        }

    }
}
