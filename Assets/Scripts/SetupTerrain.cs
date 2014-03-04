using UnityEngine;
using System.Collections;

public class SetupTerrain : MonoBehaviour {

	public GameObject Terrain1;
	public GameObject Terrain2;
	public GameObject Terrain3;

	// Use this for initialization
	void Start () {
		var choice = Random.Range(1,7);

		GameObject left = null;
		GameObject middle = null;
		GameObject right = null;

			if (choice == 1) { 
				left = Terrain1; //not == bc we're assigning the values of prefabs to the three variables, i'm not comparing if htey are the same. i'm assigning
				middle = Terrain2;
				right = Terrain3;
				
			}else if (choice ==2){
				left = Terrain1;
				middle = Terrain3;
				right = Terrain2;

			}else if (choice ==3){
				left = Terrain2;
				middle = Terrain1;
				right = Terrain3;

			}else if (choice ==4){
				left = Terrain2;
				middle= Terrain3;
				right = Terrain1;

			}else if (choice ==5){
				left = Terrain3;
				middle = Terrain2;
				right = Terrain1;

			}else if (choice ==6){
				left = Terrain3;
				middle = Terrain1;
				right = Terrain2;

			}
		var leftTerrain = Object.Instantiate(left) as GameObject; //object.instantiate just returns but we want it as a GameObject so we can change its position
		leftTerrain.transform.position = new Vector3(-999,0,0); 

		var middleTerrain = Object.Instantiate(middle) as GameObject;
		middleTerrain.transform.position = new Vector3(-333,0,0);

		var rightTerrain = Object.Instantiate(right) as GameObject;
		rightTerrain.transform.position = new Vector3(333,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
