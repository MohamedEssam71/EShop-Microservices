namespace BuildingBlocks.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        { }
        public NotFoundException(string key, object value) : base($"Entity \"{key}\" ({value}) was not found.")
        { }
    }
}
