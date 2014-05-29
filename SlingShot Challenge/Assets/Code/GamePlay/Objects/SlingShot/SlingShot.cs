using UnityEngine;

using System.Collections;

public class SlingShot : MonoBehaviour
{
    public static Vector2 MinPosition, MaxPosition;
    
    public static bool Started;

    Vector3 LaunchPoint;

    Vector3 Impulse , Force;
	RuntimePlatform platform = Application.platform;

	// Use this for initialization
	void Start ()
	{
        //MinPosition = new Vector2(-1f , 0.5f);

        //MaxPosition = new Vector2(1f , 1.5f);

        MinPosition = new Vector2(-1.5f, 0f);

        MaxPosition = new Vector2(1.5f, 2f);

        Impulse = new Vector3(200, 500, 900);

		Reset();
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Started)
        {
            if (Input.GetMouseButtonUp(0))
            {

                Started = false;

                LaunchPoint = RoundManager.CurrentRound.Stones[RoundManager.CurrentRound.CurrentTurn].transform.position;

                Vector3 Distance = LaunchPoint - transform.position;

                // Consertando o erro do Modelo 3D
                Distance.x -= 0.3f;

                Vector3 Direction = -Distance;

                Force = new Vector3(Impulse.x * Direction.x, Impulse.y * Direction.y, Impulse.z * Direction.z);
                RoundManager.CurrentRound.LaunchStone(Force);
            }
            else
            {
                //Vector3 Drag = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0); //Descobrir o Drag em Z
                ///Drag /= 10;
				//RoundManager.CurrentRound.DragStone(Drag);
            }
        }
	}

	void Reset()
	{
		Started = false;

        LaunchPoint = new Vector3();

        Force = new Vector3();
	}
}