using UnityEngine;
using UnityEngine.UI;

public class BGMVolumes : MonoBehaviour {


    [SerializeField]
    UnityEngine.Audio.AudioMixer mixer;

    public Animator SizukuAnim;

    float animTime = 0;
    float prevValue;

    void Start()
    {
        float bgmVolume;
        mixer.GetFloat("BGMVolume", out bgmVolume);
        GetComponent<Slider>().value = prevValue = bgmVolume;
        SizukuAnim.speed = 0;
    }

    public float BGMVolume
    {
        set
        {
            mixer.SetFloat("BGMVolume", value);

            float delta = value - prevValue;
            SizukuAnim.speed = Mathf.Abs(delta * 2);
            animTime = 0.1f;

            prevValue = value;
        }

    }

    void Update()
    {

        if (animTime > 0)
        {
            animTime -= Time.deltaTime;
            if (animTime <= 0)
            {
                animTime = 0;
                SizukuAnim.speed = 0;
            }

        }
    }

}
