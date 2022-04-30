using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range;
    [Header("Настройки снаряда")]
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Transform[] gunBarrel;
    [SerializeField] private float countdown;
    [SerializeField] private float turnSpeed;
    private int barellNumber;
    private bool canShoot = true;
    [SerializeField] private AudioSource audioSource;
    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    private void FindTarget(){
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject currentTarget = null;
        float distance = Mathf.Infinity;

        foreach(GameObject target in targets){
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);
            if(distanceToEnemy < distance){
                distance = distanceToEnemy;
                currentTarget = target;
            }
        }
        if(distance <= range && currentTarget != null){
            this.target = currentTarget.transform;
        }else{
            this.target = null;
        }
    }
    IEnumerator Shoot(int barrelNumber){
        GameObject bullet = Instantiate(bulletPref, gunBarrel[barrelNumber].position, Quaternion.identity);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.TakeForce(target);
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.Play();

        yield return new WaitForSeconds(countdown);
        canShoot = !canShoot;
    }
    private void Look(){
        if(target != null){
            Quaternion look = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, look, turnSpeed * Time.deltaTime);
            if(canShoot){
                StartCoroutine(Shoot(barellNumber));
                barellNumber++;
                if(barellNumber == gunBarrel.Length){
                    barellNumber = 0;
                }
                canShoot  = !canShoot;
            }
        }
    }
}
