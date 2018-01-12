using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D myRigidbody;
    public float moveSpeed;
    public float timeToDestroy;


    void Start()
    {
        
            
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddRelativeForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);

    }
    private void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if(timeToDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")// wall nahyi
        {
            Destroy(this.gameObject);

        }

    }
}

