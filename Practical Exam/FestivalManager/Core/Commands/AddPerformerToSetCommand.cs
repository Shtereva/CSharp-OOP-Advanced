using FestivalManager.Core.Contracts;
using FestivalManager.Core.Controllers.Contracts;

namespace FestivalManager.Core.Commands
{
    public class AddPerformerToSetCommand : ICommand
    {
        private IFestivalController festivalController;

        public AddPerformerToSetCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public string Execute(string[] args)
        {
            return this.festivalController.AddPerformerToSet(args);
        }
    }
}
