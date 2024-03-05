namespace GameZone.Servises
{
    public interface IGameService
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create(CreateGameFormVM vm);
        Task<Game?> Update(EditGameFormVM vm);
        public bool Delete(int id);
    }
}
