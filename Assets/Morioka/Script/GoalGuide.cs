using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGuide : FloorMove
{
    //ゴールプレファブのインスタンス
    public static GameObject Goal;
    public static GameObject GuidePrefab;
    public static Vector3 HighPos;

    private void Start()
    {
        //プレファブのインスタンスを作成
        Goal = (GameObject)Resources.Load("Prefabs/GoalBar");
        GuidePrefab = (GameObject)Resources.Load("Prefabs/GoalSymbol");

        //ゴールの高得点域をランダムで取得
        HighPos = new Vector3(Random.Range(-4, 4), GoalPos, 0);

        //生成
        Instantiate(Goal, new Vector3(0, GoalPos, 0), Quaternion.identity);
        Instantiate(GuidePrefab, HighPos, Quaternion.identity);
    }

    private void Update()
    {
        
    }
}
