

namespace GameZone.Models
{
    public class Category:BaseEntity
    {
        public ICollection<GameCategory> Games { get; set; } = new List<GameCategory>();
    }
}
