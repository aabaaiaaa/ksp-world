using System.ComponentModel.DataAnnotations;

namespace Kerbal.Data
{
    public class Mission
    {
        [Key]
        public string Ref { get; set; }
        public string TargetPlanet { get; set; }
    }
}