using FestivalManager.Core.Contracts;
using FestivalManager.Core.Controllers.Contracts;

namespace FestivalManager.Core.Commands
{
    public class LetsRockCommand : ICommand
    {
        private ISetController setController;

        public LetsRockCommand(ISetController setController)
        {
            this.setController = setController;
        }

        public string Execute(params string[] args)
        {
            return this.setController.PerformSets();
        }
    }
}
