using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HPによる状態のリスト
/// </summary>
public enum PlayerHPState {
	High,
	Normal,
	Low,
}

/// <summary>
/// 雫の状態のリスト
/// </summary>
public enum PlayerStatus {
	None,
	Poison,
	Fly,
}

/// <summary>
/// 雫を操作するクラス
/// </summary>
public class Player : MonoBehaviour {

	[Header("Player Base Settings")]
	public int maxHP;
	int HP;
	public float speed;
	public float friction;
	public float maxSize;
	public float minSize;

	[Header("Player System Settings")]
	public int[] HPStateTable;

	public PlayerHPState HPState {
		get; private set;
	}

	public PlayerStatus status {
		get; private set;
	}

	Vector3 accel;


	// Use this for initialization
	void Start () {
		HP = maxHP;
		var size = Mathf.Lerp(minSize, maxSize, (float)HP / maxHP);
		transform.localScale = Vector3.one * size;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move() {
		accel += InputManager.GetAccSensor() * 0.1f * (1 - friction);
		transform.position += accel * speed * Time.deltaTime;
	}

	public void Damage(int pow) {

		HP -= pow;
		if(HP < 0) HP = 0;

		//サイズ変更
		var size = Mathf.Lerp(minSize, maxSize, (float)HP / maxHP);
		transform.localScale = Vector3.one * size;

	}

	public void Death() {

		//

		//

		//ゲームオーバー
	}


}
