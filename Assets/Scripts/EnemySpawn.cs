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

    public void SpawnEnemies(int colCount)
    {
        for (int i = 0; i < colCount; i++)
        {
            for (int j = 0; j < invaders.Count; j++)
            {
                Vector3 spawnPosOffset = new Vector3(offsetX * i, 0.6f * j, 0);
                GameObject invader = Instantiate(invaders[j], startPoint.position + spawnPosOffset, Quaternion.identity, GameControl.instance.EnemyCols[i].transform);
                GameControl.instance.InvaderList.Add(invader);
            }
        }
    }
}
