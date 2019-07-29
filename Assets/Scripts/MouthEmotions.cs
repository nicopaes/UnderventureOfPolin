/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;

public class MouthEmotions : MonoBehaviour {

	#region Public Variables
	public playerHealth playerHealth;
	[Range(1f,30f)]
	public float emotionRadious;
	#endregion

	#region Private Variables
	private bool babao;
	private bool medo;
	private Animator mouthAnimator;
	#endregion

	#region Start and Awake
	void Awake () {
		mouthAnimator = GetComponent<Animator>();
	}

	#endregion

	#region Fixed-Update²
	void Update()
	{
		mouthAnimator.SetBool("Babao", babao);
		mouthAnimator.SetBool("Medo", medo);
		if (playerHealth.HP == 1)
		{
			medo = true;
		}
		else
		{
			medo = false;
		}
		//static Collider2D OverlapCircle(Vector2 point, float radius, int layerMask = DefaultRaycastLayers, float minDepth = -Mathf.Infinity, float maxDepth = Mathf.Infinity);
		
	}
	private void FixedUpdate()
	{
		babao = false;
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, emotionRadious);
		for (var i = 0; i < hitColliders.Length; i++)
		{
			if (hitColliders[i].transform.GetComponent<VagalumeLife>() == true)
			{
				babao = true;
			}
		}

	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, emotionRadious);
	}
	#endregion

	#region Auxiliary Functions

	#endregion
}
