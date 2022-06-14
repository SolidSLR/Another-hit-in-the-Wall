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
    private int rounds = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemiesOnScreen = new List<GameObject>();
        rounds=6;
        StartCoroutine("SpawnEnemiesCorout");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Objetos en lista "+enemiesOnScreen.Count);
    }
    private IEnumerator SpawnEnemiesCorout(){
        /*Instantiate(enemyWeak, spawnPoint);
        yield return new WaitForSeconds(2f);
        Instantiate(enemyStrong, spawnPoint);
        yield return new WaitForSeconds(2f);
        Instantiate(enemyWizard, spawnPoint);*/
        int x = 0;
        while(x<rounds){
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWeak, spawnPoint));
            x++;
        }
        x = 0;
        while(x<rounds-1){
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyStrong, spawnPoint));
            x++;
        }
        x = 0;
        while(x<rounds-3){
            yield return new WaitForSeconds(1f);
            enemiesOnScreen.Add(Instantiate(enemyWizard, spawnPoint));
            x++;
        }
    }
}
