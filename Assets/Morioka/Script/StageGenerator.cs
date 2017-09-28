using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    //背景（床）のインスタンス
    GameObject FloorPrefab;
    GameObject[] Floor = new GameObject[3];

    //タイムカウントの正負を決定
    public static int SamDif = 0;

    // Use this for initialization
    public void Generat(int id)
    {
        Vector2 pos = Vector2.zero;
        FloorPrefab = (GameObject)Resources.Load("Prefabs/BackGround");
        Debug.Log(FloorPrefab);
        for (int i = 0; i < Floor.Length; i++)
        {
            Debug.Log("きーたよ");
            Floor[i] = Instantiate(FloorPrefab, pos, Quaternion.identity) as GameObject;
            Floor[i].name = "Floor" + i;
            pos.y += 19.2f;
            SamDif = id;
        }
    }
}
