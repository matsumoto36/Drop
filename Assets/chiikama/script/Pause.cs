using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pause : MonoBehaviour {
	Behaviour[] pauseBehavs = null;
	// Use this for initialization
	void Start () {
		
	}
	void OnPause()
	{
		if (pauseBehavs != null)
		{
			return;
		}
		//有効なBehaviourを取得
		pauseBehavs = Array.FindAll(GetComponentsInChildren<Behaviour>(), (obj) => { return obj.enabled; });
		foreach (var com in pauseBehavs)
		{
			com.enabled = false;
		}
	}
	void OnResume()
	{
		if (pauseBehavs == null)
		{
			return;
		}

		// ポーズ前の状態にBehaviourの有効状態を復元
		foreach (var com in pauseBehavs)
		{
			com.enabled = true;
		}

		pauseBehavs = null;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
