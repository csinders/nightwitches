using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

  public float distance;
  public float lifetime;

  private float birth;

	// Use this for initialization
	void Start () {
    birth = Time.fixedTime;
    var targets = GameObject.FindGameObjectsWithTag("Target");
    foreach (var target in targets) {
      if (Vector3.Distance(target.transform.position, transform.position) < distance) {
        Object.Destroy(target);
      }
    }
	}
	
	// Update is called once per frame
	void Update () {
    if (Time.fixedTime - birth > lifetime) {
      Object.Destroy(gameObject);
    }
	}
}
