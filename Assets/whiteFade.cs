/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;

public class whiteFade : MonoBehaviour {

	private SpriteRenderer whiteFadeSprite;

	private void Awake()
	{
		whiteFadeSprite = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		if(GetComponentInParent<Transform>().position.y > -900f)
		{
			float y = GetComponentInParent<Transform>().position.y;
			float newAlpha = Mathf.Clamp01(-0.1524390244e-4f * Mathf.Pow(y,2) - 0.1371951220e-1f * y);
			var spriteColor = whiteFadeSprite.color;
			spriteColor.a = newAlpha;

			Debug.Log(spriteColor.a);

			whiteFadeSprite.color = spriteColor;
		}
	}
}
