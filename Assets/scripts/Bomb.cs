using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

  public GameObject explosionPrefab;
	
	void OnCollisionEnter(Collision collision) {
    var explosion = Object.Instantiate(explosionPrefab) as GameObject;
    explosion.transform.position = transform.position;
    Object.Destroy(gameObject);
  }
}
