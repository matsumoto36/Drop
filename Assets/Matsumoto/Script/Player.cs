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

	public float friction;
	public float accelPow;

	public float maxSpeed;
	public float minSpeed;

	public float maxSize;
	public float minSize;

	public float damagePerSec;
	float dps = 0;

	[Header("Player System Settings")]
	public int[] HPStateTable;

	public PlayerHPState HPState {
		get; private set;
	}

	public PlayerStatus status {
		get; private set;
	}

	bool isFreeze = true;
	Coroutine changeSizeRoutine;
	Vector3 accel;


	// Use this for initialization
	void Start () {
		HP = maxHP;
		var size = Mathf.Lerp(minSize, maxSize, (float)HP / maxHP);
		transform.localScale = Vector3.one * size;

		AudioManager.Play(BGMType.Title, 1.0f, true);

		Initialize();
	}

	void Initialize() {

		isFreeze = false;
		StartCoroutine(ContinuationDamage());
	}

	// Update is called once per frame
	void Update () {

		if(isFreeze) return;

		Move();

		if(Input.GetKeyDown(KeyCode.F)) {
			Damage(10);
		}
	}

	void Move() {

		//スピードの決定
		var speed = Mathf.Lerp(minSpeed, maxSpeed, 1 - (float)HP / maxHP);

		//移動
		accel += InputManager.GetAccSensor() * accelPow * (1 - friction);
		transform.position += accel * speed * Time.deltaTime;

		//向きの変更
		transform.rotation = Quaternion.AngleAxis(
			Mathf.Rad2Deg * Mathf.Atan2(accel.y, accel.x) - 90, Vector3.forward);
	}

	public void Damage(int pow) {

		Debug.Log("Damage " + pow);

		HP -= pow;

		//0以下なら死亡
		if(HP <= 0) {
			Death();
			return;
		}

		//サイズ変更
		UpdateSize();
	}

	public void Death() {

		Debug.Log("Player Death");

		HP = 0;

		if(changeSizeRoutine != null) StopCoroutine(changeSizeRoutine);
		changeSizeRoutine = StartCoroutine(ChangeSize(new Vector3()));

		//ゲームオーバー
	}

	void UpdateSize() {

		var size = Mathf.Lerp(minSize, maxSize, (float)HP / maxHP);
		if(changeSizeRoutine != null) StopCoroutine(changeSizeRoutine);
		changeSizeRoutine = StartCoroutine(ChangeSize(Vector3.one * size));
	}

	/// <summary>
	/// 持続ダメージ
	/// </summary>
	/// <returns></returns>
	IEnumerator ContinuationDamage() {
		yield return new WaitForSeconds(1.0f / damagePerSec);
		Damage(1);
		StartCoroutine(ContinuationDamage());
	}

	/// <summary>
	/// プレイヤーのサイズの変更
	/// </summary>
	/// <param name="size">新しいサイズ</param>
	/// <returns></returns>
	IEnumerator ChangeSize(Vector3 size) {

		var changeSpeed = 0.1f;
		var changeTime = 1.0f;
		var t = 0.0f;

		while(t < changeTime) {
			t += Time.deltaTime;
			transform.localScale = Vector3.Lerp(transform.localScale, size, changeSpeed);
			yield return null;
		}

		transform.localScale = size;
	}
}
