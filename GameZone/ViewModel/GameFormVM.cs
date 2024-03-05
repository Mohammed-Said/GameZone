namespace GameZone.ViewModel
{
    public class GameFormVM
    {
        [MaxLength(250)]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;


        [Display(Name = "Category")]
        public List<int> SelectedCategories { get; set; } = default!;
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
