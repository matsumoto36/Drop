﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour {
	Player player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(!player.IsConfStatus(PlayerStatus.Fly)) {

				AudioManager.Play(SEType.Hole_in_Drop);
				player.Death(DeathType.Hole);
			}
		}
	}
}
