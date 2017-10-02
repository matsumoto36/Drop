using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGuide : FloorMove
{
    //ゴールプレファブのインスタンス
    public static GameObject Goal;
    public static GameObject GuidePrefab;

    private void Start()
    {
        //プレファブのインスタンスを作成
        Goal = (GameObject)Resources.Load("Prefabs/GoalBar");
        GuidePrefab = (GameObject)Resources.Load("Prefabs/GoalSymbol");

        //ゴールの高得点域をランダムで取得
        Vector3 GoalPos = new Vector3(Random.Range(-4, 4), Goalpos - 50, 0);

        //生成
        Instantiate(Goal, new Vector3(0, Goalpos - 50, 0), Quaternion.identity);
        Instantiate(GuidePrefab, GoalPos, Quaternion.identity);
    }
}
