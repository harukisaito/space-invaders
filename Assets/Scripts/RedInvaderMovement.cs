using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedInvaderMovement : MonoBehaviour {

	private Rigidbody2D redInvaderRB;	

	[SerializeField]
	private float movementSpeed;

	private Vector3 leftPos = new Vector3(-6, 3.6f);
	private Vector3 rightPos = new Vector3(6, 3.6f);
	private bool right;

	void Start () {
		redInvaderRB = GetComponent<Rigidbody2D>();

		if(Random.Range(0,100) >= 50)
		{
			redInvaderRB.transform.position = leftPos;
			redInvaderRB.AddForce(Vector2.right * movementSpeed);
			right = true;
		}
		else
		{
			redInvaderRB.transform.position = rightPos;
			redInvaderRB.AddForce(Vector2.left * movementSpeed);
			right = false;
		}
	}

	void Update()
	{
		if(redInvaderRB.transform.position.x >= rightPos.x && right == true)
		{
			Destroy(gameObject);
		}

		if(redInvaderRB.transform.position.x <= leftPos.x && right == false)
		{
			Destroy(gameObject);
		}
	}
}
