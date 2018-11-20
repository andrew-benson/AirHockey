using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(Vector3.left * 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
