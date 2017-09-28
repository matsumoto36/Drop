using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{

    GameObject[] floor = new GameObject[3];
    Transform Player;
    float LoadPos;
    int j, k, l, m;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < floor.Length; i++)
        {
            floor[i] = GameObject.Find("Floor" + i);
        }
        Player = GameObject.Find("Player").transform;
        LoadPos = 30;
        j = 0;k = 1; l = 2;m = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Player.position.y >= LoadPos)
        {
            floor[j].transform.position += Vector3.up * 60;
            LoadPos += 20;
            j = k;k = l;l = m;m = j;
        }
	}
}
