namespace CalibrationTracking.Shared
{
    public enum ErrorCode
    {
        /// <summary>
        /// The not found
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// The server error
        /// </summary>
        ServerError = 500,

        /// <summary>
        /// The bad request
        /// </summary>
        BadRequest = 400,

        AlreadyExists = 501,
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        /// <summary>
        ///
        /// </summary>

        /// <summary>
        ///
        /// </summary>
        public class Error
        {
            /// <summary>
            /// Gets or sets the code.
            /// </summary>
            /// <value>
            /// The code.
            /// </value>
            public ErrorCode Code { get; set; }

            /// <summary>
            /// Gets or sets the message.
            /// </summary>
            /// <value>
            /// The message.
            /// </value>
            public string Message { get; set; } = null!;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        public Result()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Result(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public List<Error> Errors { get; internal set; } = new();

        /// <summary>
        /// Gets a value indicating whether this instance is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is error; otherwise, <c>false</c>.
        /// </value>
        public bool IsError { get; private set; } = false;

        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="Message">The message.</param>
        public void AddError(ErrorCode code, string Message)
        {
            IsError = true;
            Errors.Add(new Error { Code = code, Message = Message });
        }

        /// <summary>
        /// Adds the server error.
        /// </summary>
        /// <param name="Message">The message.</param>
        public void AddServerError(string Message)
        {
            IsError = true;
            Errors.Add(new Error { Code = ErrorCode.ServerError, Message = Message });
        }

        /// <summary>
        /// Resets the state of the error.
        /// </summary>
        public void ResetErrorState()
        {
            IsError = false;
        }
    }
}