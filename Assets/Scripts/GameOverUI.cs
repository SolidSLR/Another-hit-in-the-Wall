using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void RestartOnClick(){
        SceneManager.LoadScene("MainScene");
    }
    public void ExitOnClick(){
        Application.Quit();
    }
}
