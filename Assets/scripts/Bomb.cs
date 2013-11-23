using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

  public GameObject explosionPrefab;

  private bool exploded;

	// Use this for initialization
	void Start () {
	  exploded = false;
	}
	
	void OnCollisionEnter(Collision collision) {
    if (!exploded) {
      exploded = true;
      var explosion = Object.Instantiate(explosionPrefab) as GameObject;
      explosion.transform.position = transform.position;
    }
  }
}
