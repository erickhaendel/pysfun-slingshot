using UnityEngine;

using System.Collections;

enum WelcomeState
{
    Normal , SignUp
}

public class Welcome : MonoBehaviour
{
    Texture2D BackGroundImage , SignUpBackGround;

    Button SignUpButton , VisitorButton , OkButton;

    WelcomeState CurrentState;

    TextBox NameBox, AgeBox, GenderBox;

    // Use this for initialization
	void Start()
    {
        StateManager.Start();
        
        # region Language

        switch (StateManager.CurrentLanguage)
        {
            case GameLanguage.English:

                BackGroundImage = Resources.Load("BackGroundImages/Welcome/Welcome") as Texture2D;

                SignUpBackGround = Resources.Load("BackGroundImages/Welcome/SignUp") as Texture2D;

                break;

            case GameLanguage.Portugues:

                BackGroundImage = Resources.Load("Telas/BemVindo/BemVindo") as Texture2D;

                SignUpBackGround = Resources.Load("Telas/BemVindo/Cadastro") as Texture2D;

                break;
        }

        # endregion

        # region Buttons

        SignUpButton = new Button("Buttons/Welcome/SignUp" , new Vector2(850 , 425));

        VisitorButton = new Button("Buttons/Welcome/Visitor", new Vector2(275 , 425));

        OkButton = new Button("Buttons/Welcome/Ok", new Vector2(850 , 375));

        # endregion

        CurrentState = WelcomeState.Normal;

        # region Sign Up

        NameBox = new TextBox(new Vector2(620, 200) , string.Empty , new Vector2(330 , 30));

        AgeBox = new TextBox(new Vector2(620 , 245) , string.Empty , new Vector2(330 , 30));

        GenderBox = new TextBox(new Vector2(620 , 295) , string.Empty , new Vector2(330 , 30));

        # endregion
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
            switch (CurrentState)
            {
                case WelcomeState.Normal:

                    # region Escape

                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Application.Quit();
                    }

                    # endregion

                    break;

                case WelcomeState.SignUp:

                    # region Escape

                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        CurrentState = WelcomeState.Normal;
                    }

                    # endregion

                    break;
            }
        }
	}

    void OnGUI()
    {
        StateManager.DrawBackGroundImage(BackGroundImage);
        
        # region Buttons

        # region Draw

        SignUpButton.Draw(StateManager.GameSkin.button);
        VisitorButton.Draw(StateManager.GameSkin.button);

        # endregion

        # region Click

        if (!StateManager.IsOnTransition)
        {
            if (SignUpButton.Clicked)
            {
                CurrentState = WelcomeState.SignUp;
            }

            if (VisitorButton.Clicked)
            {
                GetLoading();
            }
        }

        # endregion

        # endregion

        switch (CurrentState)
        {
            case WelcomeState.Normal:



                break;

            case WelcomeState.SignUp:

                StateManager.DrawBackGroundImage(SignUpBackGround);

                # region TextBoxes

                NameBox.Draw(StateManager.GameSkin.textField);
                AgeBox.Draw(StateManager.GameSkin.textField);
                GenderBox.Draw(StateManager.GameSkin.textField);

                # endregion

                # region Buttons

                OkButton.Draw(StateManager.GameSkin.button);

                if (OkButton.Clicked)
                {
                    GetLoading();
                }

                # endregion

                break;
        }

        StateManager.TransitionEffect();
    }

    void GetLoading()
    {
        StateManager.ChangeState(GameStates.Loading);
    }
}