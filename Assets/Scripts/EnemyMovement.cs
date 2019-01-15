using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


	[SerializeField]
	private float movementSpeed = 1;
	[SerializeField]
	private float distanceX;
	[SerializeField]
	private float distanceY;
	[SerializeField]
	private float stepsX;
	private float counter = 0;
	private float timer;
	private bool goingRight = true;
	private bool goingDown = false;


	// Use this for initialization
	void Start () {
		Transform[] gameObjects = GetComponentsInChildren<Transform>();
		foreach (Transform t in gameObjects)
		{
			if(t.gameObject.name.Contains("Col"))
				Debug.Log(t.GetChild(0));
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(GameControl.instance.PlayerLifes > 0)
		{
			timer += Time.deltaTime;
			if(timer >= movementSpeed)
			{
				if(goingDown == true)
				{
					MoveDown();
					return;
				}
				if(goingRight == true)
				{
					MoveRight();
					return;
				}
				if(goingRight == false)
				{
					MoveLeft();
					return;
				}
			}
		}
	}

	private void MoveRight()
	{
		transform.position = new Vector2(transform.position.x + distanceX, transform.position.y);

		counter ++;
		timer = 0;
		if(counter == stepsX)
		{
			goingDown = true;
			goingRight = false;
		}
	}

	private void MoveLeft()
	{
		transform.position = new Vector2(transform.position.x - distanceX, transform.position.y);

		counter ++;
		timer = 0;
		if(counter == stepsX)
		{
			goingDown = true;
			goingRight = true;
		}
	}

	private void MoveDown()
	{
		transform.position = new Vector2(transform.position.x, transform.position.y - distanceY);
		counter = 0;
		timer = 0;
		goingDown = false;
	}
}
