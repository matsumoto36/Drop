using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDummy : MonoBehaviour {
    //アイテムのプレファブ
    public GameObject ItemDrop;



    void Awake()
    {
        //プレファブを同ポジションに生成
        GameObject go = (GameObject)Instantiate(
            ItemDrop,
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

        Gizmos.DrawSphere(this.transform.position, transform.localScale.x);

        //アイテムのプレファブのアイコンを表示
        if (ItemDrop != null)
            Gizmos.DrawIcon(transform.position, ItemDrop.name, true);

    }
}
