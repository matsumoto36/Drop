using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFly : MonoBehaviour {
	Player player;
	void Start()
	{
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
					Debug.Log("poison");
					player.SetStatus(PlayerStatus.Fly, 10.0f);
			        Destroy(gameObject);
		}

			}

		}
	
	// Use this for initialization


	
	// Update is called once per frame


