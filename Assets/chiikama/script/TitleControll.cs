using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleControll : MonoBehaviour {
	public void ToMenuScene()
	{
		SceneFader.MoveToScene("MenuScene", SceneMoveType.Short);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
