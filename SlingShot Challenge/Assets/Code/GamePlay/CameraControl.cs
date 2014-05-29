using UnityEngine;

using System.Collections;

public class CameraControl : MonoBehaviour
{
    public static bool Moving;

    static float Speed;

    float MaxZ, MinZ;

    // Use this for initialization
	void Start ()
    {
        Moving = false;

        Speed = -0.1f;

        MaxZ = 2;

        MinZ = -5;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Moving)
        {
            if (Speed > 0)
            {
                if (transform.position.z < MaxZ)
                {
                    transform.position += new Vector3(0, 0, Speed);
                }
            }
            else
            {
                if (transform.position.z > MinZ)
                {
                    transform.position += new Vector3(0, 0, Speed);
                }
            }
        }
	}

    public static void Move(bool Forward)
    {
        Moving = true;

        if (Forward)
        {
            Speed = 0.2f;
        }
        else
        {
            Speed = -0.1f;
        }
    }
}