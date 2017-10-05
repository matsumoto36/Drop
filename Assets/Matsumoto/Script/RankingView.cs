using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingView : MonoBehaviour {

	public Text[] rankText;

	// Use this for initialization
	void Start () {
		RankingManager.LoadRanking();

		for(int i = 0;i < 3;i++) {
			rankText[i].text = RankingManager.GetScore(i).ToString();
		}

		AudioManager.Play(BGMType.Menu);
	}

	public void BackButton() {
		AudioManager.Play(SEType.Button);
		SceneFader.MoveToScene("MenuScene", SceneMoveType.Short);
	}
}
