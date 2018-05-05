using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWeirdThing : MonoBehaviour {
    public GameObject[] dummyScript;
    bool trigger1 = false;

    public int timer = 0;

    private void Start()
    {
        dummyScript = GameObject.FindGameObjectsWithTag("Bug");
    }

    // Update is called once per frame
    void Update () {
		if (timer > 100 && !trigger1)
        {
            trigger1 = true;
            for (int i = 0; i < dummyScript.Length; i++)
            {
                WanderingAIMovement npc = dummyScript[i].GetComponent<WanderingAIMovement>();
                npc.isMoving = true;
            }
        }
        else
        {
            timer++;
        }
	}
}
