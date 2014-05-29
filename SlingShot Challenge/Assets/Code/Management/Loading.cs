using UnityEngine;

using System.Collections;

public class Loading : MonoBehaviour
{
	Texture2D BackGroundImage;

	// Use this for initialization
	void Start ()
	{
		# region Language
		
		switch (StateManager.CurrentLanguage)
        {
            case GameLanguage.English:
			
				BackGroundImage = (Texture2D)Resources.Load("BackGroundImages/Loading");

            break;

        	case GameLanguage.Portugues:

            	BackGroundImage = (Texture2D)Resources.Load("Telas/Carregando");

            break;
        }
		
		# endregion
	}
	
	// Update is called once per frame
	void Update ()
	{		
		if (StateManager.IsOnTransition)
		{
			StateManager.Update();
		}
		else
        {
            # region Time

            if (Time.timeSinceLevelLoad >= 2)
      		{
                GetMenu();
            }

            # endregion

            # region Enter and MouseClick

            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetMouseButtonDown(0))
            {
                GetMenu();
            }

            # endregion

            # region Escape

            if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
            }

            # endregion
        }		
	}
	
	void OnGUI()
	{
		StateManager.DrawBackGroundImage(BackGroundImage);

        StateManager.TransitionEffect();
	}

    void GetMenu()
    {
        StateManager.ChangeState(GameStates.Menu);
    }
}