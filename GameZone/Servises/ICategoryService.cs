namespace GameZone.Servises
{
    public interface ICategoryService
    {
        IEnumerable<SelectListItem> GetCategories();
    }
}
