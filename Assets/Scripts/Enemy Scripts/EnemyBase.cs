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
       transform.parent = null; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Tower" || other.gameObject.tag == "Wall"){
            StartCoroutine("MeleeAttackCorout");
            Debug.Log("Tower or wall hitted");
        }
    }
    public IEnumerator MeleeAttackCorout(){
        speed = -speed;
        yield return new WaitForSeconds(0.4f);
        speed = -speed;
    }
}
