using UnityEngine;
using System.Collections;

public class PopulateTargets : MonoBehaviour {

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
}
