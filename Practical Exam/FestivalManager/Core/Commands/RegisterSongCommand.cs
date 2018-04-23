using FestivalManager.Core.Contracts;
using FestivalManager.Core.Controllers.Contracts;

namespace FestivalManager.Core.Commands
{
    public class RegisterSongCommand : ICommand
    {
        private IFestivalController festivalController;

        public RegisterSongCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public string Execute(string[] args)
        {
            return this.festivalController.RegisterSong(args);
        }
    }
}
