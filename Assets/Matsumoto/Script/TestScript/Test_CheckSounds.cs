using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CheckSounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioManager.Play(BGMType.Title, 1.0f, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
