using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform spawnPoint;
    [Header("Час між хвилями")]
    [SerializeField] private float countDown = 3f;
    [Header("Час між спавном ворогів у хвилі")]
    [SerializeField] private float timeBetweenSpawnEnemy = 1f;
    private float countWave = 1f;
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnWave(){
        yield return new WaitForSeconds(countDown);
        for(int i = 0; i < countWave; i++){
            Instantiate(ChooseEnemy(), spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnEnemy);
        }
        countWave++;
        StartCoroutine(SpawnWave());
    }
    private GameObject ChooseEnemy(){
        if(countWave > 10){
            int chance = Random.Range(0, 100);
            if(chance < 50) return enemies[0];
            else if(chance >= 50 && chance < 80) return enemies[1];
            else if(chance >= 80 && chance <= 100) return enemies[2];
        }
        return enemies[0];
    }
}
