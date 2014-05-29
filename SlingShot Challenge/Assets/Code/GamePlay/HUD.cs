using UnityEngine;

using System.Collections;

public class HUD : MonoBehaviour
{
	public GUIStyle Info_Style , PlayerStyle;

    # region Score Properties

    Vector2 Box1Position, Box2Position;

    Vector2 BoxSize , LabelSize;

    Vector2 LabelMargin;

    Texture2D TurnOn;

    # endregion

    // Use this for initialization
	void Start()
	{
        # region Score

        Box1Position = new Vector2(150 , 400);
        Box2Position = new Vector2(900 , 400);

        BoxSize = new Vector2(300 , 150);

        LabelSize = new Vector2(30 , 30);

        LabelMargin = new Vector2(15 , 10);

        TurnOn = Resources.Load("GamePlay/Interface/TurnOn") as Texture2D;

        # endregion
    }
	
	// Update is called once per frame
	void Update()
	{

	}

	void OnGUI()
	{
        GUI.Label(new Rect(1000 , 50 , 100 , 50) , "Round : " + (RoundManager.ElapsedRounds + 1).ToString() , Info_Style);
        
        GUI.Label(new Rect(1000 , 100 , 100 , 50) , "Turn : " + RoundManager.CurrentRound.CurrentTurn.ToString() , Info_Style);

        # region Player1 Score

        GUI.Box(new Rect(Box1Position.x, Box1Position.y, BoxSize.x, BoxSize.y), "Player1" , StateManager.GameSkin.box);

        GUI.BeginGroup(new Rect(Box1Position.x, Box1Position.y, BoxSize.x, BoxSize.y));

        for (int i = 0; i < RoundManager.RoundCount; i++)
        {
            GUI.Label(new Rect(LabelMargin.x + (LabelMargin.x * i) + (LabelSize.x * i) + (LabelMargin.x * i) + (LabelMargin.x / 2) , 50 + LabelMargin.y , LabelSize.x , LabelSize.y) , RoundManager.Scores[TurnType.Player1][i].ToString() , PlayerStyle);
        }

        if (RoundManager.CurrentRound.CurrentTurn == TurnType.Player1)
        {
            GUI.DrawTexture(new Rect(60 * RoundManager.ElapsedRounds , 50 , 60 , 50) , TurnOn);
        }
        
        GUI.EndGroup();

        # endregion
        
        # region Player2 Score

        GUI.Box(new Rect(Box2Position.x, Box2Position.y, BoxSize.x, BoxSize.y), "Player2", StateManager.GameSkin.box);

        GUI.BeginGroup(new Rect(Box2Position.x, Box2Position.y, BoxSize.x, BoxSize.y));

        for (int i = 0; i < RoundManager.RoundCount; i++)
        {
            GUI.Label(new Rect(LabelMargin.x + (LabelMargin.x * i) + (LabelSize.x * i) + (LabelMargin.x * i) + (LabelMargin.x / 2), 50 + LabelMargin.y, LabelSize.x, LabelSize.y), RoundManager.Scores[TurnType.Player2][i].ToString(), PlayerStyle);
        }

        if (RoundManager.CurrentRound.CurrentTurn == TurnType.Player2)
        {
            GUI.DrawTexture(new Rect(60 * RoundManager.ElapsedRounds , 50 , 60 , 50) , TurnOn);
        }

        GUI.EndGroup();

        # endregion
    }
}