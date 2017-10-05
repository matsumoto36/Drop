using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	private new SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		Player player = collider.GetComponent<Player>();
		if(player)
		{
			if (player.IsConfStatus(PlayerStatus.Poison))
			{
				Destroy(gameObject);
			}
			else
			{
				AudioManager.Play(SEType.Worm);
				Debug.Log("damege");
				player.Damage(10);
			}

		}
	}

	


}
