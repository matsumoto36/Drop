using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour {


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
			Destroy(gameObject);
		}

	}

	//transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 1), transform.position.z);
}
