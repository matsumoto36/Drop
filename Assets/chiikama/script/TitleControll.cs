using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleControll : MonoBehaviour {
	public void ToMenuScene()
	{

	}
	// Use this for initialization
	void Start () {
		AudioManager.FadeIn(1, BGMType.Title);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			AudioManager.Play(SEType.Button);
			AudioManager.FadeOut(1);

			SceneFader.MoveToScene("MenuScene", SceneMoveType.Short);
		}
	}
}
