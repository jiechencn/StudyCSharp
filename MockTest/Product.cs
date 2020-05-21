namespace MockTest
{
    public interface Product
    {
        string Name { get; set; }
        int SerialID { get; set; }

        string ReadOnlyString { get; }
    }

    public class Computer : Product
    {
        public string Name { get; set; }
        public int SerialID { get; set; }

        public string ReadOnlyString { get; }
    }

    public class Phone: Product
    {
        public string Name { get; set; }
        public int SerialID { get; set; }
        public string ReadOnlyString { get; }
    }
    public class Postcard: Product
    {
        public string Name { get; set; }
        public int SerialID { get; set; }
        public string ReadOnlyString { get; }
    }

}