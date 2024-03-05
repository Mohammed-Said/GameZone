namespace GameZone.Validation
{
    public class MaxFileSizeAttribute:ValidationAttribute
    {
        private readonly int maxSize;

        public MaxFileSizeAttribute(int maxSize)
        {
            this.maxSize = maxSize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                
                if (file.Length>maxSize)
                {
                    return new ValidationResult($"Maximum allowed size is {maxSize/1024} KB");
                }

            }
            return ValidationResult.Success;
        }
    }
}
