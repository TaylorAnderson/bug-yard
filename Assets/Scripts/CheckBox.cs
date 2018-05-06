using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;
using UnityEngine.UI;
public class CheckBox : MonoBehaviour {

	// Use this for initialization

	public GameObject checkbox;
	public Image bugText;
	public Image bug;
	private DoodleAnimator checkboxAnim;

	public DoodleAnimationFile checkedFile;

	public DoodleAnimationFile uncheckedFile;

	private int[] uncheckedFrames = new int[] {0, 1};
	private int[] checkedFrames = new int[] {2, 3};

	private int[] currentAnim;

	public bool isChecked = false;

	public BugType bugType;
	void Start () {	

		currentAnim = uncheckedFrames;
		this.checkboxAnim = checkbox.GetComponent<DoodleAnimator>();
		this.isChecked = Bug.bugsCaught.IndexOf(this.bugType) != -1;
	
	}
	
	// Update is called once per frame
	void Update () {
		this.isChecked = Bug.bugsCaught.IndexOf(this.bugType) != -1;
		
		if (isChecked) {
			this.checkboxAnim.ChangeAnimation(checkedFile);
			var tmp = bugText.color;
			tmp.a = 1;
			bugText.color = tmp;

			tmp = bug.color;
			tmp.a = 1;
			bug.color = tmp;
			
		}
		else {
			this.checkboxAnim.ChangeAnimation(uncheckedFile);
			var tmp = bugText.color;
			tmp.a = 0.2f;
			bugText.color = tmp;

			tmp = bug.color;
			tmp.a = 0.2f;
			bug.color = tmp;
		}
	}
}
