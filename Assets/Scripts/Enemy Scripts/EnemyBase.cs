using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float speed;
    public float life;
    public int attackPower;
    // Start is called before the first frame update
    void Start()
    {
       transform.parent = null; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(life<=0){
            GameManager.instance.enemiesOnScreen.Remove(gameObject);
            Destroy(gameObject);
        }
        //Debug.Log("Vida actual: "+life);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Tower"){
            StartCoroutine("MeleeAttackCorout");
            Tower.instance.actualLife  -= attackPower;
        }

        if(other.gameObject.tag == "Wall"){
            StartCoroutine("MeleeAttackCorout");
            other.gameObject.GetComponent<Wall>().life -= attackPower;
        }
    }
    public IEnumerator MeleeAttackCorout(){
        speed = -speed;
        yield return new WaitForSeconds(0.4f);
        speed = -speed;
    }
}
