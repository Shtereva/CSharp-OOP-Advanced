using FestivalManager.Core.Contracts;
using FestivalManager.Core.Controllers.Contracts;

namespace FestivalManager.Core.Commands
{
    public class SignUpPerformerCommand : ICommand
    {
        private IFestivalController festivalController;

        public SignUpPerformerCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public string Execute(string[] args)
        {
           return this.festivalController.SignUpPerformer(args);
        }
    }
}
