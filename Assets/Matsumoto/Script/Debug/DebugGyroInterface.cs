using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugGyroInterface : MonoBehaviour {

	static DebugGyroInterface myInterface;

	public RectTransform panelTransform;
	public Image areaImage;
	public Image buttonImage;

	Vector3 buttonOffset;
	Vector3 panelOffset;

	bool isButtonClick;
	bool isPanelClick;

	void Awake() {
		if(myInterface) {
			Destroy(gameObject);
		}
		else {
			myInterface = this;
			//DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(isButtonClick) MoveButton();
		if(isPanelClick) MovePanel();

		if(Input.GetKeyDown(KeyCode.B)) {
			Debug.Log(_GetPositionNormalize());
		}
	}

	#region Panel

	public void Panel_ButtonDown() {
		isPanelClick = true;

		panelOffset =
			panelTransform.position - Input.mousePosition;
	}
	public void Panel_ButtonUp() {
		isPanelClick = false;
	}

	void MovePanel() {
		panelTransform.position = Input.mousePosition + panelOffset;
	}

	#endregion

	#region Button

	public void Button_ButtonDown() {
		isButtonClick = true;

		buttonOffset = 
			buttonImage.rectTransform.position - Input.mousePosition;
	}
	public void Button_ButtonUp() {
		isButtonClick = false;
	}

	void MoveButton() {

		var mousePos = Input.mousePosition + buttonOffset;
		var areaPos = areaImage.rectTransform.position;
		var areaSize = areaImage.rectTransform.rect.size;
		
		mousePos.x = Mathf.Clamp(mousePos.x, areaPos.x - areaSize.x / 2, areaPos.x + areaSize.x / 2);
		mousePos.y = Mathf.Clamp(mousePos.y, areaPos.y - areaSize.y / 2, areaPos.y + areaSize.y / 2);
		buttonImage.rectTransform.position = mousePos;
	}

	#endregion

	Vector2 _GetPositionNormalize() {

		var areaRect = areaImage.rectTransform.rect;
		var buttonPos = buttonImage.rectTransform.localPosition;

		return new Vector2(
			buttonPos.x / (areaRect.width / 2),
			buttonPos.y / (areaRect.height / 2)
			);
	}

	public static Vector2 GetPositionNormalize() {
		return myInterface._GetPositionNormalize();
	}
}
