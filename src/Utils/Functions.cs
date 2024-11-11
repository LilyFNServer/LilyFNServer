namespace LilyFNServer.Utils
{
    public class Functions
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

        public FortniteVersionInfo GetVersionInfo(HttpRequest req)
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
                } catch (Exception ex)
                {
                    try
                    {
                        string BuildID = req.Headers["user-agent"].ToString().Split("-")[1].Split("+")[0];

                        if (!Double.IsNaN(Convert.ToDouble(BuildID))) CL = BuildID;

                    } catch (Exception e) {}
                }

                try
                {
                    string Build = req.Headers["user-agent"].ToString().Split("Release-")[1].Split("-")[0];
                    
                    if (Build.Split())
                }
            }

            return info;
        }
    }
}
