using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizard : EnemyBase
{
    public int attackPower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "RangeAttackPos" && gameObject.tag == "EnemyWizard"){
            speed = 0;
            Debug.Log("I'm a wizard and I've reached the attack point");
            // Empezar ataque a distancia.
        }
    }
}
