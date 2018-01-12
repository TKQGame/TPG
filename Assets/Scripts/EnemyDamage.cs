using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public WallHp whp;
    public float damage = 10f;
    public float timeDamage = 1f;

	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
            Invoke("GiveDamage", timeDamage);
    }

    void GiveDamage()
    {
        whp.healthWall -=  damage;
    }

}
