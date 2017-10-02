using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	const float STAGE_HEIGHT = 15f;

	Player player;
	public float trackSpeed;
	public bool isFreeze;

	//Debug
	public int _StageCount;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	public void Move () {

		if(isFreeze) return;

		//YのみLerpする
		var pos = transform.position;

		//上に移動した場合はスクロールしない
		if(player.transform.position.y > pos.y) return;

		//ステージの下限まで移動した場合はスクロールしない
		if((_StageCount - 1) * STAGE_HEIGHT <= Mathf.Abs(pos.y)) {
			pos.y = -(_StageCount - 1) * STAGE_HEIGHT;
			transform.position = pos;
			return;
		}

		pos.y = Mathf.Lerp(pos.y, player.transform.position.y, trackSpeed);

		transform.position = pos;
	}
}
