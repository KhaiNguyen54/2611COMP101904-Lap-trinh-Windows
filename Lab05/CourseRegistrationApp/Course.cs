namespace CourseRegistrationApp
{
    public class Course
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public override string ToString() { return Name; }
    }
}