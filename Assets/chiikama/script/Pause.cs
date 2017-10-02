using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pause : MonoBehaviour {

	// Use this for initialization
	static List<Pause> targets = new List<Pause>();
	Behaviour[] pauseBehavs = null;

	void Start () {
		targets.Add(this);
	}

	void OnDestroy()
	{
		targets.Remove(this);
	}

	void OnPause()//ポーズされたとき
	{
		if(pauseBehavs != null)
		{
			return;
		}
		pauseBehavs = Array.FindAll(GetComponentsInChildren<Behaviour>(), (obj) => {
			if (obj == null)
			{
				return false;
			}
			return obj.enabled;
		});

		foreach (var com in pauseBehavs)
		{
			com.enabled = false;
		}
	}

	void OnResume()//ポーズ解除されたとき
	{
		if(pauseBehavs == null)
		{
			return;
		}
		foreach(var com in pauseBehavs)
		{
			com.enabled = true;
		}
		pauseBehavs = null;

	}

	public static void InPause()
	{
		foreach (Pause obj in FindObjectsOfType<Pause>())
		{
			Debug.Log(obj.gameObject.name);
			if(obj != null)
			{
				obj.OnPause();
			}
		}
	}
	public static void Resume()
	{
		foreach (var obj in targets)
		{
			obj.OnResume();
		}
	}
}

	


