using FestivalManager.Entities.Factories.Contracts;

using System;
using System.Linq;
using System.Text;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Core.Controllers
{
    public class FestivalController : IFestivalController
    {
        private readonly IStage stage;

        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage, ISetFactory setFactory, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory, ISongFactory songFactory)
        {
            this.stage = stage;
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.songFactory = songFactory;
        }
        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            var set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return $"Registered {type} set";
        }

        public string ProduceReport()
        {
            var sb = new StringBuilder();

            var totalFestivalLength = TimeSpan.FromSeconds(this.stage.Sets.Sum(s => s.ActualDuration.TotalSeconds));

            sb.AppendLine("Results:");
            sb.AppendLine($"Festival length: {totalFestivalLength.TotalMinutes:00}:{totalFestivalLength.Seconds:00}");

            foreach (var stageSet in this.stage.Sets)
            {
                sb.AppendLine($"--{stageSet.Name} ({stageSet.ActualDuration.TotalMinutes:00}:{stageSet.ActualDuration.Seconds:00}):");

                var performers = stageSet.Performers
                    .OrderByDescending(p => p.Age)
                    .ToArray();

                foreach (var performer in performers)
                {
                    var instruments = string.Join(", ", performer.Instruments
                                .OrderByDescending(i => i.Wear));

                    sb.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!stageSet.Songs.Any())
                {
                    sb.AppendLine($"--No songs played");
                }

                else
                {
                    sb.AppendLine("--Songs played:");
                    foreach (var song in stageSet.Songs)
                    {
                        sb.AppendLine("----" + song);
                    }
                }
            }

            return sb.ToString().Trim();
        }
        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumentsNames = args.Skip(2).ToArray();

            var instruments = instrumentsNames
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            var minutesAndSeconds = args[1]
                .Split(":")
                .Select(int.Parse)
                .ToArray();

            TimeSpan duration = TimeSpan.FromSeconds((minutesAndSeconds[0] * 60) + minutesAndSeconds[1]);

            var song = this.songFactory.CreateSong(name, duration);
            this.stage.AddSong(song);

            return $"Registered song {name} ({duration.TotalMinutes:00}:{duration.Seconds:00})";
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];


            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration.TotalMinutes:00}:{song.Duration.Seconds:00}) to {setName}";
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
    }
}