namespace PaymentServiceServer.Controllers
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    class ControllerAttribute : Attribute
    {
        public string Name { get; private set; }

        public ControllerAttribute(string name)
        {
            Name = name;
        }
    }
}
