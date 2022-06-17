using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    public int damage = 0;
    Arrow arrow;
    // Start is called before the first frame update
    void Start()
    {
        arrow = GetComponentInParent<Arrow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.CompareTag("Enemy")){
            Debug.Log("Se restarán "+damage+" puntos de vida al enemigo");
            Destroy(arrow.gameObject);
        }
        if(other.gameObject.CompareTag("Ground")){
            Destroy(arrow.gameObject);
        }
    }
}
