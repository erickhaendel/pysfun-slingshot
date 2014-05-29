using UnityEngine;

using System.Collections;

public class Distribution : MonoBehaviour
{
    Texture2D BackGroundImage;

    Button OkButton;

	// Use this for initialization
	void Start()
    {
        # region Language

        switch (StateManager.CurrentLanguage)
        {
            case GameLanguage.English:

                BackGroundImage = (Texture2D)Resources.Load("BackGroundImages/Distribution");

                break;

            case GameLanguage.Portugues:

                BackGroundImage = (Texture2D)Resources.Load("Telas/Distribuicao");

                break;
        }

        # endregion

        OkButton = new Button("Buttons/Ok", new Vector2(650, 500));
	}
	
	// Update is called once per frame
    void Update()
    {
        if (StateManager.IsOnTransition)
        {
            StateManager.Update();
        }
        else
        {
            # region Escape

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GetMenu();
            }

            # endregion

            # region Enter

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                GetPlayAgain();
            }

            # endregion
        }
    }

    void OnGUI()
    {
        StateManager.DrawBackGroundImage(BackGroundImage);

        OkButton.Draw(StateManager.GameSkin.button);

        if (OkButton.Clicked)
        {
            GetPlayAgain();
        }

        StateManager.TransitionEffect();
    }

    void GetPlayAgain()
    {
        if (true)
        {
            Save();
        }
        else
        {
            Save();
        }

        GetMenu();
    }

    void Save()
    {
        // Enviar pro Servidor
    }

    void GetMenu()
    {
        GameObject.Destroy(GamePlay.LocalAudio);

        StateManager.ChangeState(GameStates.Menu);
    }
}