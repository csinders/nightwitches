using UnityEngine;
using System.Collections;
//float redBall; 
public class LostItems : MonoBehaviour {
//public GameObject redBall; 
	public GameObject Camera;
	Ray ray;        
	RaycastHit hit; 
	// Use this for initialization
	void Start () {
		//ray casting- it works on mouseclick, shoots a ray out, and detects if something shold happen- like a new screen with info, etc. 
		//translating current screen position, so 3 different screen psoitions- so you have screen, viewport, and world position
			//im concnered about world position and screen position
			//the mouse is always livign on the coordinates of the screen position, its x,y (only on two axises)
			//you translate on the screen position and to the z axis on the world position- its an invisible ray coming from mouse to world position on X axis
				//if anything intersects with that, you know you've clicked on something 
		//onMouseClick (put in void onmouseclick function)
		//on running into object/picking it up, have it destroyed 
		//need a seperate inventory class- or an object, but a way to keep track of everything- it could just be an variable or an array list that expands and gives you added to
		//so you can pull stuff back up in another way 
		ray = Camera.camera.main.ScreenPointToRay(Input.mousePosition);   
		if (Physics.Raycast(ray, out hit, 100)) {// 100 is depth in z layer         	     
	 //      //Debug.DrawLine(ray.origin, hit.point); //put code for any action to have happen so make something happen.           
	     Destroy(gameObject);
	 //      Debug.Log(hit); 
	   	}
             
	}
	
	// Update is called once per frame
	void Update () {
		// 
	}
}

using UnityEngine;
using System.Collections;
 
public class testDestroy : MonoBehaviour {
 
    private float distance = 100.0f;
 
     void Update(){
     Ray ray = new Ray(transform.position,transform.forward);
     RaycastHit hit;
     if (Physics.Raycast (ray,out hit,distance))
     {
     Destroy(hit.collider.GameObject);
     }
     }
}   