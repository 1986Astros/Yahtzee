using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    class Records
    {
        public static void ReadRecords()
        {
            int Version = 0;
            if (System.IO.File.Exists(RecordsPath()))
            {
                using (DataSet ds = new DataSet())
                {
                    DataTable dt;

                    ds.ReadXml(RecordsPath());

                    if (ds.Tables.Contains("Header"))
                    {
                        dt = ds.Tables["Header"];
                        foreach (DataRow dr in dt.Rows)
                        {
                            switch (dr["Name"])
                            {
                                case "Version":
                                    Version = Convert.ToInt32(dr["Value"]);
                                    break;
                            }
                        }
                    }

                    if (ds.Tables.Contains("Players"))
                    {
                        dt = ds.Tables["Players"];

                        // get the players
                        foreach (DataRow dr in dt.Rows)
                        {
                            Players.Add(PlayerInfo.FromDataRow(dr));
                        }
                    }
                }
            }
            if (Players.Count == 0)
            {
                AddPlayer("Guest");
            }
        }
        public static void WriteRecords()
        {
            DataRow dr;
            using (DataSet ds = new DataSet("LeaderBoard"))
            {
                using (DataTable  dt = new DataTable("Header"))
                {
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Value");

                    dr = dt.NewRow();
                    dr["Name"] = "Version";
                    dr["Value"] = 0;
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
                using (DataTable dt = new DataTable("Players"))
                {
                    PlayerInfo.AddPlayerInfoColumns(dt);
                    foreach (PlayerInfo pi in Players)
                    {
                        dt.Rows.Add(pi.ToDataRow(dt.NewRow()));
                    }
                    ds.Tables.Add(dt);
                }
                ds.WriteXml(RecordsPath(), XmlWriteMode.WriteSchema);
            }
        }
        public static string RecordsPath()
        {
            return System.IO.Path.Combine(Application.UserAppDataPath, "Records.xml");
        }

        public static List<PlayerInfo> Players = new List<PlayerInfo>();
        public static PlayerInfo Player(string Name)
        {
            return Players.FirstOrDefault(p => p.PlayerName.Equals(Name, StringComparison.CurrentCultureIgnoreCase));
        }
        public static PlayerInfo Player(int ID)
        {
            return Players.FirstOrDefault(p => p.ID == ID);
        }

        public class PlayerInfo
        {
            public string PlayerName;
            public int ID;
            public int[][] BestScores = { new int[10], new int[10], new int[10] };
            public DateTime[][] BestScoresWhen = { new DateTime[10], new DateTime[10], new DateTime[10] };
            public long[] TotalScores = new long[3];
            public int[] GameCount = new int[3];
            public Color TableColor = Color.ForestGreen;
            public Color DieColor= Color.Red;
            public Color PipColor = Color.White;
            public bool ConfirmPlay = false;
            public DataRow ToDataRow(DataRow dr)
            {
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(Color));
                dr["Name"] = PlayerName;
                dr["ID"] = ID;
                dr["TableColor"] = tc.ConvertToString(TableColor);
                dr["DieColor"] = tc.ConvertToString(DieColor);
                dr["PipColor"] = tc.ConvertToString(PipColor);
                dr["ConfirmPlay"] = ConfirmPlay.ToString();
                int[] IntList;
                DateTime[] DTList;
                for (int version = 0; version < 3; version++)
                {
                    IntList = BestScores[version];
                    dr[$"BestScore{version}"] = IntList.Select(s => s.ToString()).Aggregate<string>((ag, bs) => $"{ag},{bs}").Trim(',');
                    DTList = BestScoresWhen[version];
                    dr[$"BestWhen{version}"] = DTList.Select(dt => dt != null ? dt.ToShortDateString() : "").Aggregate<string>((ag, dt) => $"{ag}|{dt}");
                    dr[$"TotalScore{version}"] = TotalScores[version];
                    dr[$"GameCount{version}"] = GameCount[version];
                }
                return dr;
            }
            public static PlayerInfo FromDataRow(DataRow dr)
            {
                PlayerInfo pi = new PlayerInfo();
                pi.PlayerName = dr["Name"].ToString();
                pi.ID = Convert.ToInt32(dr["ID"]);
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(Color));
                pi.TableColor = (Color)tc.ConvertFromString(dr["TableColor"].ToString());
                pi.DieColor = (Color)tc.ConvertFromString(dr["DieColor"].ToString());
                pi.PipColor = (Color)tc.ConvertFromString(dr["PipColor"].ToString());
                pi.ConfirmPlay = Convert.ToBoolean(dr["ConfirmPlay"]);
                int idx;
                for (int version = 0; version < 3; version++)
                {
                    idx = 0;
                    foreach (int score in dr[$"BestScore{version}"].ToString().Split(',').Select(bs => Convert.ToInt32(bs)))
                    {
                        pi.BestScores[version][idx++] = score;
                    }
                    idx = 0;
                    foreach (DateTime when in dr[$"BestWhen{version}"].ToString().Split('|').Select(dt => Convert.ToDateTime(dt)))
                    {
                        pi.BestScoresWhen[version][idx++] = when;
                    }
                    pi.TotalScores[version] = Convert.ToInt64(dr[$"TotalScore{version}"]);
                    pi.GameCount[version] = Convert.ToInt32(dr[$"GameCount{version}"]);
                }
                return pi;
            }
            public static void AddPlayerInfoColumns(DataTable dt)
            {
                dt.Columns.Add("Name");
                dt.Columns.Add("ID");
                dt.Columns.Add("TableColor");
                dt.Columns.Add("DieColor");
                dt.Columns.Add("PipColor");
                dt.Columns.Add("ConfirmPlay");
                for (int version = 0; version < 3; version++)
                {
                    dt.Columns.Add($"BestScore{version}");
                    dt.Columns.Add($"BestWhen{version}");
                    dt.Columns.Add($"TotalScore{version}");
                    dt.Columns.Add($"GameCount{version}");
                }
            }

            public override string ToString()
            {
                return $"{ID:N4} {PlayerName}";
            }
        }
        public static PlayerInfo AddPlayer(string Name)
        {
            if (Players.Any(p => p.PlayerName.Equals(Name, StringComparison.CurrentCultureIgnoreCase)))
            {
                return null;
            }
            int NextID = Players.Count > 0 ? Players.Max(p => p.ID) + 1 : 0;
            PlayerInfo pi = new PlayerInfo() { PlayerName = Name, ID = NextID };
            Players.Add(pi);
            return pi;
        }
        public static bool AddGamePlayed(int ID,  int Score)
        {
            PlayerInfo pi = Players.First(p => p.ID == ID);
            int LeftIndex = (int)Globals.Variation;
            bool NewHighScore = false;
            if (Score > pi.BestScores[LeftIndex].Last())
            {
                List<int> scores = new List<int>(pi.BestScores[LeftIndex]);
                List<DateTime> whens = new List<DateTime>(pi.BestScoresWhen[LeftIndex]);
                int Position = scores.Take(10).TakeWhile(p => p >= Score).Count();
                scores.Insert(Position, Score);
                Array.Copy(scores.ToArray(), pi.BestScores[LeftIndex], 10);
                whens.Insert(Position, DateTime.Now);
                Array.Copy(whens.ToArray(), pi.BestScoresWhen[LeftIndex], 10);
                NewHighScore = true;
            }
            pi.TotalScores[LeftIndex] += (long)Score;
            pi.GameCount[LeftIndex] ++;
            return NewHighScore;
        }

        public class HighScoreInfo
        {
            public string Name;
            public int Score;
            public DateTime When;
            public float Average;
        }

        public static bool LoadHighScores( out IEnumerable<HighScoreInfo> OrderedList, out float avg)
        {
            int LeftIndex = (int)Globals.Variation;
            List<HighScoreInfo> AllScores = new List<HighScoreInfo>();
            foreach (PlayerInfo pi in Players)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (pi.BestScores[LeftIndex][i] > 0)
                    {
                        AllScores.Add(new HighScoreInfo() { Name = pi.PlayerName, Score = pi.BestScores[LeftIndex][i], When = pi.BestScoresWhen[LeftIndex][i], Average = ((float)(Convert.ToDouble(pi.TotalScores[LeftIndex]) / Convert.ToDouble(pi.GameCount[LeftIndex]))) });
                    }
                    else
                    {
                        break;
                    }
                }
            }
            OrderedList = AllScores.OrderByDescending(hs => hs.Score).Take(10);
            avg = LoadLeagueAverage();
            return true;
        }
        public static float LoadLeagueAverage()
        {
            int LeftIndex = (int)Globals.Variation;
            int TotalGames = Players.Sum(p => p.GameCount[LeftIndex]);
            if (TotalGames > 0)
            {
                return (float)((Convert.ToDouble(Players.Sum(p => p.TotalScores[LeftIndex])) / Convert.ToSByte(TotalGames)));
            }
            else
            {
                return 0;
            }
        }
    }
}
