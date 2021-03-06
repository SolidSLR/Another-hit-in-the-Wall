using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject resumeUI;
    public GameObject plusLifeButton;
    public GameObject plusADButton;
    public GameObject plusArrowButton;
    public GameObject spawnWalls;
    public static UIController instance;
    public int maxWalls = 0;
    void Awake(){
        instance=this;
    }
    void Start(){
        pauseUI.SetActive(true);
        resumeUI.SetActive(false);
    }
    public void ContinueOnClick(){
        maxWalls = 0;
        GameManager.instance.rounds++;
        plusLifeButton.GetComponent<Button>().interactable = true;
        plusADButton.GetComponent<Button>().interactable = true;
        plusArrowButton.GetComponent<Button>().interactable = true;
        spawnWalls.GetComponent<Button>().interactable = true;
        ChangeDisabledColor(plusLifeButton, "#C8C8C8");
        ChangeDisabledColor(plusADButton, "#C8C8C8");
        ChangeDisabledColor(plusArrowButton, "#C8C8C8");
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
    public void MenuOnClick(){
        Debug.Log("Se llamará a la pantalla de menú");
        SceneManager.LoadScene("Menu");
    }
    public void PlusLifeOnClic(){
        GameManager.instance.UpgradeTowerLife();
        ChangeDisabledColor(plusLifeButton, "#5FFF6E");
        DisableUpgradeUI();
    }
    public void PlusADOnClick(){
        GameManager.instance.UpgradeArrowAD();
        ChangeDisabledColor(plusADButton, "#5FFF6E");
        DisableUpgradeUI();
    }
    public void PlusArrowPerShot(){
        GameManager.instance.AddShot();
        ChangeDisabledColor(plusArrowButton, "#5FFF6E");
        DisableUpgradeUI();
    }
    public void SpawnWall(){
        GameManager.instance.SpawnWall();
        maxWalls++;
        Debug.Log("Murallas puestas: "+maxWalls);
        if(maxWalls==3){
            Debug.Log("No deberían aparecer más murallas");
            spawnWalls.GetComponent<Button>().interactable = false;
        }
    }
    public void DisableUpgradeUI(){
        plusLifeButton.GetComponent<Button>().interactable = false;
        plusADButton.GetComponent<Button>().interactable = false;
        plusArrowButton.GetComponent<Button>().interactable = false;
    }
    public void ChangeDisabledColor(GameObject button, string newcolor){
        Color color;
        ColorUtility.TryParseHtmlString(newcolor, out color);
        ColorBlock disabledColor = button.GetComponent<Button>().colors;
        disabledColor.disabledColor = color;
        button.GetComponent<Button>().colors = disabledColor;
    }
}