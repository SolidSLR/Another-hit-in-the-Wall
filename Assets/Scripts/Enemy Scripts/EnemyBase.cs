using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float speed;
    public float maxLife;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Tower" || other.gameObject.tag == "Wall"){
            speed = 0;
            Debug.Log("Tower or wall hitted");
        }
    }
}
