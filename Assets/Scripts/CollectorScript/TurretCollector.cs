using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollector : MonoBehaviour
{
    private GameObject [] turretHolders;
    private float distance = 4.5f;
    private float lastTurretX;
    private float turretMin = -1.94f;
    private float turretMax = 1.94f;
    
    // Start is called before the first frame update
    void Awake()
    {
        turretHolders = GameObject.FindGameObjectsWithTag("TurretHolder");
        
        for(int i=1; i < turretHolders.Length; i++){
            Vector3 temp = turretHolders[i].transform.position;
            temp.y = Random.Range(turretMin, turretMax);
            turretHolders[i].transform.position = temp;
        }

        lastTurretX = turretHolders[0].transform.position.x;

        for(int i=1; i < turretHolders.Length; i++){
            if(lastTurretX < turretHolders[i].transform.position.x){
                lastTurretX = turretHolders[i].transform.position.x;
            }
        }
    }    
    
    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "TurretHolder"){
             Vector3 temp = target.transform.position;

             temp.x = lastTurretX + distance;
             temp.y = Random.Range(turretMin, turretMax);
             target.transform.position = temp;

             lastTurretX = temp.x;
         }
    }
}
