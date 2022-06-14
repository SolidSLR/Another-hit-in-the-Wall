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
    private List<GameObject> enemiesOnScreen;
    public int rounds = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemiesOnScreen = new List<GameObject>();
        StartCoroutine("SpawnEnemiesCorout");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
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
    }
}
