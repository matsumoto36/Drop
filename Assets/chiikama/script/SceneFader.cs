using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SceneMoveType
{
	Short,
	Long,
}

public class SceneFader : MonoBehaviour {

	Image FadeImage;
	GameObject canvas;

	// Use this for initialization
	string SceneName;
	SceneMoveType type;

	void Start () {
		canvas = Instantiate(Resources.Load<GameObject>("Prefabs/Fade"));
		FadeImage = canvas.GetComponentInChildren<Image>();

		//移動するタイプによって、内容を分ける
		switch (type)
		{
			case SceneMoveType.Short:
				StartCoroutine(SceneMove(SceneName));
				break;
			case SceneMoveType.Long:
				StartCoroutine(SceneMoveLong(SceneName));
				break;
			default:
				break;
		}

	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void MoveToScene(string SceneName, SceneMoveType type)//シーン移動
	{
		SceneFader sf = new GameObject("MoveScene").AddComponent<SceneFader>();

		//移動する情報を伝える
		sf.SceneName = SceneName;
		sf.type = type;
	}

	IEnumerator SceneFadeOut(float fadeTime)//フェードアウト
	{
		float alfa = 0;		

		while (alfa <=1)
		{
			FadeImage.color = new Color(0, 0, 0, alfa);
			alfa += Time.deltaTime/fadeTime;
			yield return null;
		}

	}
	IEnumerator SceneFadeIn(float fadeTime)//フェードイン
	{
		float alfa = 1;

		while (alfa >= 0)
		{
			FadeImage.color = new Color(0, 0, 0, alfa);
			alfa -= Time.deltaTime/fadeTime;
			yield return null;
		}


	}

	IEnumerator SceneMove(string SceneName)
	{
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(canvas);
		yield return StartCoroutine(SceneFadeOut(1));//フェードアウト
		SceneManager.LoadScene(SceneName);//シーン移動
		yield return StartCoroutine(SceneFadeIn(1));//フェードイン
		Destroy(canvas);
		Destroy(gameObject);
	}
	IEnumerator SceneMoveLong(string SceneName)
	{
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(canvas);
		yield return StartCoroutine(SceneFadeOut(2));//フェードアウト
		SceneManager.LoadScene(SceneName);//シーン移動
		yield return StartCoroutine(SceneFadeIn(2));//フェードイン
		Destroy(canvas);
		Destroy(gameObject);
	}
}
