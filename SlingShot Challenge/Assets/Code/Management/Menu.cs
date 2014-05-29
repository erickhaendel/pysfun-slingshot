using UnityEngine;

using System.Collections;

public class Menu : MonoBehaviour
{
	Texture2D BackGroundImage;	
	
	Button PlayButton , AboutButton , CreditsButton , SettingsButton;

    public static GameObject LocalAudio;

	// Use this for initialization
	void Start ()
	{		
		# region Language

        switch (StateManager.CurrentLanguage)
        {
            case GameLanguage.English:

            	BackGroundImage = (Texture2D)Resources.Load("BackGroundImages/Menu");

            break;

        	case GameLanguage.Portugues:
			
				BackGroundImage = (Texture2D)Resources.Load("Telas/Menu");
			
            break;
        }

        # endregion
		
		# region Buttons
		
		PlayButton = new Button("Buttons/Menu/Play" , new Vector2(100 , 400));
		
		AboutButton = new Button("Buttons/Menu/About" , new Vector2(950 , 325));
		
		CreditsButton = new Button("Buttons/Menu/Credits" , new Vector2(950 , 425));
		
		SettingsButton = new Button("Buttons/Menu/Settings" , new Vector2(950 , 525));
		
		# endregion

        # region Audio

        if (StateManager.HasAudioControl)
        {
            if (GameObject.Find("AudioController"))
            {
                //if (GameObject.Find("AudioController").audio.clip == AudioController.Songs[SongType.GamePlay])
                //{
                    
                //}

                //GameObject.Destroy(GamePlay.LocalAudio);
            }
            else
            {
                CreateAudio();
            }
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
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}
	
	void OnGUI()
	{
        StateManager.DrawBackGroundImage(BackGroundImage);

        # region Buttons

        # region Draw

        PlayButton.Draw(StateManager.GameSkin.button);
        AboutButton.Draw(StateManager.GameSkin.button);
        CreditsButton.Draw(StateManager.GameSkin.button);
        SettingsButton.Draw(StateManager.GameSkin.button);

        # endregion

        # region Click

        if (!StateManager.IsOnTransition)
        {
            if (PlayButton.Clicked)
            {
                StateManager.ChangeState(GameStates.GamePlay);

                GameObject.Destroy(LocalAudio);
            }

            if (AboutButton.Clicked)
            {
                StateManager.ChangeState(GameStates.About);

                DontDestroyOnLoad(LocalAudio);
            }

            if (CreditsButton.Clicked)
            {
                StateManager.ChangeState(GameStates.Credits);

                DontDestroyOnLoad(LocalAudio);
            }

            if (SettingsButton.Clicked)
            {
                StateManager.ChangeState(GameStates.Settings);

                DontDestroyOnLoad(LocalAudio);
            }
        }

        # endregion

        # endregion

        StateManager.TransitionEffect();
	}

    void CreateAudio()
    {
        LocalAudio = new GameObject("AudioController");
        LocalAudio.AddComponent<AudioSource>();
        LocalAudio.audio.clip = AudioController.Songs[SongType.Menu];
        LocalAudio.audio.loop = true;
        LocalAudio.audio.volume = AudioController.SongVolume / 10;
        LocalAudio.audio.Play();
    }
}