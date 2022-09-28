using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    public class GameScore
    {
        public enum LowerSectionLineItems
        {
            ThreeOfAKind,
            FourOfAKind,
            FullHouse,
            SmallStraight,
            LargeStraight,
            Yahtzee,
            Chance
        }
        public int[] UpperSection = new int[6];
        public bool[] ScoredUpperSection = new bool[6];
        public int[] LowerSection = new int[7];
        public bool[] ScoredLowerSection = new bool[7];

        public bool UseBonusYahtzees;
        public int BonusYahtzees = 0;

        public void Clear()
        {
            Array.Clear(UpperSection, 0, 6);
            Array.Clear(LowerSection, 0, 7);
            BonusYahtzees = 0;
        }

        public void AddUpperScore(int LineItem)
        {
            UpperSection[LineItem] = CalculateUpperScore(LineItem);
            ScoredUpperSection[LineItem] = true;
            if (IsYahtzee() && LowerSection[(int)LowerSectionLineItems.Yahtzee] == 50)
            {
                BonusYahtzees += 1;
            }
        }

        public void AddLowerScore(LowerSectionLineItems LineItem)
        {
            LowerSection[(int)LineItem] = CalculateLowerScore(LineItem);
            ScoredLowerSection[(int)LineItem] = true;
            if (LineItem != LowerSectionLineItems.Yahtzee && LowerSection[(int)LowerSectionLineItems.Yahtzee] == 50 && IsYahtzee())
            {
                {
                    BonusYahtzees += 1;
                }
            }
        }

        public int CalculateUpperScore(int LineItem)
        {
            LineItem++;
            return LineItem * Globals.Dice.Count(d => d.Value == LineItem);
        }

        public int CalculateLowerScore(LowerSectionLineItems LineItem)
        {
            int Score = 0;
            switch (LineItem)
            {
                case LowerSectionLineItems.ThreeOfAKind:
                    if (Globals.Dice.GroupBy(d => d.Value).Any(g => g.Count() >= 3))
                    {
                        Score = Globals.Dice.Sum(d => d.Value);
                    }
                    break;
                case LowerSectionLineItems.FourOfAKind:
                    if (Globals.Dice.GroupBy(d => d.Value).Any(g => g.Count() >= 4))
                    {
                        Score = Globals.Dice.Sum(d => d.Value);
                    }
                    break;
                case LowerSectionLineItems.FullHouse:
                    var grouped = Globals.Dice.GroupBy(d => d.Value).OrderByDescending(g => g.Count());
                    if (grouped.Count() == 2 && grouped.ElementAt(0).Count() == 3)
                    {
                        Score = 25;
                    }
                    break;
                case LowerSectionLineItems.SmallStraight:
                    if (IsYahtzee() && LowerSection[(int)LowerSectionLineItems.Yahtzee] == 50 && ScoredUpperSection[Globals.Dice[0].Value-1])
                    {
                        Score = 30;
                    }
                    else
                    {
                        IEnumerable<IGrouping<int, int>> ssGroups = Globals.Dice.Select(d => d.Value).Distinct().OrderBy(v => v).GroupBy(v => v);
                        if (ssGroups.Count() >= 4)
                        {
                            IEnumerable<int> Values = ssGroups.SelectMany(g => g);
                            if (Values.ElementAt(3) - Values.ElementAt(0) == 3 || (ssGroups.Count() > 4 && Values.ElementAt(4) - Values.ElementAt(1) == 3))
                            {
                                Score = 30;
                            }
                        }
                    }
                    break;
                case LowerSectionLineItems.LargeStraight:
                    if (IsYahtzee() && LowerSection[(int)LowerSectionLineItems.Yahtzee] == 50 && ScoredUpperSection[Globals.Dice[0].Value-1])
                    {
                        Score = 40;
                    }
                    else
                    {
                        IEnumerable<IGrouping<int, int>> lsGroups = Globals.Dice.Select(d => d.Value).Distinct().OrderBy(v => v).GroupBy(v => v);
                        if (lsGroups.Count() == 5)
                        {
                            int SumOfDice = Globals.Dice.Sum(d => d.Value);
                            if (SumOfDice == 15 || SumOfDice == 20)
                            {
                                Score = 40;
                            }
                        }
                    }
                    break;
                case LowerSectionLineItems.Yahtzee:
                    if (IsYahtzee())
                    {
                        Score = 50;
                    }
                    break;
                case LowerSectionLineItems.Chance:
                    Score = Globals.Dice.Sum(d => d.Value);
                    break;
            }
            return Score;
        }

        private static bool IsYahtzee()
        {
            return Globals.Dice.GroupBy(d => d.Value).Count() == 1;
        }

        public bool UpperSectionIsFilled()
        {
            return ScoredUpperSection.All(us => us);
        }
        public bool LowerSectionIsFilled()
        {
            return ScoredLowerSection.All(ls => ls);
        }
        public bool GameIsCompleted()
        {
            return UpperSectionIsFilled() && LowerSectionIsFilled();
        }

        public int UpperBonus
        {
            get
            {
                if (UpperSection.Sum() >= 63)
                {
                    return 35;
                }
                return 0;
            }
        }
        public int UpperScoreWithoutBonus
        {
            get
            {
                return UpperSection.Sum();
            }
        }
        public int UpperScoreWithBonus
        {
            get
            {
                return UpperSection.Sum() + UpperBonus;
            }
        }
        public int YahtzeeBonus
        {
            get
            {
                if (UseBonusYahtzees)
                {
                    return 100 * BonusYahtzees;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int LowerScore
        {
            get
            {
                return LowerSection.Sum();
            }
        }
        public int GrandTotal
        {
            get
            {
                return UpperScoreWithBonus + LowerScore;
            }
        }

        public GameScore Clone()
        {
            return (GameScore)MemberwiseClone();
        }
    }
}
