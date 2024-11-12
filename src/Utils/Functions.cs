namespace LilyFNServer.Utils
{
    public struct FortniteVersionInfo
    {
        public FortniteVersionInfo(int season, double build, string CL, string lobby)
        {
            this.season = season;
            this.build = build;
            this.CL = CL;
            this.lobby = lobby;
        }

        public int season { get; set; }
        public double build { get; set; }
        public string CL { get; set; }
        public string lobby { get; set; }
    }

    public class Functions
    {
        public static FortniteVersionInfo GetVersionInfo(HttpRequest req)
        {
            FortniteVersionInfo info = new FortniteVersionInfo(0, 0.0, "0", "");

            if (!string.IsNullOrEmpty(req.Headers["user-agent"].ToString()))
            {
                string CL = "";

                try
                {
                    string BuildID = req.Headers["user-agent"].ToString().Split("-")[3].Split(",")[0];

                    if (!Double.IsNaN(Convert.ToDouble(BuildID))) CL = BuildID;
                    else
                    {
                        BuildID = req.Headers["user-agent"].ToString().Split("-")[3].Split(" ")[0];

                        if (!Double.IsNaN(Convert.ToDouble(BuildID))) CL = BuildID;
                    }
                } catch (Exception)
                {
                    try
                    {
                        string BuildID = req.Headers["user-agent"].ToString().Split("-")[1].Split("+")[0];

                        if (!Double.IsNaN(Convert.ToDouble(BuildID))) CL = BuildID;

                    } catch (Exception) {}
                }

                try
                {
                    string Build = req.Headers["user-agent"].ToString().Split("Release-")[1].Split("-")[0];
                    
                    if (Build.Split(".").Length == 3)
                    {
                        string[] Value = Build.Split(".");
                        Build = Value[0] + "." + Value[1] + Value[2];
                    }

                    info.season = Convert.ToInt32(Build.Split(".")[0]);
                    info.build = Convert.ToInt32(Build);
                    info.CL = CL;
                    info.lobby = string.Format("LobbySeason{0}", info.season);

                    if (Double.IsNaN(Convert.ToDouble(info.season))) throw new Exception();
                } catch (Exception)
                {
                    if (Convert.ToInt32(info.CL) < 3724489)
                    {
                        info.season = 0;
                        info.build = 0.0;
                        info.CL = CL;
                        info.lobby = "LobbySeason0";
                    } else if (Convert.ToInt32(info.CL) <= 3790078)
                    {
                        info.season = 1;
                        info.build = 1.0;
                        info.CL = CL;
                        info.lobby = "LobbySeason1";
                    } else
                    {
                        info.season = 2;
                        info.build = 2.0;
                        info.CL = CL;
                        info.lobby = "LobbyWinterDecor";
                    }
                }
            }

            return info;
        }
    }
}
