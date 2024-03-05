namespace GameZone.ViewModel
{
    public class EditGameFormVM:GameFormVM
    {
        public int Id { get; set; }
        public string? CoverPath { get; set; }
        [AllowedExtention(FileSettings.AllowedExtentions)]
        [MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; }
    }
}
