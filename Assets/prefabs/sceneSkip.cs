
using UnityEngine;
using System.Collections;

public class sceneSkip : MonoBehaviour {
	public string nextScene; 

    void Update() {
	    if (Input.GetKeyDown("space"))
		    Application.LoadLevel(nextScene);
    }
}
