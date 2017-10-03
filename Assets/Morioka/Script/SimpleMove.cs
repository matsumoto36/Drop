using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position -= Vector3.up * 0.5f;
        Camera.main.transform.position = new Vector3(0, Vector3.Lerp(Camera.main.transform.position, transform.position, .1f).y, -10);
	}
}
