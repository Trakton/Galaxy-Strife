using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// A leaderboard entry composed of Score and Name. Implement IComparable for sorting functions by descending score.
/// </summary>
public class LeaderboardEntry : IComparable 
{
	public int Score { get; set; }
	public string Name { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="LeaderboardEntry"/> class.
	/// </summary>
	/// <param name="name">the string name of the player who won this score.</param>
	/// <param name="score">the int score.</param>
	public LeaderboardEntry(string name, int score)
	{
		this.Name = name;
		this.Score = score;
	}

	/// <summary>
	/// Compareres two instances of LeaderboardEntry by the Score.
	/// </summary>
	/// <returns>-1 if left is smaller, 1 if left is greater or 0 if they are equally scored. </returns>
	/// <param name="a">The left instance.</param>
	/// <param name="b">The right instance.</param>
	int IComparable.CompareTo(object b)
	{
		LeaderboardEntry rhs = (LeaderboardEntry)b;
		if (Score > rhs.Score)
			return -1;
		else if(Score < rhs.Score)
			return 1;
		else 
			return 0;
	}
}
