using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemyPrefab;
	
    public void Spawn(int time)
    {
        Invoke("SpawnEnemy", 1);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, gameObject.transform);
    }
}
