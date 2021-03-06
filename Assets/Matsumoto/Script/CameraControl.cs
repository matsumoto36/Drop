﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	const float STAGE_HEIGHT = 15f;

	Player player;
	public float trackSpeed;
	public bool isFreeze;
	public Vector3 offset;

	int stageCount;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		stageCount = (int)Mathf.Abs(FloorMove.GoalPos / STAGE_HEIGHT) + 1;
	}
	
	// Update is called once per frame
	public void Move () {

		if(isFreeze) return;

		//YのみLerpする
		var pos = transform.position;
		var plPosY = (player.transform.position + offset).y;

		//上に移動した場合はスクロールしない
		if(plPosY > pos.y) return;

		//ステージの下限まで移動した場合はスクロールしない
		if((stageCount - 1) * STAGE_HEIGHT <= Mathf.Abs(pos.y)) {
			pos.y = -(stageCount - 1) * STAGE_HEIGHT;
			transform.position = pos;
			return;
		}

		pos.y = Mathf.Lerp(pos.y, plPosY, trackSpeed);

		transform.position = pos;
	}
}
