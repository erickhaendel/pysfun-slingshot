using UnityEngine;

using System.Collections;

/// This script requires that a rigdibody is attached to the same game object

public class StickyGrenade : MonoBehaviour
{		
	bool Attached;
	
	Transform AttachedTransform;
	
	Vector3 AttachmentPoint;
	
	public GameObject Connected;
	
	// Use this for initialization
	void Start ()
	{
		// Enable only when we have a collision
		enabled = false;
		
		Attached = false;
		
		AttachmentPoint = Vector3.zero;
		
		if (Connected)
		{
			Verify(Connected.transform , Connected.rigidbody);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Update position to follow the object we stick to
		if (AttachedTransform)
		{
			transform.position = AttachedTransform.TransformPoint(AttachmentPoint);
		}
		else
		{
			// The attached transform was destroyed. Let go and enable physics control
			rigidbody.isKinematic = false;
			
			enabled = false;
		}
	}
	
	void OnCollisionEnter(Collision Hit)
	{
		Verify(Hit.transform , Hit.rigidbody);
	}
	
	void Verify(Transform _transform , Rigidbody _rigidbody)
	{
		if (!Attached)
		{			
			Attached = true;		
			
			// When we hit a rigidbody we attach to it with a fixed joint
			// this gives extra realism eg. the grenade's mass will now pull down the attached to rigidbody
			if (_rigidbody)
			{
				FixedJoint joint = gameObject.AddComponent("FixedJoint") as FixedJoint;
				
				joint.connectedBody = _rigidbody;
			}
			// When we hit a normal collider we just follow the transform around!
			else
			{
				// Store local attachment point and transform we stick to	
				AttachedTransform = _transform;
				
				AttachmentPoint = AttachedTransform.InverseTransformPoint(transform.position);
			
				// The grenade's position is now driven by the script instead of physics
				//rigidbody.isKinematic = true;
				
				enabled = true;
			}
		}
	}
}		