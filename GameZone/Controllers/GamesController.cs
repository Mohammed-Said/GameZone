

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly AppDbContext context;
        private readonly ICategoryService categoryService;
        private readonly IDevicesService devicesService;
        private readonly IGameService gameService;

        public GamesController(AppDbContext context, ICategoryService categoryService, IDevicesService devicesService, IGameService gameService)
        {
            this.context = context;
            this.categoryService = categoryService;
            this.devicesService = devicesService;
            this.gameService = gameService;
        }

        public IActionResult Index() =>
            View(gameService.GetAll());

        public IActionResult Details(int id)
        {
            Game? game = gameService.GetById(id);
            if (game == null)
                return NotFound();

            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var Categories = categoryService.GetCategories();
            var Devices = devicesService.GetDevices();
            CreateGameFormVM vm = new CreateGameFormVM()
            {
                Categories = Categories,
                Devices = Devices,

            };

            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(CreateGameFormVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = categoryService.GetCategories();
                model.Devices = devicesService.GetDevices();

                return View(model);
            }

            await gameService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Game? game = gameService.GetById(id);
            if (game == null)
                return NotFound();

            EditGameFormVM vm = new EditGameFormVM()
            {
                Categories = categoryService.GetCategories(),
                Devices = devicesService.GetDevices(),
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                SelectedCategories = game.Categories.Select(c => c.CategoryId).ToList(),
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                CoverPath = game.Cover
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(EditGameFormVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = categoryService.GetCategories();
                model.Devices = devicesService.GetDevices();

                return View(model);
            }

            var game = await gameService.Update(model);
            if (game == null)
                return BadRequest();
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            
            bool isDelted = gameService.Delete(id);

            return isDelted ? Ok() : BadRequest();
        }
    }
}
