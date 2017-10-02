using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGuide : FloorMove
{

    public static GameObject GuidePrefab;

    private void Start()
    {
        GuidePrefab = (GameObject)Resources.Load("Prefabs/GuideSymbol");
    }

    public static void guideChoose()
    {
        Vector3 Goalpos = new Vector3(Random.Range(-5, 5), 1000, 0);
        Instantiate(GuidePrefab, Goalpos, Quaternion.identity);
    }
}
