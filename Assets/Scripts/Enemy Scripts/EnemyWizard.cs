using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizard : EnemyBase
{
    public int attackPower;
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
            Debug.Log("I'm a wizard and I've reached the attack point");
            // Empezar ataque a distancia.
        }
    }

    private IEnumerator EnemyStartShooting(){
        while (canShoot){
            yield return new WaitForSeconds(1.5f);
            Instantiate(spellPrefab, transform.position, Quaternion.identity);
        }
    }
}
