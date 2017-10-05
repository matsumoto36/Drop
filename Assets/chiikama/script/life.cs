using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour {
	Player player;
	void Start() {
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Player") {
			Debug.Log("life");
			AudioManager.Play(SEType.Heal);
			player.Damage(-10);
			Destroy(gameObject);
		}

	}

}

// Use this for initialization



// Update is called once per frame


