using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizard : EnemyBase
{
    public GameObject spellPrefab;
    private bool canShoot = false;
    private float normalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = speed;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "RangeAttackPos"){
            if(!canShoot){
                canShoot = true;
            }
            speed = 0;
            StartCoroutine("EnemyStartShooting");
            // Empezar ataque a distancia.
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        speed = normalSpeed;
        canShoot = false;
    }
    private IEnumerator EnemyStartShooting(){
        while (canShoot){
            yield return new WaitForSeconds(0.75f);
            Vector2 spellSpawnPos = new Vector2(transform.position.x-0.5f, transform.position.y);
            Instantiate(spellPrefab, spellSpawnPos, Quaternion.identity);
        }
    }
}
