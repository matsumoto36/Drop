using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CheckSounds : MonoBehaviour {

	public SEType SEtype;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySounds() {
		AudioManager.Play(SEtype);
	}
}
