
namespace GameZone.Servises
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagePath;

        public GameService(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagePath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }

        public IEnumerable<Game> GetAll() =>
            _context.Games
            .Include(game => game.Categories)
            .ThenInclude(c => c.Category)
            .Include(game => game.Devices)
            .ThenInclude(d => d.Device)
            .AsNoTracking().ToList();

        public Game? GetById(int id) =>
            _context.Games
            .Include(game => game.Categories)
            .ThenInclude(c => c.Category)
            .Include(game => game.Devices)
            .ThenInclude(d => d.Device)
            .AsNoTracking()
            .FirstOrDefault(game => game.Id == id)
            ;


        public async Task Create(CreateGameFormVM model)
        {

            Game game = new Game()
            {
                Name = model.Name,
                Description = model.Description,
                Cover = await saveCover(model.Cover),
                Devices = model.SelectedDevices.Select(d => new GameDevice() { DeviceId = d }).ToList(),
                Categories = model.SelectedCategories.Select(c => new GameCategory() { CategoryId = c }).ToList(),
            };
            _context.Add(game);
            _context.SaveChanges();

        }
        public async Task<Game?> Update(EditGameFormVM model)
        {
            Game? game = _context.Games
                .Include(g=>g.Categories)
                .Include(g=>g.Devices)
                .SingleOrDefault(g=>g.Id==model.Id);

            if (game == null)
                return null;

            bool hasNewCover = model.Cover is not null;
            string oldCover = game.Cover;

            if (hasNewCover)
                game.Cover = await saveCover(model.Cover!);

            game.Name = model.Name;
            game.Description = model.Description;
            game.Devices = model.SelectedDevices.Select(d => new GameDevice() { DeviceId = d }).ToList();
            game.Categories = model.SelectedCategories.Select(c => new GameCategory() { CategoryId = c }).ToList();


            int effectRows = _context.SaveChanges();
            if (effectRows > 0)
            {
                if (hasNewCover)
                {
                    var Cover = Path.Combine(_imagePath, oldCover);
                    File.Delete(Cover);
                }
                return game;
            }
            else
            {
                var Cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(Cover);
                return null;
            }

        }

        public bool Delete(int id)
        {
            Game? game = _context.Games.Find(id);
            if (game == null) return false;

            _context.Games.Remove(game);
            int effectedRow= _context.SaveChanges();
            if (effectedRow > 0)
            {
                var Cover=Path.Combine(_imagePath, game.Cover);
                File.Delete(Cover);
            }
            return true;
        }
        private async Task<string> saveCover(IFormFile cover)
        {
            //Generate Unigue Name 
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            //Path+image Name
            var path = Path.Combine(_imagePath, coverName);
            //Save into Images folder
            using var Stream = File.Create(path);
            await cover.CopyToAsync(Stream);
            return coverName;
        }
    }
}
