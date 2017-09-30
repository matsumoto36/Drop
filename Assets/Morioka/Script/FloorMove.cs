using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{

    GameObject[] floor = new GameObject[3];
    public static Transform player;
    public static float LoadPos;
    int a,b,c,d;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < floor.Length; i++)
        {
            floor[i] = GameObject.Find("Floor" + i);
        }
        player = GameObject.Find("Player").transform;
        LoadPos = 30;
        a = 0;b = 1;c = 2;d = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player.position.y >= LoadPos)
        {
            floor[a].transform.position += Vector3.up * 60;
            LoadPos += 20;
            a = b;b = c;c = d;d = a;
        }
        if (player.position.y > 1000)
        {
            GoalGuide.guideChoose();
        }
	}
}
