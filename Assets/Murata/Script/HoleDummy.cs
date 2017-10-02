using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDummy : MonoBehaviour {

    //穴のプレファブ
    public GameObject EnemyHole;



    void Awake()
    {
        //プレファブを同ポジションに生成
        GameObject go = (GameObject)Instantiate(
            EnemyHole,
            Vector3.zero,
            Quaternion.identity
            );
        go.transform.localScale = transform.localScale;
        //一緒に削除されるように生成した敵オブジェクトを子に設定
        go.transform.SetParent(transform, false);

    }

    //ステージエディット中のためにシーンにキズモを表示
    void OnDrawGizmos()
    {
       

        //球を表示
        //球の色
        Gizmos.color = new Color(1, 0, 0, 0.5f);

        Gizmos.DrawSphere(this.transform.position ,transform.localScale.x);

        //穴のプレファブのアイコンを表示
        if (EnemyHole != null)
            Gizmos.DrawIcon(transform.position , EnemyHole.name, true);
       
    }
}
