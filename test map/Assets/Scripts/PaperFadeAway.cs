using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperFadeAway : MonoBehaviour {
	MeshRenderer meshRenderer;

	void Start () {
		meshRenderer = GetComponent<MeshRenderer>();
		Physics2D.gravity = new Vector2(0, -5);
	}
	
	void Update () {
		Color color = meshRenderer.sharedMaterial.color;

		if (color.a < 0.01f) {
			Destroy(gameObject);
		}

		meshRenderer.sharedMaterial.color = Color.Lerp(color, new Color(1, 1, 1, 0), Time.deltaTime);
	}
}
