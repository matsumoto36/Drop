using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

	Image FadeImage;
	GameObject canvas;

	// Use this for initialization
	string SceneName;

	void Start () {
		canvas = Instantiate(Resources.Load<GameObject>("Prefabs/Fade"));
		FadeImage = canvas.GetComponentInChildren<Image>();
		StartCoroutine(SceneMove(SceneName));
	}
	
	// Update is called once per frame
	void Update () {

	}
	public static void MoveToScene(string SceneName)
	{
		SceneFader sf = new GameObject("MoveScene").AddComponent<SceneFader>();
		sf.SceneName = SceneName;
	}

	IEnumerator SceneFadeOut()
	{
		float alfa = 0;
		float fadeSpeed = 0.5f;
		

		while (alfa <=1)
		{
			FadeImage.color = new Color(0, 0, 0, alfa);
			alfa += fadeSpeed * Time.deltaTime;
			yield return null;
		}

	}
	IEnumerator SceneFadeIn()
	{
		float alfa = 1;
		float fadeSpeed = 0.5f;

		while (alfa >= 0)
		{
			FadeImage.color = new Color(0, 0, 0, alfa);
			alfa -= fadeSpeed * Time.deltaTime;
			yield return null;
		}


	}

	IEnumerator SceneMove(string SceneName)
	{
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(canvas);
		yield return StartCoroutine(SceneFadeOut());//フェードアウト
		SceneManager.LoadScene(SceneName);//シーン移動
		yield return StartCoroutine(SceneFadeIn());//フェードイン
		Destroy(canvas);
		Destroy(gameObject);
	}
}
