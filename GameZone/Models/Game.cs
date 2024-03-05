
namespace GameZone.Models
{
    public class Game:BaseEntity
    {
       
        public string Description { get; set; }=String.Empty;
        public string Cover { get; set; }=String.Empty;

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();
        public ICollection<GameCategory> Categories { get; set; } = new List<GameCategory>();

    }
}
