namespace GameZone.Validation
{
    public class AllowedExtentionAttribute : ValidationAttribute
    {
        private readonly string _allowedExtentions;

        public AllowedExtentionAttribute(string allowedExtentions)
        {
            _allowedExtentions = allowedExtentions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);
                bool isAllowed = _allowedExtentions.Split(',').Contains(extension,StringComparer.OrdinalIgnoreCase);
                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtentions} are allowed!");
                }

            }
            return ValidationResult.Success;
        }
    }
}
