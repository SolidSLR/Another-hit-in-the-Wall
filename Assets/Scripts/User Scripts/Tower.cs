using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int maxLife = 500;
    public int actualLife;
    public static Tower instance;
    public GameObject arrow;
    public Transform arrowSpawn;
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }
    void Start()
    {
        actualLife = maxLife;
        StartCoroutine("SpawnShot");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other){
        // Código temporal para comprobar que se lanza la UI
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Vida actual: "+actualLife+" Vida máxima: "+maxLife);
        }
        // Usar para ejecutar animación de sacudida
    }
    public IEnumerator SpawnShot(){
        // Código temporal para pruebas
        while(true){
            yield return new WaitForSeconds(0.3f);
            GameObject newArrow = Instantiate(arrow, arrowSpawn.position, Quaternion.identity);
            newArrow.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(0.001f, 0.15f), ForceMode2D.Impulse);
        }
    }
}
