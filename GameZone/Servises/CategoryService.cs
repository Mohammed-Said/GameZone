
namespace GameZone.Servises
{
    public class CategoryService : ICategoryService
    {

        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context) => _context = context;
        public IEnumerable<SelectListItem> GetCategories() =>
            _context.Categories
                    .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name })
                    .OrderBy(c => c.Text)
                    .AsNoTracking()
                    .ToList();
    }
}
