using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    class Globals
    {
        public static List<Die> Dice = new List<Die>();
        public static string[] UpperSectionNames = new String[] { "Aces", "Twos", "Threes", "Fours", "Fives", "Sixes" };
        public static string[] LowerSectionNames = new string[] { "3 of a Kind", "4 of a Kind", "Full House", "SM Straight", "LG Straight", "YAHTZEE", "Chance" };
        public static StringFormat sfLeft = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
        public static StringFormat sfCenter = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        public static StringFormat sfRight = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
        public static Random rnd = new Random();
        public static RegistryExtensions.RegistryEx Registry = new RegistryExtensions.RegistryEx(RegistryExtensions.RegistryEx.HKey.CurrentUser, "Shark In Seine", "Yahtzee");
        public static Variations LastVariation
        {
            get
            {
                //return Registry.GetValue<Variations>("General", "Variation", Variations.Original);
                return (Variations)(Registry.GetValue("General", "Variation", Variations.Original));
            }
            set
            {
                Registry.SetValue("General", "Variation", value);
            }
        }
        public static IEnumerable<string> LastPlayers
        {
            get
            {
                if (!LastPlayersHasBeenTested)
                {
                    List<string> Players = new List<string>(((string)(Registry.GetValue("General", "LastPlayers", Records.Players[0].PlayerName))).Split(',').Where(pn => Records.Players.Select(p => p.PlayerName).Contains(pn)));
                    if (Players.Count == 0)
                    {
                        Registry.SetValue("General", "LastPlayers", Records.Players.ElementAt(0).PlayerName);
                    }
                    else
                    {
                        Registry.SetValue("General", "LastPlayers", Players.Aggregate<string, string>("", (ag, s) => $"{ag},{s}").TrimStart(','));
                    }
                    LastPlayersHasBeenTested = true;
                }
                return ((string)(Registry.GetValue("General", "LastPlayers", Records.Players[0].PlayerName))).Split(',');
            }
            set
            {
                Registry.SetValue("General", "LastPlayers", value.Aggregate<string, string>("", (ag, s) => $"{ag},{s}").TrimStart(','));
            }
        }
        private static bool LastPlayersHasBeenTested = false;

        public enum Variations
        {
            Original,
            Bonus,
            Triple
        }
        public static Variations Variation = LastVariation;

        public static List<PlayerControl> NamePlates = new List<PlayerControl>();
    }
}
