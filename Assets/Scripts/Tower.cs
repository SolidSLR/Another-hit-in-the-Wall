using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int maxLife = 500;
    public int actualLife;
    public static Tower instance;
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }
    void Start()
    {
        actualLife = maxLife;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other){
        // Código temporal para comprobar que se lanza la UI
        Destroy(other.gameObject);
        // Usar para ejecutar animación de sacudida
    }
}
