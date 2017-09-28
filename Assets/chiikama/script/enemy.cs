using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public bool damege = false;//フラグ
	private new SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(!damege && collider.gameObject.tag == "enemy")
		{
			Debug.Log("damege"); 
			                                  
			
		}
	}

	


}
