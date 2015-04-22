using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour 
{
	public float moveSpeed;
	public float jumpSpeed;
	bool isGrounded = true;
	// public class variable is exposed in inspector view

	void Update () 
	{
		float x = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime ;
		float z = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime ;

		// Vector3 force = new Vector3(x*10f, 0f, z*10f); // hardcoding values
		Vector3 force = new Vector3(x, 0f, z);
		// add f for float; less calculations

		if (isGrounded && Input.GetButton ("Jump"))
		{
			force.y = jumpSpeed;
			isGrounded = false;
		}

		rigidbody.AddForce (force);
		// lowercase, p: property
		// uppercase, c: class
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Coin"))
		{
			other.gameObject.SetActive(false);
			ScoreTracker.instance.AddScore(10);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag ("Ground")) 
		{
			isGrounded = true;
		}
	}
}
