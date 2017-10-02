using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : MonoBehaviour {

	public void ToMainMode()
	{
		SceneFader.MoveToScene("test",SceneMoveType.Long);
	}

	public void ToEndlessMode()
	{
		//SceneFader.MoveToScene("EndlessMode");
	}

	public void ToTitleScene()
	{
		SceneFader.MoveToScene("TitleScene",SceneMoveType.Short);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
