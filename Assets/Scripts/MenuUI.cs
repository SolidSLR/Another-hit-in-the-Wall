using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void StartOnClick(){
        SceneManager.LoadScene("MainScene");
    }
    public void ExitOnClick(){
        Application.Quit();
    }
    public void GameInfoOnClick(){
        Debug.Log("Se carga info de juego");
    }
}
