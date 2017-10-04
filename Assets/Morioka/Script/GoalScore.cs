using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScore : FloorMove
{

    int flg;
    public float mag;
    GameManager gmManage;

    private void Start()
    {
        flg = 0;
        mag = 1;
        gmManage = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (player.position.y < GoalPos && flg == 0)   
        {
            gmManage.GameClear();
            Debug.Log("ゴール！");
            flg++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        mag = 1.5f;
        Debug.Log("フラグ");
    }
}
