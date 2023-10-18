using FluentValidation;
using ProductsRegister.Business.Models;

namespace ProductsRegister.Business.Services
{
    public abstract class BaseService
    {
        protected bool ExecuteValidation<TValidation, TEntity>(TValidation validation, TEntity entity)
            where TValidation : AbstractValidator<TEntity>
            where TEntity : Entity
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid) return true;
            ///Lançamento de notificações
            ///
            return false;
        }

        protected void Notify(string message)
        {

        }
    }
}
