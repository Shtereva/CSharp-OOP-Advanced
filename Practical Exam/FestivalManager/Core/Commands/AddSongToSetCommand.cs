using FestivalManager.Core.Contracts;
using FestivalManager.Core.Controllers.Contracts;

namespace FestivalManager.Core.Commands
{
    public class AddSongToSetCommand : ICommand
    {
        private IFestivalController festivalController;

        public AddSongToSetCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public string Execute(string[] args)
        {
            return this.festivalController.AddSongToSet(args);
        }
    }
}
