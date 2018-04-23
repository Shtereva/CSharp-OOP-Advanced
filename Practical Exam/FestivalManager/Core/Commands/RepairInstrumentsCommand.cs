using FestivalManager.Core.Contracts;
using FestivalManager.Core.Controllers.Contracts;

namespace FestivalManager.Core.Commands
{
    public class RepairInstrumentsCommand : ICommand
    {
        private IFestivalController festivalController;

        public RepairInstrumentsCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public string Execute(string[] args)
        {
            return this.festivalController.RepairInstruments(args);
        }
    }
}
