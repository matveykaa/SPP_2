namespace FakerTests.TestClasses
{
    public class ClassConstructedWithParameters
    {
        public string stringValue;
        public double b;

        public ClassConstructedWithParameters(string _stringValue, double _b) 
        { 
            stringValue = _stringValue;
            b = _b;
        }
    }
}
