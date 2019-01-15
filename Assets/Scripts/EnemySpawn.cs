using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> invaders;

	[SerializeField]
	private Transform startPoint;

	[SerializeField]
	private float offsetX;

	private GameObject[] invaderInstances;

    public List<GameObject> InvaderList
    {
        get {return invaders;}
        set {invaders = value;}
    }

    public void SpawnEnemies(int colCount)
    {
        invaderInstances = new GameObject[invaders.Count];

        for (int i = 0; i < colCount; i++)
        {
            for (int j = 0; j < invaders.Count; j++)
            {
                Vector3 spawnPosOffset = new Vector3(offsetX * i, 0.6f * j, 0);
                invaderInstances[j] = Instantiate(invaders[j], startPoint.position + spawnPosOffset, Quaternion.identity, GameControl.instance.EnemyCols[i].transform);
            }
        }
    }
}
