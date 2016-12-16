using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Quaternion rot = this.GetComponent<Rigidbody>().transform.rotation;
        //this.GetComponent<Rigidbody>().transform.rotation = new Quaternion(rot.x + 15.0f, 0.0f, 0.0f, 1.0f);
        //this.GetComponent<Rigidbody>().transform.Rotate(new Vector3(15.0f, 0.0f, 0.0f));
        this.transform.Rotate(new Vector3(0.0f, 0.0f, 10.0f));
	}
}
