using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePad : MonoBehaviour {


	private RectTransform rectTransform;
	// Use this for initialization
	private bool startMoving = false;
	private bool movingUp = false;
	void Start () {
		this.rectTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.startMoving) {
			if (this.movingUp) {
				this.rectTransform.position += Vector3.up * this.rectTransform.anchoredPosition.y * -0.5f;
			}
			else {
				this.rectTransform.position += Vector3.up * ((-500 + this.rectTransform.anchoredPosition.y) * -0.5f);
			}
			
		}
	}
	public void MoveUp() {
		startMoving = true;
		movingUp = true;
		
	}
	public void MoveDown() {
		startMoving = true;
		movingUp = false;
	}
}
