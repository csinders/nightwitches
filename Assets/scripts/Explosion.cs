using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

  public float lifetime;

  private float birth;

	// Use this for initialization
	void Start () {
    birth = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
    if (Time.fixedTime - birth > lifetime) {
      Object.Destroy(gameObject);
    }
	}
}
