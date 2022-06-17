using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Contador de rondas. Control de Game Over. Control de interfaz. Control de cambio de escena.
    // Spawn de enemigos. 
    public Transform spawnPoint;
    public GameObject enemyWeak;
    public GameObject enemyStrong;
    public GameObject enemyWizard;
    public GameObject betweenRoundsUI;
    public GameObject pauseUI;
    public static GameManager instance;
    public bool canSpawn;
    public List<GameObject> enemiesOnScreen;
    // Incrementar rondas al hacer click en "Continuar" en el UI
    public int rounds = 1;
    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        betweenRoundsUI.SetActive(false);
        canSpawn = true;
        enemiesOnScreen = new List<GameObject>();
        StartCoroutine("SpawnEnemiesCorout");
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine("CheckForUI");
        if(Tower.instance.actualLife == 0){
            Debug.Log("Torre KO: "+Tower.instance.actualLife);
            Time.timeScale = 0;
            // Lanzar GameOver
        }
        Debug.Log("Valor de rounds "+rounds+" Valor de canSpawn: "+canSpawn+" Enemigos en lista "+enemiesOnScreen.Count);
    }
    // Llamar a la corrutina al hacer click en "Continuar" en el UI
    private IEnumerator SpawnEnemiesCorout(){
        if(rounds == 1){
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
        }else if(rounds == 2){
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
        }else if(rounds == 3){
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyStrong, spawnPoint));
        }else if(rounds == 4){
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyStrong, spawnPoint));
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWizard, spawnPoint));
        }else{
            int x = 0;
            while(x<rounds){
                float random = Random.Range(0f,1f);
                if(random < 0.5f){
                    yield return new WaitForSeconds(1f);
                    enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
                }else if(random >= 0.5f && random < 0.8f){
                    yield return new WaitForSeconds(1f);
                    enemiesOnScreen.Add(Instantiate(enemyStrong, spawnPoint));
                }else if(random >= 0.8f){
                    yield return new WaitForSeconds(1f);
                    enemiesOnScreen.Add(Instantiate(enemyWizard, spawnPoint));
                }
                x++;
            }
        }
        canSpawn = false;
    }
    private IEnumerator CheckForUI(){
        yield return new WaitForSeconds(1.5f);
        if(enemiesOnScreen.Count == 0 && !canSpawn){
            // Lanzar UI
            betweenRoundsUI.SetActive(true);
            pauseUI.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void NextRound(){
        canSpawn = true;
        betweenRoundsUI.SetActive(false);
        pauseUI.SetActive(true);
        StartCoroutine("SpawnEnemiesCorout");
        Time.timeScale = 1;
    }
    public void PauseGame(){
        Time.timeScale = 0;
    }
    public void ResumeGame(){
        Time.timeScale = 1;
    }
}
