using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPoison : Status {

	public override void StartEffect(Player player)
	{
		player.GetComponent<Renderer>().material.color = Color.green;
		Debug.Log("green");
			
	}


	public override void EffectLoop(Player player)
	{
	}

	public override void EndEffect(Player player)
	{
		player.GetComponent<Renderer>().material.color = Color.white;
	}



	// Use this for initialization
	void Start () {
		
	}
}
