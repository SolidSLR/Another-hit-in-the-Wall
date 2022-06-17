using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject resumeUI;
    void Start(){
        pauseUI.SetActive(true);
        resumeUI.SetActive(false);
    }
    public void ContinueOnClick(){
        GameManager.instance.rounds++;
        GameManager.instance.NextRound();
    }
    public void PauseOnClick(){
        GameManager.instance.PauseGame();
        resumeUI.SetActive(true);
        pauseUI.SetActive(false);
    }
    public void ResumeOnClick(){
        GameManager.instance.ResumeGame();
        pauseUI.SetActive(true);
        resumeUI.SetActive(false);
    }
    public void RestartOnClick(){
        SceneManager.LoadScene("MainScene");
        // Revisar por qué no vuelven a salir bichos
    }
}
