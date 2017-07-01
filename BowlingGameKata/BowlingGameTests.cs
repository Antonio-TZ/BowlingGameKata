using NUnit.Framework;

namespace BowlingGameKata {
    [TestFixture]
    public class BowlingGameShould {

        BowlingGame bowlingGame;

        [SetUp]
        public void initialise() {
            bowlingGame = new BowlingGame();
        }

        [Test]
        public void return_0_score_for_gutter_game() {
            rollMany(20, 0);
            Assert.AreEqual(0, bowlingGame.score);
        }

        [Test]
        public void return_20_score_for_all_1s() {
            rollMany(20, 1);
            Assert.AreEqual(20, bowlingGame.score);
        }

        [Test]
        public void score_spares_correctly() {
            rollMany(2, 5);
            bowlingGame.scorePins(3);
            rollMany(17, 0);
            Assert.AreEqual(16, bowlingGame.score);
        }

        [Test]
        public void score_strikes_correctly() {
            bowlingGame.scorePins(10);
            bowlingGame.scorePins(3);
            bowlingGame.scorePins(4);
            rollMany(16, 0);
            Assert.AreEqual(24, bowlingGame.score);
        }

        [Test]
        public void score_is_300_for_perfect_game() {
            rollMany(12, 10);
            Assert.AreEqual(300, bowlingGame.score);
        }

        private void rollMany(int rolls, int pins) {
            for (int i = 0; i < rolls; i++) {
                bowlingGame.scorePins(pins);
            }
        }
    }
}
