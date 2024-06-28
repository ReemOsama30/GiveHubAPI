
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Entities;


namespace charityPulse.core.Models
{
    public class Badge:IsoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsDeleted { get; set; }

        public List<AwardedBadge> AwardedBadges { get; set;} = new List<AwardedBadge>();

    }
}
