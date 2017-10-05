using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : MonoBehaviour {

	public void ToMainMode()
	{
		SceneFader.MoveToScene("Game",SceneMoveType.Long);
	}

	public void ToTitleScene()
	{
		SceneFader.MoveToScene("TitleScene",SceneMoveType.Short);
	}


	// Use this for initialization
	void Start () {
		AudioManager.FadeIn(1, BGMType.Menu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
