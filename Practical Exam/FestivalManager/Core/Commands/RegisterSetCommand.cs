using FestivalManager.Core.Contracts;
using FestivalManager.Core.Controllers.Contracts;

namespace FestivalManager.Core.Commands
{
    public class RegisterSetCommand : ICommand
    {
        private IFestivalController festivalController;

        public RegisterSetCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public string Execute(string[] args)
        {
           return this.festivalController.RegisterSet(args);
        }
    }
}
