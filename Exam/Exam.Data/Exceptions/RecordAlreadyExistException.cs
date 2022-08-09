namespace Exam.Data.Exceptions
{
    public class RecordAlreadyExistException : Exception
    {
        public RecordAlreadyExistException()
        {
        }

        public RecordAlreadyExistException(string message) : base(message)
        {
        }

        public RecordAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}