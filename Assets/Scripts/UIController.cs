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
    void Start(){
        pauseUI.SetActive(true);
        resumeUI.SetActive(false);
    }
    public void ContinueOnClick(){
        GameManager.instance.rounds++;
        plusLifeButton.GetComponent<Button>().interactable = true;
        plusADButton.GetComponent<Button>().interactable = true;
        plusArrowButton.GetComponent<Button>().interactable = true;
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
    }
    public void PlusLifeOnClic(){
        GameManager.instance.UpgradeTowerLife();
        ChangeDisabledColor(plusLifeButton);
        DisableUpgradeUI();
        //Debug.Log("Incrementar vida de torre");
    }
    public void PlusADOnClick(){
        GameManager.instance.UpgradeArrowAD();
        ChangeDisabledColor(plusADButton);
        DisableUpgradeUI();
        //Debug.Log("Incrementar daño de flechas");
    }
    public void PlusArrowPerShot(){
        GameManager.instance.AddShot();
        ChangeDisabledColor(plusArrowButton);
        DisableUpgradeUI();
        //Debug.Log("Añadir una flecha más por disparo");
    }
    public void DisableUpgradeUI(){
        Debug.Log("Se inhabilitarán los botones de mejora");

        plusLifeButton.GetComponent<Button>().interactable = false;
        plusADButton.GetComponent<Button>().interactable = false;
        plusArrowButton.GetComponent<Button>().interactable = false;
    }
    public void ChangeDisabledColor(GameObject button){
        Color color;
        ColorUtility.TryParseHtmlString("#5FFF6E", out color);
        ColorBlock disabledColor = button.GetComponent<Button>().colors;
        disabledColor.disabledColor = color;
        button.GetComponent<Button>().colors = disabledColor;
    }
}
