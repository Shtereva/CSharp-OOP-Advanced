    public class PrintCommand : Command
    {
        [Inject]
        private IRepository weaponRepository;

    public PrintCommand(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            string name = this.Data[0];

           this.weaponRepository.Print(name);
        }
    }
