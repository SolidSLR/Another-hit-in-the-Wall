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
    public bool canSpawn;
    private List<GameObject> enemiesOnScreen;
    // Incrementar rondas al hacer click en "Continuar" en el UI
    public int rounds = 1;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        enemiesOnScreen = new List<GameObject>();
        StartCoroutine("SpawnEnemiesCorout");
    }
    // Update is called once per frame
    void Update()
    {
        if(Tower.instance.actualLife == 0){
            Time.timeScale = 0;
            // Lanzar GameOver
        }

        if(enemiesOnScreen.Count == 0 && !canSpawn){
            // Lanzar UI
            Time.timeScale = 0;
        }
    }
    // Llamar a la corrutina al hacer click en "Continuar" en el UI
    private IEnumerator SpawnEnemiesCorout(){
        Debug.Log("Entro en corrutina");
        if(rounds == 1){
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
        }else if(rounds == 2){
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
        }else if(rounds == 3){
            Debug.Log("Deberían empezar a salir bichos");
            yield return new WaitForSeconds(1f);
            Debug.Log("Debería salir un enemigo débil");
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
}
