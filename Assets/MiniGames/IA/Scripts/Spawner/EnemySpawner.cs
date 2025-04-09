using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 1f;
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (true) 
        { 
            yield return wait; 
            int random  = Random.Range(0,enemyPrefab.Length);
            GameObject enemyToSpawn = enemyPrefab[random];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
