using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusFly : Status {

	public override void StartEffect(Player player)
	{
		Vector3 pos = player.transform.position;
		pos.z -= 2f;
		player.transform.position = pos;
		Debug.Log("fly");
	}

	public override void EffectLoop(Player player)
	{
		//player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Mathf.PingPong(Time.time, 1));//Mathf.PingPong(Time.time, 1)
	}

	public override void EndEffect(Player player)
	{
		Vector3 pos = player.transform.position;
		pos.z +=2;
		player.transform.position = pos;
	}

}
