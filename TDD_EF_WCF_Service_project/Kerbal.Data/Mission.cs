using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kerbal.Data
{
    public class Mission
    {
        [ForeignKey("Kerbal")]
        public int MissionId { get; set; }
        public string Ref { get; set; }
        public string TargetPlanet { get; set; }

        public virtual Kerbal Kerbal { get; set; }
    }
}