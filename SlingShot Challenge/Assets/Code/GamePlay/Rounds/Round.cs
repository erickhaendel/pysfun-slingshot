using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public enum TurnType 
{
	Player1 , Player2
}

public class Round
{
    int Id;
    
    public bool Launched , End;

    public Dictionary<TurnType, int> Scores;

    public Dictionary<TurnType, GameObject> Stones;
	
	public float ElapsedTime;
	
	public static float MaxTime = 5.0f;
	
	public TurnType CurrentTurn;
	
	RoundSettings Settings;

    Arrangement Tins;

	public Round(int RoundId)
	{
        Id = RoundId;
        
        End = false;

        Settings = new RoundSettings(Id);
        
        Scores = new Dictionary<TurnType, int>();
        Scores.Add(TurnType.Player1, 0);
        Scores.Add(TurnType.Player2, 0);

        Stones = new Dictionary<TurnType, GameObject>();
        Stones.Add(TurnType.Player1, null);
        Stones.Add(TurnType.Player2, null);

		CurrentTurn = TurnType.Player1;
		
		Reset();

        if (RoundId != 0)
        {
            Tins = new Arrangement(ArrangementType.Simple);
        }
        else
        {
            Tins = new Arrangement(ArrangementType.Simple, GameObject.Find("SmallTin"), GameObject.Find("NormalTin"), GameObject.Find("BigTin"));
        }

        CameraControl.Move(false);
	}

	public void Update()
	{
		if (Launched)
		{
			ElapsedTime += Time.deltaTime;

			if (ElapsedTime > MaxTime)
			{
                SaveScore();

                switch (CurrentTurn)
				{
					case TurnType.Player1 :

						CameraControl.Move(false);

                        CurrentTurn = TurnType.Player2;

						Reset();
					
					break;
					
					case TurnType.Player2:

                        # region Destroy

                        if (Id < RoundManager.RoundCount - 1)
                        {
                            Tins.Delete();

                            GameObject.Destroy(Stones[TurnType.Player1]);
                            GameObject.Destroy(Stones[TurnType.Player2]);
                        }

                        # endregion

                        End = true;

					break;
				}	
			}
		}
	}

    void Reset()
    {
        ElapsedTime = 0.0f;

        Launched = false;

        Stones[CurrentTurn] = GameObject.Instantiate(Content.Stones[Settings.Stone]) as GameObject;
        Stones[CurrentTurn].name = CurrentTurn + " Stone " + RoundManager.ElapsedRounds;
    }

	public void LaunchStone(Vector3 Force)
	{	
        Stones[CurrentTurn].rigidbody.AddForce(Force);

        Stones[CurrentTurn].rigidbody.useGravity = true;
		
		Launched = true;

		CameraControl.Move(true);
	}

    public void DragStone(Vector3 Delta)
    {
        Stones[CurrentTurn].transform.position += Delta;

        Vector3 ClampedPos = Stones[CurrentTurn].transform.position;

        ClampedPos.x = Mathf.Clamp(ClampedPos.x, SlingShot.MinPosition.x, SlingShot.MaxPosition.x);
        ClampedPos.y = Mathf.Clamp(ClampedPos.y, SlingShot.MinPosition.y, SlingShot.MaxPosition.y);

        Stones[CurrentTurn].transform.position = ClampedPos;
    }

    public void IncreaseScore()
    {
        ++Scores[CurrentTurn];
    }

    void SaveScore()
    {
        RoundManager.Scores[CurrentTurn][RoundManager.ElapsedRounds] = Scores[CurrentTurn];
    }
}