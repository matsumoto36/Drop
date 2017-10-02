using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// HPによる状態のリスト
/// </summary>
public enum PlayerHPState {
	High,
	Normal,
	Low,
}

/// <summary>
/// 雫を操作するクラス
/// </summary>
public class Player : MonoBehaviour {

	const int PLAYER_MOVABLE_X = 4;
	const int PLAYER_MOVABLE_Y = 7;

	[Header("Player Base Settings")]
	[Header("HP")]
	public int maxHP;

	[Header("摩擦")]
	public float maxFriction;
	public float minFriction;

	[Header("加速度")]
	public float maxAccelPow;
	public float minAccelPow;

	[Header("速度")]
	public float speed;
	public float maxSpeed;

	[Header("大きさ")]
	public float maxSize;
	public float minSize;

	[Header("継続ダメージ(n秒に1ダメ)")]
	public float secPerDamage;

	[Header("Player System Settings")]
	public int[] HPStateTable;

	[Header("死亡時回転速度")]
	public float deathRotSpeed;

	public bool isFreeze = true;

	CameraControl cameraControl;
	Coroutine changeSizeRoutine;
	Vector3 accel;
	bool isDeath;

	Status[] statusEffect;
	float[] statusDuration;

	public int HP {
		get; private set;
	}

	public PlayerHPState HPState {
		get; private set;
	}

	// Use this for initialization
	void Start () {

		cameraControl = FindObjectOfType<CameraControl>();

		statusDuration = new float[Enum.GetNames(typeof(PlayerStatus)).Length];

		//ステータスの効果を持ってくる
		statusEffect = new Status[Enum.GetNames(typeof(PlayerStatus)).Length];
		statusEffect[0] = null;
		statusEffect[1] = new StatusPoison();
		statusEffect[2] = new StatusFly();

		HP = maxHP;
		var size = Mathf.Lerp(minSize, maxSize, (float)HP / maxHP);
		transform.localScale = Vector3.one * size;

		AudioManager.Play(BGMType.Title, 1.0f, true);

		Initialize();
	}

	// Update is called once per frame
	void FixedUpdate () {

		if(isFreeze) return;

		Move();

		if(Input.GetKeyDown(KeyCode.F)) {
			Damage(10);
		}
	}

	void Initialize() {

		isFreeze = false;
		StartCoroutine(ContinuationDamage());
	}

	/// <summary>
	/// その状態かどうかを調べる
	/// </summary>
	/// <returns></returns>
	public bool IsConfStatus(PlayerStatus status) {

		if(status != PlayerStatus.None) {
			return statusDuration[(int)status] != 0;
		}

		bool anyConfStatus = false;
		for(int i = 1;i < statusDuration.Length;i++) {
			anyConfStatus |= statusDuration[(int)status] != 0;
		}

		return anyConfStatus;
	}

	/// <summary>
	/// プレイヤーの状態を一定時間変化させる
	/// </summary>
	/// <param name="status">タイプ</param>
	/// <param name="duration">効果時間</param>
	public void SetStatus(PlayerStatus status, float duration) {
		

		var statusID = (int)status;
		if(statusDuration[statusID] != 0) {
			//既に実行しているので、更新して終了する
			statusDuration[statusID] = duration;
			return;
		}

		statusDuration[statusID] = duration;
		StartCoroutine(ConformStatus(status));
	}

	public void Damage(int pow) {

		Debug.Log("Damage " + pow);

		HP -= pow;

		//0以下なら死亡
		if(HP <= 0) {
			Death();
			return;
		}

		//状態の変更
		if(HP <= HPStateTable[(int)HPState]) HPState++;

		//サイズ変更
		UpdateSize();
	}

	public void Death() {

		Debug.Log("Player Death");

		HP = 0;

		//死亡時のアニメーション開始
		StartCoroutine(PlayerDeathAnim());
	}

	void Move() {

		var pos = transform.position;

		//スピードの決定
		var t = (float)HP / maxHP;
		var accelPow = Mathf.Lerp(minAccelPow, maxAccelPow, 1 - t);
		var friction = Mathf.Lerp(minFriction, maxFriction, t);
		var dir = InputManager.GetAccSensor();

		//移動
		accel += dir * accelPow;
		accel -= accel * friction;

		var moveVec = accel * speed;
		if(moveVec.magnitude > maxSpeed) {
			moveVec = moveVec.normalized * maxSpeed;
		}

		pos += moveVec * Time.deltaTime;

		//X判定
		if(Mathf.Abs(pos.x) > PLAYER_MOVABLE_X) {
			pos.x = pos.x / Mathf.Abs(pos.x) * PLAYER_MOVABLE_X;
			accel.x = 0;
		}

		//Y判定
		var camPosY = cameraControl.transform.position.y;
		var checkPosY = pos.y - camPosY;
		if(Math.Abs(checkPosY) > PLAYER_MOVABLE_Y) {
			pos.y = checkPosY / Mathf.Abs(checkPosY) * PLAYER_MOVABLE_Y + camPosY;
			accel.y = 0;
		}

		transform.position = pos;

		if(!isDeath) {

			//向きの変更
			var rot = Quaternion.AngleAxis(
				Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x) - 90, Vector3.forward);

			transform.rotation =
				Quaternion.Lerp(transform.rotation, rot, 0.3f);
		}

		//カメラの移動
		cameraControl.Move();

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
		yield return new WaitForSeconds(secPerDamage);
		Damage(1);
		StartCoroutine(ContinuationDamage());
	}

	/// <summary>
	/// プレイヤーのサイズの変更
	/// </summary>
	/// <param name="size">新しいサイズ</param>
	/// <returns></returns>
	IEnumerator ChangeSize(Vector3 size) {

		var changeTime = 1.0f;
		var t = 0.0f;

		while(t < changeTime) {
			t += Time.deltaTime;
			transform.localScale = Vector3.Lerp(transform.localScale, size, t);
			yield return null;
		}

		transform.localScale = size;
	}

	IEnumerator ConformStatus(PlayerStatus status) {

		var statusID = (int)status;

		//開始時の処理
		if(statusID == 0) yield break;

		//効果(開始時)
		statusEffect[statusID].StartEffect(this);


		while(statusDuration[statusID] > 0) {
			statusDuration[statusID] -= Time.deltaTime;

			//効果(持続)
			statusEffect[statusID].EffectLoop(this);

			yield return null;
		}
		statusDuration[statusID] = 0;

		//効果(終了時)
		statusEffect[statusID].EndEffect(this);
	}

	IEnumerator PlayerDeathAnim() {

		isDeath = true;
		GetComponent<Collider2D>().enabled = false;

		//サイズを小さくする
		if(changeSizeRoutine != null) StopCoroutine(changeSizeRoutine);
		changeSizeRoutine = StartCoroutine(ChangeSize(new Vector3()));

		float t = 0f;
		while(t < 1.0f) {
			t += Time.deltaTime;

			transform.rotation *= Quaternion.AngleAxis(deathRotSpeed, Vector3.forward);
			yield return null;
		}

		isFreeze = true;

		//ゲームオーバー
	}

	public void _SetPoison() {
		SetStatus(PlayerStatus.Poison, 10.0f);
	}
	public void _SetFly() {
		SetStatus(PlayerStatus.Fly, 10.0f);
	}
}
