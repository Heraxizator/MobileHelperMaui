using MobileHelperMaui.Application.Quots.Get;
using MobileHelperMaui.Domain.Abstractions;

namespace MobileHelperMaui.Application.Share
{
    public class CommandInvoker<Q>
    {
        private ICommand<Q> command;

        public CommandInvoker()
        {

        }

        public void SetCommand(ICommand<Q> command)
        {
            this.command = command;
        }

        public async Task<Q> Run()
        {
            Q result = await this.command.Execute();

            return result;
        }
    }
}
