using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField] private Text scoreText, currentScore, endScore, bestScore;

    [SerializeField] private Button clickToPlayButton;

    [SerializeField] private GameObject pausePanel, continuePanel;

    public GameObject AWingRed, AWingResistance, AWingWGY, AWingWhiteRed;

    private const string selectedCharacter = "Selected Character";

    void Awake(){
        MakeInstance();
        Time.timeScale = 0f;

        int getShip;
        getShip = PlayerPrefs.GetInt(selectedCharacter);
        switch(getShip){
            case 1:
                AWingResistance.SetActive(true);
                break;
            case 2:
                AWingWGY.SetActive(true);
                break;
            case 3:
                AWingWhiteRed.SetActive(true);
                break;
            case 4:
                AWingRed.SetActive(true);
                break;
            default:
                AWingRed.SetActive(true);
                break;
        }
    }

    void MakeInstance()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void PauseGame(){
        if(ShipScript.instance != null){
            if(ShipScript.instance.isAlive){
                scoreText.gameObject.SetActive(false);
                pausePanel.SetActive(true);
                currentScore.text = "" + ShipScript.instance.score;
                
                bestScore.text = "" + GameController.instance.GetHighScore();
                Time.timeScale = 0f;
            }
        }
    }

    public void GoToMenuButton(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ResumeGame(){
        pausePanel.SetActive(false);
        Time.timeScale = 1f;

    }

    public void RestartGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameplayScene");
    }

    public void PlayGame(){
        scoreText.gameObject.SetActive(true);
        clickToPlayButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetScore(int score){
        scoreText.text = "" + score;
    }

    public void PlayerDiedShowScore(int score){
        continuePanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        
        endScore.text = "" + score;

        if(score > GameController.instance.GetHighScore()){
            GameController.instance.SetHighScore(score);
        }

        bestScore.text = "" + GameController.instance.GetHighScore();
    }
}
