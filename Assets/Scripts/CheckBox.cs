using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;
public class CheckBox : MonoBehaviour {

	// Use this for initialization

	public GameObject checkbox;
	private DoodleAnimator checkboxAnim;
	void Start () {	
		this.checkboxAnim = checkbox.GetComponent<DoodleAnimator>();
		print(checkboxAnim.Keyframes);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
