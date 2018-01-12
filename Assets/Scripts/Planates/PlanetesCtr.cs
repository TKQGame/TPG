using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetesCtr : MonoBehaviour {
    public Collider coll; 
    private Vector2 MousePos;

    public Vector3 someObject;
	void Start () {
		
	}

    private void OnMouseDown()
    {
        if(coll.gameObject.tag == "Planet"){
           
        }
    }
    void Update () {
        transform.Rotate(new Vector3(1, Time.deltaTime, 0));
      

    }
}
