using UnityEngine;
using System.Collections;


public class Button1 : MonoBehaviour {
	
	public Texture2D buttonOn;
	public Texture2D buttonOff;
			
	public void OnMouseEnter(){
		guiTexture.texture = buttonOn; 		
	}
	
	public void OnMouseExit(){
		guiTexture.texture = buttonOff;
			
	}
	
	public void OnMouseDown(){
		Application.LoadLevel("MainScene");
			
	}
		

	
}
