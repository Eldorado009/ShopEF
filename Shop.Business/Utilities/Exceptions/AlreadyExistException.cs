// Make sure the Exception class is accessible by declaring it as public
namespace Shop.Business.Utilities.Exceptions
{
    // Declare the Exception class as public
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string message) : base(message) { }
    }
}
