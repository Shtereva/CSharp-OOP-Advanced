//Use this file for your unit tests.
//When you are ready to submit, REMOVE all using statements to your project(entities/controllers/etc)

using System;
using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void Test()
        {
            Assert.Pass();
        }

        [Test]
        public void PerformCommandReturnsSuccessResult()
        {
            IStage stage = new Stage();
            ISet set = new Short("Set1");

            TimeSpan duration = TimeSpan.FromSeconds((1 * 60) + 2);
            ISong song = new Song("Song1", duration);

            IPerformer performer = new Performer("Gosho", 20);
            performer.AddInstrument(new Guitar());

            set.AddPerformer(performer);
            set.AddSong(song);

            stage.AddSong(song);

            stage.AddSet(set);
            stage.AddSong(song);
            stage.AddPerformer(performer);

            ISetController setController = new SetController(stage);

            string actual = "1. Set1:\r\n-- 1. Song1 (01:02)\r\n-- Set Successful";
            string expected = setController.PerformSets();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void TestInstrumentsGetBroken()
        {
            IStage stage = new Stage();
            ISet set = new Short("Set1");

            TimeSpan duration = TimeSpan.FromSeconds((1 * 60) + 2);
            ISong song = new Song("Song1", duration);

            IPerformer performer = new Performer("Gosho", 20);

            IInstrument instrument = new Guitar();
            instrument.WearDown();
            instrument.WearDown();

            performer.AddInstrument(instrument);

            set.AddPerformer(performer);
            set.AddSong(song);

            stage.AddSong(song);

            stage.AddSet(set);
            stage.AddSong(song);
            stage.AddPerformer(performer);

            ISetController setController = new SetController(stage);

            string actual = "1. Set1:\r\n-- Did not perform";
            string expected = setController.PerformSets();

            Assert.AreEqual(actual, expected);
        }
    }
}