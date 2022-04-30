using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPref;
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn(){
        Instantiate(enemyPref, transform.position, Quaternion.identity);
    }
}
