using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CheckGyro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += InputManager.GetAccSensor() * Time.deltaTime;
	}
}
