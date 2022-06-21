using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public int attackPower;
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up/3 * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Tower"){
            Tower.instance.actualLife -= attackPower;
        }
        if(other.gameObject.tag == "Wall"){
            other.gameObject.GetComponent<Wall>().life -= attackPower;
        }
        if(other.gameObject.tag == "Tower" || other.gameObject.tag == "Wall"){
            Destroy(gameObject);
        }
    }
}
