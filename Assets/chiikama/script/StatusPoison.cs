using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPoison : Status {

	public override void StartEffect(Player player)
	{
				gameObject.GetComponent<Renderer>().material.color = Color.green;
				Destroy(player.gameObject);
	}

	public override void EffectLoop(Player player)
	{
	}

	public override void EndEffect(Player player)
	{
	}



	// Use this for initialization
	void Start () {
		
	}
}
