using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
	public GameObject target; 	// View target object
	Vector3 offset; 			// Position relative to our view target

	void Start () 
	{
		// Compute the offset relative to our target
		offset = transform.position - target.transform.position;
	}

	void Update () 
	{
		transform.position = target.transform.position + offset;
	}
}
	