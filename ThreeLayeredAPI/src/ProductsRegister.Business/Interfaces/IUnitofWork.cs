namespace ProductsRegister.Business.Interfaces
{
    public interface IUnitofWork
    {
        Task<bool> Commit();
    }
}
