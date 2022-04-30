using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color hoverColor;
    private GameObject tempObj;
    [SerializeField] private GameObject[] turrets;
    private bool canBuild = false;
    private int cost;
    private int indexTurret;
    private int buildingCounter;
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit)){
            if(raycastHit.collider.gameObject.CompareTag("Node") && canBuild){
                tempObj = raycastHit.collider.gameObject;
                tempObj.GetComponent<MeshRenderer>().material.color = hoverColor;
                if(Input.GetMouseButtonDown(0)){
                    tempObj.GetComponent<NodeBuildSetting>().StartBuild(turrets, indexTurret, 0.35f, cost);
                    canBuild = false;
                    buildingCounter++;
                    if(buildingCounter > 5 && Random.Range(0, 100) < 30){
                        AdsManager.ShowVideo("Interstitial_Android");
                    }
                }
            }else{
                if(tempObj != null){
                    tempObj.GetComponent<MeshRenderer>().material.color = startColor;
                }
            }
        }
    }
    public void SetBuildTurret(int buildCost, int buildIndex){
        indexTurret = buildIndex;
        cost = buildCost;
        canBuild = true;
    }
    
}
