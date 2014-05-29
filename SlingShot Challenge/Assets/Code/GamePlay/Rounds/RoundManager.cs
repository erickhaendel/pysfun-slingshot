using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class RoundManager
{
	public static Round CurrentRound;

    public static int RoundCount , ElapsedRounds;

    public static Dictionary<TurnType, int[]> Scores;
	
	public static bool End;
	
	public static void Initialize(int roundCount)
	{
        RoundCount = roundCount;
        
        ElapsedRounds = 0;

        Scores = new Dictionary<TurnType, int[]>();
        Scores.Add(TurnType.Player1, new int[10]);
        Scores.Add(TurnType.Player2, new int[10]);

        CurrentRound = new Round(ElapsedRounds);

		End = false;
	}
	
	public static void Update()
	{
		CurrentRound.Update();
		
		if (CurrentRound.End)
		{
			NextRound();
		}
	}
	
	static void NextRound()
	{
		if (ElapsedRounds >= (RoundCount - 1))
		{
			End = true;
		}
		else
		{
            ++ElapsedRounds;
            
            CurrentRound = new Round(ElapsedRounds);
		}
	}
}