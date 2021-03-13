using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float frequency;

    private void Start()
    {
        frequency = PlayerPrefs.GetFloat("Frequency");
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy;
            enemy = enemies[Random.Range(0, 3)];
            GameObject enemyRef = null;
            switch (Random.Range(1, 5))
            {
                case 1:
                    enemyRef = Instantiate(enemy, new Vector3(-Utility.WIDTH - 1, Random.Range(-Utility.HEIGHT, Utility.HEIGHT), 0), Quaternion.identity);
                    break;
                case 2:
                    enemyRef = Instantiate(enemy, new Vector3(Utility.WIDTH + 1, Random.Range(-Utility.HEIGHT, Utility.HEIGHT), 0), Quaternion.identity);
                    break;
                case 3:
                    enemyRef = Instantiate(enemy, new Vector3(Random.Range(-Utility.WIDTH, Utility.WIDTH), Utility.HEIGHT + 1, 0), Quaternion.identity);
                    break;
                case 4:
                    enemyRef = Instantiate(enemy, new Vector3(Random.Range(-Utility.WIDTH, Utility.WIDTH), -Utility.HEIGHT - 1, 0), Quaternion.identity);
                    break;
            }
            yield return null;
            enemyRef.GetComponent<EnemyController>().Initialize();
            yield return new WaitForSeconds(frequency);
        }
    }
}
