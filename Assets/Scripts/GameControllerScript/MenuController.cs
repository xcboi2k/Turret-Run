using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void PlayGame(){
        SceneManager.LoadScene("SelectShipScene");
    }

    public void ExitGame(){
        Application.Quit();
    }

}
