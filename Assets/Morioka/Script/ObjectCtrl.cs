using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : FloorMove
{
    //プレファブとシーン上のオブジェクトの配列
    GameObject[] objects = new GameObject[25];
    GameObject[] sceneObjects = new GameObject[3];

    //乱数選出時同じものが出ないようにするための変数
    List<int> choose = new List<int>();

    //instantiate時の座標指定変数
    Vector3 instancePos = new Vector3(0, 30, 0);
    int temp, i, j, l, f;

    // Use this for initialization
    void Start ()
    {
        //配列にインスタンスを付与
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = (GameObject)Resources.Load("Prefabs/Objects/Object" + i);
            choose.Add(i);
        }
        for (int i = 0; i < sceneObjects.Length; i++)
        {
            sceneObjects[i] = GameObject.Find("Object" + i);
        }

        //変数初期化
        i = 0;j = 1;l = 2;f = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //playerのpositionからオブジェクトを更新
        if (player.position.y <= LoadPos)
        {
            //乱数でプレファブから選択、選択したものは次回選択から除外
            int selectIndex = choose[Random.Range(0, choose.Count)];
            choose.Remove(selectIndex);
            Destroy(sceneObjects[i].gameObject);
            //消したオブジェクトの一つ上のものを基点としてインスタンス、配列に代入
            sceneObjects[i] = Instantiate(objects[selectIndex], sceneObjects[j].transform.position-instancePos, Quaternion.identity) as GameObject;
            choose.Add(temp);
            temp = selectIndex;
            i = j;j = l;l = f;f = i;
        }
	}
}
