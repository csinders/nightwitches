using UnityEngine;
using System.Collections;

public class PopulateTargets : MonoBehaviour {

<<<<<<< HEAD
	public float altitude; 
	public int targetCount; 
	public GameObject circleTarget;
	public GameObject squareTarget;
	public GameObject triangleTarget;

	// Use this for initialization
	void Start () {
		for (var i = 0; i < targetCount; ++i) { 
			var choice = ChooseShape();
			var target = Object.Instantiate(choice) as GameObject; //Object represents the CLass Object 
			target.transform.position = RandomPosition();

		}
	
	}

	//decides which shapes to return, it's arbitary 
	// random.value returns a number between 1 and 0 
	GameObject ChooseShape(){
		var choice = Random.value;
		if (choice < 1.0f / 3.0f) {
			return circleTarget;
		}else if (choice < 2.0f / 3.0f) {
			return squareTarget;
		}else {
			return triangleTarget;
		}
	}

	//this script is on the ground, ground has an object called BOUNDS (it's a box thtt contains the object
	//extents are from the center to the object to the edge of the box, in 3(x,y,z) directions you have how far away that distance is
	//
	Vector3 RandomPosition(){
		var extents = collider.bounds.extents; 
		var position = new Vector3(
			Random.Range(-extents.x, extents.x), //x coordinates of the BOUNDS, random rnge returns some number between -500 and positive 500 
				altitude,							//b/c our ground is 1000 by 1000 and half of tha tis the extent
			Random.Range(-extents.z, extents.z));//b/c 2-D, Y is up (for 3-D)
		return collider.bounds.center + position; //this is the center of hte object plus new position, so it moves along with the ground 

	}
	
	// Update is called once per frame
	void Update () {
	
	}
=======
  public float altitude;
  public int targetCount;
  public GameObject circleTarget;
  public GameObject squareTarget;
  public GameObject triangleTarget;

	// Use this for initialization
	void Start () {
    for (var i = 0; i < targetCount; ++i) {
      var choice = ChooseShape();
      var target = Object.Instantiate(choice) as GameObject;
      target.transform.position = RandomPosition();
    }
	}

  GameObject ChooseShape() {
    var choice = Random.value;
    if (choice < 1.0f / 3.0f) {
      return circleTarget;
    } else if (choice < 2.0f / 3.0f) {
      return squareTarget;
    } else {
      return triangleTarget;
    }
  }

  Vector3 RandomPosition() {
    var extents = collider.bounds.extents;
    var position = new Vector3(
        Random.Range(-extents.x, extents.x),
        altitude,
        Random.Range(-extents.z, extents.z));
    return collider.bounds.center + position;
  }
>>>>>>> e67aceb71bb2f28729e2b9ff835c3f5cc6d7a659
}
