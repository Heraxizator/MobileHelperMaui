using MobileHelperMaui.Domain.Abstractions;
using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Entities;
using MobileHelperMaui.Domain.Share;

namespace MobileHelperMaui.Application.Share.Command
{
    public class Command<T, Q> : ICommand<Q>
    {
        private readonly IHandler<T, Q> handler;
        private readonly IRepository<T> repository;

        public Command(IHandler<T, Q> handler, IRepository<T> repository)
        {
            this.handler = handler;
            this.repository = repository;
        }

        public async Task<Q> Execute()
        {
            Q result = await handler.Handle(repository);

            return result;
        }
    }
}
