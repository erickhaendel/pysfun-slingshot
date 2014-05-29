using UnityEngine;

using System.Collections;

public class Stone : MonoBehaviour
{	
	public Vector3 curePosition, screenPoint, offset, curScreenPoint;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnMouseDown()
    {
		this.screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		this.offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.screenPoint.z));

        if (!SlingShot.Started)
        {
            SlingShot.Started = true;

        }
    }

	
	void OnMouseDrag() { 

		//if (Input.mousePosition.y < 1.5f && Input.mousePosition.y > -1.5f) {
		float pos_x = Input.mousePosition.x;
		float pos_y = Input.mousePosition.y;

		float pos_min_x = (Screen.width - 440) / 2;
		float pos_max_x = pos_min_x + 440;

		float pos_min_y = 40 ;
		float pos_max_y = Screen.height /2 ;

		if( pos_x < pos_min_x )
		{
			pos_x = pos_min_x;
		}else if( pos_x > ( pos_max_x ) )
		{
			pos_x = pos_max_x;
		}

		if( pos_y > pos_max_y )
		{
			pos_y = pos_max_y;
		}else if( pos_y < pos_min_y )
		{
			pos_y = pos_min_y;
		}

		// 440 - 200 
				
		this.curScreenPoint = new Vector3 (pos_x, pos_y, this.screenPoint.z);
		this.curePosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + this.offset;
		transform.position = curePosition;
	}
}