using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : MonoBehaviour {

	public void ToMainMode()
	{
		AudioManager.Play(SEType.Button);
		AudioManager.FadeOut(2);

		SceneFader.MoveToScene("Game",SceneMoveType.Long);
	}

	public void ToTitleScene()
	{
		AudioManager.Play(SEType.Button);
		AudioManager.FadeOut(1);

		SceneFader.MoveToScene("TitleScene",SceneMoveType.Short);
	}

	public void ToRanking() {

		AudioManager.Play(SEType.Button);
		AudioManager.FadeOut(1);

		SceneFader.MoveToScene("RankingScene", SceneMoveType.Short);
	}

	// Use this for initialization
	void Start () {
		AudioManager.FadeIn(1, BGMType.Menu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
