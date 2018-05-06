using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMessage : MonoBehaviour {

	public List<CheckBox> checkBoxes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var allChecked = true;
		foreach (CheckBox box in checkBoxes) {
			if (!box.isChecked) allChecked = false;
		}
		this.gameObject.SetActive(allChecked);
	}
}
