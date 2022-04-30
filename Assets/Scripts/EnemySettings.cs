using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySettings : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private GameObject boomFX;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetSpeed(){
        return speed;
    }
    public int GetHealth(){
        return health;
    }
    public void Damage(int damageValue){
        //if(damageValue > health) return;
        health -= damageValue;
        if(health <= 0){
            CoinController.AddCoin(15);
            Instantiate(boomFX, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            Destroy(gameObject);
        }
    }
}
