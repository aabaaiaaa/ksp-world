namespace EntityFrameworkCodeFirstConsoleApp
{
    public class Rocket
    {
        // For EF to set the primary key
        public int RocketId { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}