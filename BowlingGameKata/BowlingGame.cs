using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata {
    public class BowlingGame {

        private const int SPARE = 10;
        private const int STRIKE = 10;
        private bool frameIsSpare(int frame) => frameScore(frame) == SPARE;
        private bool ballStrikes(int ball) => balls[ball] == STRIKE;
        private int frameScore(int ball) => balls[ball] + balls[ball + 1];
        private int spareScore(int ball) => SPARE + balls[ball + 2];
        private int strikeScore(int ball) => STRIKE + balls.GetRange(ball + 1, 2).Sum();

        public List<int> balls = new List<int>();
        public void scorePins(int pins) => balls.Add(pins);

        public int score {
            get {
                int _score = 0;
                int _frames = 0;
                for (int ball = 0; _frames < 10; ball++, _frames++) {
                    _score += scoreFrame(ref ball);
                }
                return _score;
            }
        }

        private int scoreFrame(ref int ball) {
            if (ballStrikes(ball)) return strikeScore(ball);
            return (frameIsSpare(ball)) ? spareScore(ball++) : frameScore(ball++);
        }
    }
}