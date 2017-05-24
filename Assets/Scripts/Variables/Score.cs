using System.Collections.Generic;

/// <summary>
/// Stores the rewards for killing a particular foe.
/// </summary>
static public class Score 
{
	static Dictionary<string, int> enemy;

	/// <summary>
	/// Init this instance filling the score dictionaries.
	/// </summary>
	static public void Init()
	{
		enemy = new Dictionary<string, int> ();
		enemy.Add("fractionEnemy", 50);
		enemy.Add("seekerEnemy", 75);
		enemy.Add("wandererEnemy", 50);
		enemy.Add("walkerEnemy", 100);
		enemy.Add("fractionaryEnemy", 125);
		enemy.Add("missileEnemy", 200);
	}

	/// <summary>
	/// Gets the score value for an particular enemy.
	/// </summary>
	/// <returns>The score this enemy killing rewards.</returns>
	/// <param name="name">The enemy name.</param>
	static public int GetEnemy(string name)
	{
		if (enemy.ContainsKey (name))
			return enemy [name];
		return 0;
	}
}
