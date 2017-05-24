/// <summary>
/// Default leaderboard of a fresh new game.
/// </summary>
static public class DefaultLeaderboard  
{
	static public LeaderboardEntry[] hardcoreEntries;
	static public LeaderboardEntry[] beginnerEntries;

	/// <summary>
	/// Init this instance with some random scores for random players.
	/// </summary>
	static public void Init()
	{
		hardcoreEntries = new LeaderboardEntry[]
		{
			new LeaderboardEntry("Higor Cavalcanti",1510250),
			new LeaderboardEntry("Neon Blaster",950025),
			new LeaderboardEntry("Destroyer",525500),
			new LeaderboardEntry("Space Pirate",275250),
			new LeaderboardEntry("Blackdagger",100075)
		};

		beginnerEntries = new LeaderboardEntry[]
		{
			new LeaderboardEntry("Higor Cavalcanti",645325),
			new LeaderboardEntry("Blackdagger",455255),
			new LeaderboardEntry("Galaxy Invader",135725),
			new LeaderboardEntry("Cyborg",90225),
			new LeaderboardEntry("Infector",50525)
		};
	}
}
