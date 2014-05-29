using UnityEngine;

using System.Collections;

public class ScaleManager : MonoBehaviour
{
	public Transform Target;
	
	float Factor , NormalDistance;
	
	// Use this for initialization
	void Start ()
	{
		Factor = 0f;
		
		NormalDistance = Target.position.z - transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float CurrentDistance = Target.position.z - transform.position.z;
		
		Factor = CurrentDistance / NormalDistance;

		//transform.localScale += new Vector3(0 , 0 , (int)Mathf.Abs(Factor));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 NewScale = new Vector3();

			NewScale.x = transform.localScale.x;
			NewScale.z = transform.localScale.z;

			if (transform.localScale.y == 0.5f)
			{
				NewScale.y = 0.75f;
			}
			else if (transform.localScale.y == 0.75f)
			{
				NewScale.y = 0.5f;
			}

			transform.localScale = NewScale;
		}
	}
}