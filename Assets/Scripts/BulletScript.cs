using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private int damage = 15;
    private Rigidbody rb;
    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeForce(Transform target){
        Vector3 dir = target.position - transform.position;
        rb.AddForce(dir * speed, ForceMode.Impulse);
    }
    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Enemy")){
            col.gameObject.GetComponent<EnemySettings>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
