using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniWeibo.Net.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    using Hammock;

    public class WeiboResponse
    {
        /// <summary>
        /// Http response.
        /// </summary>
        private readonly RestResponseBase _response;

        /// <summary>
        /// The exception.
        /// </summary>
        private readonly Exception _exception;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeiboResponse"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="exception">The exception.</param>
        internal WeiboResponse(RestResponseBase response, Exception exception)
        {
            _response = response;
            _exception = exception;
        }

        public virtual string Response
        {
            get
            {
                return _response.Content;
            }
        }

        public virtual HttpStatusCode StatusCode
        {
            get
            {
                return _response.StatusCode;
            }

            set
            {
                _response.StatusCode = value;
            }
        }

        public virtual Exception InnerException
        {
            get { return _exception ?? _response.InnerException; }
        }

        internal WeiboResponse()
        {
        }
    }
}