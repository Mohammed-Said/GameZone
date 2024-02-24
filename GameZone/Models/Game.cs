
namespace GameZone.Models
{
    public class Game:BaseEntity
    {
       
        public string Description { get; set; }=String.Empty;
        public string Cover { get; set; }=String.Empty;

        //public List<Category>? Categories { get; set; }
        //public ICollection<Device>? Devices { get; set; }
        


    }
}
