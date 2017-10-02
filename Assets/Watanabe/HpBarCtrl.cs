﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarCtrl : MonoBehaviour {
    Slider _slider;
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    float _hp = 0;
    void Update()
    {
        // HP上昇
        _hp += 1;
        if (_hp > _slider.maxValue)
        {
            // 最大を超えたら0に戻す
            _hp = _slider.minValue;
        }

        // HPゲージに値を設定
        _slider.value = _hp;
    }
}
