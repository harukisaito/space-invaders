using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


	[SerializeField]
	private float movementSpeed;

	public float MovementSpeed
	{
		get {return movementSpeed;}
		set {movementSpeed = value;}
	}

	[SerializeField]
	private float distanceX;
	[SerializeField]
	private float distanceY;

	[SerializeField]
	private Transform leftBarrier;

	public Transform LeftBarrier
	{
		get {return leftBarrier;}
		set {leftBarrier = value;}
	}

	[SerializeField]
	private Transform rightBarrier;
	public Transform RightBarrier
	{
		get {return rightBarrier;}
		set {rightBarrier = value;}
	}

	private float timer;
	private bool goingRight = true;

	public bool GoingRight
	{
		get {return goingRight;}
		set {goingRight = value;}
	}

	private bool goingDown = false;
	public bool GoingDown
	{
		get {return goingDown;}
		set {goingDown = value;}
	}
	
	void Update () {
		if(GameControl.instance.PlayerLifes > 0)
		{
			timer += Time.deltaTime;
			if(timer >= movementSpeed)
			{
				foreach (GameObject g in GameControl.instance.InvaderList)
				{
					if(g != null)
					{
						g.GetComponent<Animator>().SetTrigger("move");
					}
				}
				if(goingRight == true)
				{
					MoveHorizontal(distanceX);
				}
				if(goingRight == false)
				{
					MoveHorizontal(-distanceX);
				}
			}
		}
	}

	public void MoveHorizontal(float x)
	{
		transform.position = new Vector2(transform.position.x + x, transform.position.y);

		timer = 0;
		goingDown = true;
	}

	public void MoveDown()
	{
		transform.position = new Vector2(transform.position.x, transform.position.y - distanceY);

		timer = 0;
		goingDown = false;
	}
}
