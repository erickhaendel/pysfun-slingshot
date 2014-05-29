using UnityEngine;

using System.Collections;

public class Tin : MonoBehaviour
{
    bool Hit;
    
    // Use this for initialization
	void Start ()
    {
        Hit = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnCollisionEnter(Collision Impact)
    {
        if (!Hit)
        {
            if (Impact.gameObject.name == "Ground")
            {
                Hit = true;

                RoundManager.CurrentRound.IncreaseScore();
            }
        }
    }
}