namespace Shop.Business.Utilities.Exceptions
{
    // Declare the NotFoundException class as public and inherit from Exception
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
