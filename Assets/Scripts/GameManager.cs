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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemies");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnEnemies(){
        Instantiate(enemyWeak, spawnPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Instantiate(enemyStrong, spawnPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Instantiate(enemyWizard, spawnPoint.position, Quaternion.identity);
    }
}
