using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int life;

    // Update is called once per frame
    void Update()
    {
       if(life<=0){
            Destroy(this.gameObject);
       } 

       if(GameManager.instance.enemiesOnScreen.Count==0){
            UIController.instance.maxWalls = 0;
            Destroy(this.gameObject);
        }
    }
}
