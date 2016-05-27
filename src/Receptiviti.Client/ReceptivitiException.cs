using System;
using System.Diagnostics.Contracts;
using System.Net;

namespace Receptiviti.Client
{

    /// <summary>
    /// Describes an exception interacting with the Receptiviti service.
    /// </summary>
    public class ReceptivitiException :
        Exception
    {

        readonly HttpStatusCode statusCode;
        readonly ReceptivitiError error;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ReceptivitiException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="innerException"></param>
        public ReceptivitiException(Exception innerException)
            : base(innerException.Message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public ReceptivitiException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            this.statusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="error"></param>
        public ReceptivitiException(HttpStatusCode statusCode, ReceptivitiError error)
            : base(error.Message)
        {
            Contract.Requires<ArgumentNullException>(error != null);

            this.statusCode = statusCode;
            this.error = error;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="error"></param>
        /// <param name="innerException"></param>
        public ReceptivitiException(HttpStatusCode statusCode, ReceptivitiError error, Exception innerException)
            : base(error.Message, innerException)
        {
            Contract.Requires<ArgumentNullException>(error != null);

            this.statusCode = statusCode;
            this.error = error;
        }

        /// <summary>
        /// Status code of failed request.
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get { return statusCode; }
        }

        /// <summary>
        /// Error from Receptiviti.
        /// </summary>
        public ReceptivitiError Error
        {
            get { return error; }
        }

    }

}
