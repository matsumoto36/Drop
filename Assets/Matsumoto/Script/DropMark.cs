using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMark : MonoBehaviour {

	public float multiPly;
	public Vector2 dir;

	// Use this for initialization
	void Start () {
		StartCoroutine(FadeDropMark());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FadeDropMark() {

		var markRenderer = GetComponent<SpriteRenderer>();
		var startSize = transform.localScale;

		var t = 0.0f;
		while(t < 1.0f) {
			t += Time.deltaTime * multiPly / startSize.x;

			var col = markRenderer.color;
			col.a = 1 - t;
			markRenderer.color = col;

			transform.localScale = Vector3.Lerp(new Vector3(), startSize, 1 - t);

			yield return null;
		}

		Destroy(gameObject);
	}
}
