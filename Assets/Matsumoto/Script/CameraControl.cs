using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	Player player;
	public float trackSpeed;
	public bool isFreeze;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	public void Move () {

		if(isFreeze) return;

		//YのみLerpする
		var pos = transform.position;

		if(player.transform.position.y > pos.y) return;

		pos.y = Mathf.Lerp(pos.y, player.transform.position.y, trackSpeed);

		transform.position = pos;
	}
}
