namespace GameZone.Models
{
    public class Device:BaseEntity
    {
        public string Icon { get; set; } = string.Empty;
        public ICollection<GameDevice> Games { get; set; } = new List<GameDevice>();

    }
}
