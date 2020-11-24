using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecterManagerScript : MonoBehaviour
{
    public static SelecterManagerScript instance;

    public GameObject AWingRed, AWingResistance, AWingWGY, AWingWhiteRed;

    public GameObject ClickArrowsInfo;

    private int characterInt = 1;

    private const string selectedCharacter = "Selected Character";

    public void NextCharacter(){
        ClickArrowsInfo.SetActive(false);
        switch(characterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                AWingRed.SetActive(false);
                AWingResistance.SetActive(true);
                characterInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                AWingResistance.SetActive(false);
                AWingWGY.SetActive(true);
                characterInt++;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedCharacter, 3);
                AWingWGY.SetActive(false);
                AWingWhiteRed.SetActive(true);
                characterInt++;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedCharacter, 4);
                AWingWhiteRed.SetActive(false);
                AWingRed.SetActive(true);
                characterInt++;
                ResetInteger();
                break;
            default:
                ResetInteger();
                break;
        }
    }

    public void PreviousCharacter(){
        ClickArrowsInfo.SetActive(false);
        switch(characterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 4);
                AWingResistance.SetActive(false);
                AWingRed.SetActive(true);
                characterInt--;
                ResetInteger();
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                AWingWGY.SetActive(false);
                AWingResistance.SetActive(true);
                characterInt--;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                AWingWhiteRed.SetActive(false);
                AWingWGY.SetActive(true);
                characterInt--;
                break;  
            case 4:
                PlayerPrefs.SetInt(selectedCharacter, 3);
                AWingRed.SetActive(false);
                AWingWhiteRed.SetActive(true);
                characterInt--;
                break;  
            default:
                ResetInteger();
                break;
        }
    }

    private void ResetInteger(){
        if(characterInt >= 4){
            characterInt = 1;
        }
        else{
            characterInt = 4;
        }
    }

    public void PlayGame(){
        SceneManager.LoadScene("GameplayScene");
    }
}
