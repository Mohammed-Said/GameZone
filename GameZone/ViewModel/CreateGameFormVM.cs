namespace GameZone.ViewModel
{
    public class CreateGameFormVM:GameFormVM
    {
        [AllowedExtention(FileSettings.AllowedExtentions)]
        [MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;

    }
}
