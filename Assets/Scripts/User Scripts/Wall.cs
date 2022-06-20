using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public static Wall instance;
    public int life;
    void Awake(){
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       if(life<=0){
        Destroy(gameObject);
       } 
    }
}
