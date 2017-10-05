using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMvolume : MonoBehaviour
{

	[SerializeField]
	UnityEngine.Audio.AudioMixer mixer;


	void Start()
	{
		float Volume;
		mixer.GetFloat("BGMVolume", out Volume);
		GetComponent<Slider>().value = Volume;

	}

	public float BGMVolume
	{
		set
		{
			Debug.Log(value);
			mixer.SetFloat("BGMVolume", value);
		}

	}

	void Update()
	{
	}

}
