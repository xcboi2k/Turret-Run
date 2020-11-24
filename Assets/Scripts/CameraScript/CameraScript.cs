using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static float offsetX;
    public GameObject playerCam;
    void Start()
    {
        playerCam.transform.position = new Vector3(-2.0f,0.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(ShipScript.instance != null){
            if(ShipScript.instance.isAlive){
                MoveTheCamera();
            }
        }
    }

    void MoveTheCamera(){
        Vector3 temp = transform.position;
        temp.x = ShipScript.instance.GetPositionX();
        transform.position = temp;
    }
}

