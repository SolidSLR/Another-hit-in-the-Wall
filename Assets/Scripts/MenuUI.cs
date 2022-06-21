using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject principalUI;
    public GameObject infoUI;
    void Start(){
        principalUI.SetActive(true);
        infoUI.SetActive(false);
    }
    public void StartOnClick(){
        SceneManager.LoadScene("MainScene");
    }
    public void ExitOnClick(){
        Application.Quit();
    }
    public void GameInfoOnClick(){
        Debug.Log("Se carga info de juego");
        principalUI.SetActive(false);
        infoUI.SetActive(true);
    }
    public void ExitInfoUI(){
        principalUI.SetActive(true);
        infoUI.SetActive(false);
    }
}
