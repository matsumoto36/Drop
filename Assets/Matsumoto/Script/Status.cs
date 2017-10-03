using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 雫の状態のリスト
/// </summary>
public enum PlayerStatus {
	None,
	Poison,
	Fly,
}

/// <summary>
/// ステータス効果の親クラス。
/// </summary>
public abstract class Status {

	/// <summary>
	/// 効果開始時の処理
	/// </summary>
	public abstract void StartEffect(Player player);

	/// <summary>
	/// 効果継続中の処理
	/// </summary>
	public abstract void EffectLoop(Player player);

	/// <summary>
	/// 効果終了時の処理
	/// </summary>
	/// <param name="player">プレイヤー</param>
	public abstract void EndEffect(Player player);
}
