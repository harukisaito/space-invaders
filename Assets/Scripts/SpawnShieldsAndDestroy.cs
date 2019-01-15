using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShieldsAndDestroy : MonoBehaviour {
	[SerializeField]
	private GameObject fullBlockPrefab;
	[SerializeField]
	private GameObject okBlockPrefab;
	[SerializeField]
	private GameObject weakBlockPrefab;
	[SerializeField]
	private float posX;
	[SerializeField]
	private float posY;
	[SerializeField]
	private float offsetX;
	bool[] usedFull = new bool[4];
	bool[] usedWeak = new bool[4];
	private Vector3 blockPoolPosition = new Vector3(-10f, -10f, 0f);

	private GameObject[] fullBlocks = new GameObject[4];
	private GameObject[] okBlocks = new GameObject[4];
	private GameObject[] weakBlocks = new GameObject[4];



	// Use this for initialization
	void Start () {
		for(int i = 0; i <= 3; i++)
		{
			fullBlocks[i] = Instantiate(fullBlockPrefab, blockPoolPosition, Quaternion.identity);
			okBlocks[i] = Instantiate(okBlockPrefab, blockPoolPosition, Quaternion.identity);
			weakBlocks[i] = Instantiate(weakBlockPrefab, blockPoolPosition, Quaternion.identity);
		}

		for(int i = 0; i <= 3; i++)
		{
			fullBlocks[i].transform.position = new Vector2(posX + i * offsetX, posY);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i <= 3; i++)
		{
			Vector3 ingamePos = new Vector3(posX + i * offsetX, posY);
			if(fullBlocks[i].transform.position == blockPoolPosition && usedFull[i] == false)
			{
				okBlocks[i].transform.position = ingamePos;
				usedFull[i] = true;
			}
			if(okBlocks[i].transform.position == blockPoolPosition && usedFull[i] == true && usedWeak[i] == false)
			{
				weakBlocks[i].transform.position = ingamePos;
				usedWeak[i] = true;
			}
		}
	}
}
