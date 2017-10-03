using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	public bool isPause;
	public static bool isFreeze = false;
	bool _isPause;
	bool isActiveMenu = false;

	public GameObject GameMenu;

	public void Awake()
	{
	
	
		Pause.ClearPauseList();
	}

	public void RetryButton()
	{
		SceneFader.MoveToScene("test", SceneMoveType.Short);
	}
	public void BackButton()
	{

	}

	public void MenuButton()
	{
		SceneFader.MoveToScene("MenuScene", SceneMoveType.Short);
	}


	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

		if (isPause != _isPause)
		{
			_isPause = isPause;
			SetPause(_isPause);
		}
	}

	/// <summary>
	/// メニューの表示・非表示を切り替える
	/// </summary>
	public void ToggleMenu()
	{
		if (isFreeze) return;
		isActiveMenu = !isActiveMenu;
		GameMenu.SetActive(isActiveMenu);
		SetPause(isActiveMenu);

	}

	void SetPause(bool enable)
	{
		if (enable)
		{
			Pause.Pauser();
		}
		else
		{
			Pause.Resume();
		}
	}
}
