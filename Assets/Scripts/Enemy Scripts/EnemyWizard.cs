using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizard : EnemyBase
{
    public GameObject spellPrefab;
    private bool canShoot = false;
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

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "RangeAttackPos"){
            canShoot = true;
            speed = 0;
            StartCoroutine("EnemyStartShooting");
            // Empezar ataque a distancia.
        }
    }

    private IEnumerator EnemyStartShooting(){
        while (canShoot){
            yield return new WaitForSeconds(0.75f);
            Vector2 spellSpawnPos = new Vector2(transform.position.x-0.5f, transform.position.y);
            Instantiate(spellPrefab, spellSpawnPos, Quaternion.identity);
        }
    }
}
