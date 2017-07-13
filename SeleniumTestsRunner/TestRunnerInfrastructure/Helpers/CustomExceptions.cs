using System;
using System.Runtime.Serialization;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Helpers
{
    [Serializable]
    internal class MoreThanOneElementException : Exception
    {
        public MoreThanOneElementException()
        {
        }

        public MoreThanOneElementException(string message) : base(message)
        {
        }

        public MoreThanOneElementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MoreThanOneElementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}