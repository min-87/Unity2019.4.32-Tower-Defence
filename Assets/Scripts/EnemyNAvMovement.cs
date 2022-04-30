using UnityEngine;
using UnityEngine.AI;

public class EnemyNAvMovement : MonoBehaviour
{
    private Vector3 finishPoint;
    private NavMeshAgent agent;
    private EnemySettings enemySetup;

    private void Awake(){
        agent = GetComponent<NavMeshAgent>();
        finishPoint = GameObject.FindGameObjectWithTag("Finish").gameObject.transform.position;
        enemySetup = GetComponent<EnemySettings>();
    }
    void Start()
    {
        agent.destination = finishPoint;
        agent.speed = enemySetup.GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Finish")){
            Destroy(gameObject);
        }
    }
}
