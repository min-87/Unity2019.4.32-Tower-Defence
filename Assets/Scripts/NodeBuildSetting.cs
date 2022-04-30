using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBuildSetting : MonoBehaviour
{
    private GameObject structure;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject StructureInfo(){
        return structure;
    }
    public void StartBuild(GameObject[] structure, int structureIndex, float high, int cost){
        if(this.structure == null && CoinController.SubtractCoin(cost)){
            Vector3 position = new Vector3(transform.position.x, transform.position.y + high, transform.position.z);
            this.structure = Instantiate(structure[structureIndex], position, Quaternion.identity);
        }
    }
}
