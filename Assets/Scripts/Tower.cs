using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Vida máxima. 
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
        Debug.Log("Vida actual "+actualLife);
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Hitted by enemy");
        }
    }
}
