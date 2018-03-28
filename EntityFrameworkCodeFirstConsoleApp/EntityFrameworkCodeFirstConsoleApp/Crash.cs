using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirstConsoleApp
{
    public class Crash
    {
        [Key]
        public string CrashRef { get; set; }
        public string Location { get; set; }
        public Rocket Rocket { get; set; }
    }
}