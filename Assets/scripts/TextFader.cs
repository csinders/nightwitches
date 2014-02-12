using UnityEngine;
using System.Collections;

public class TextFader : MonoBehaviour {
	public float waitTime;


	
	// Update is called once per frame
	void Update () {
		if(Time.time > waitTime){
			guiText.color = new Color(1, 1, 1, guiText.color.a + 0.5f * Time.deltaTime);

		}

	}
}
