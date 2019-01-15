using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutOfBounds : MonoBehaviour
{
	void OnTriggerEnter2D()
	{
		Destroy(gameObject);
	}
}
