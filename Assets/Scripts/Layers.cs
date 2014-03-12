using UnityEngine;
using System.Collections;

public class Layers : MonoBehaviour {

  public float playerPosition;
  public GameObject[] layers;
  public GameObject camera;

  public int layerIndex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    playerPosition += Input.GetAxis("Horizontal") / 10;
    if (Input.GetKeyDown("up")) {
      layerIndex += 1;
      for (var i = 0; i < layers.Length; ++i) {
        layers[i].GetComponent<Region>().DoubleRegion(playerPosition);
      }
    }
	  for (var i = 0; i < layers.Length; ++i) {
      var position = layers[i].transform.position;
      var newPosition = new Vector3(position.x, position.y, Mathf.Pow(2, (i - layerIndex) - 1));
      layers[i].transform.position = Vector3.Lerp(position, newPosition, 0.25f);
    }
    var cameraPosition = camera.transform.position;
    camera.transform.position = new Vector3(playerPosition, cameraPosition.y, cameraPosition.z);
	}
}
