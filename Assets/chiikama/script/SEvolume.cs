using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEvolume : MonoBehaviour
{

	[SerializeField]
	UnityEngine.Audio.AudioMixer mixer;


	void Start()
	{
		float Volume;
		mixer.GetFloat("SEVolume", out Volume);
		GetComponent<Slider>().value = Volume;

	}

	public float BGMVolume
	{
		set
		{
			Debug.Log(value);
			mixer.SetFloat("SEVolume", value);
		}

	}

	void Update()
	{
	}

}
