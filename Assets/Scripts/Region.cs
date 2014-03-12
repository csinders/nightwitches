using UnityEngine;
using System.Collections;

public class Region : MonoBehaviour {

  public GameObject region1, region2, region3;
  public float german, russian, wilderness;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    // Normalized means that (german + russian + wilderness) = 1
    float normalizedGerman = german / (german + russian + wilderness);
    float normalizedRussian = russian / (german + russian + wilderness);
    float normalizedWilderness = wilderness / (german + russian + wilderness);

    float widthGerman = 3 * normalizedGerman;
    float widthWilderness = 3 * normalizedWilderness;
    float widthRussian = 3 * normalizedRussian;

    region2.transform.localScale = new Vector3(widthRussian, 1, 1);
    region1.transform.localScale = new Vector3(widthWilderness, 1, 1);
    region3.transform.localScale = new Vector3(widthGerman, 1, 1);

    region2.transform.position = gameObject.transform.position + new Vector3(widthRussian / 2, 0, 0);
    region1.transform.position = gameObject.transform.position + new Vector3(widthRussian + widthWilderness / 2, 0, 0);
    region3.transform.position = gameObject.transform.position + new Vector3(widthRussian + widthWilderness + widthGerman / 2, 0, 0);
	}

  public void DoubleRegion(float playerPosition) {
    var region = RegionPlayerInhabits(playerPosition);
    if (region == 1) {
      russian *= 2;
    } else if (region == 2) {
      wilderness *= 2;
    } else {
      german *= 2;
    }
  }

  int RegionPlayerInhabits(float playerPosition) {
    // Normalized means that (german + russian + wilderness) = 1
    float normalizedGerman = german / (german + russian + wilderness);
    float normalizedRussian = russian / (german + russian + wilderness);
    float normalizedWilderness = wilderness / (german + russian + wilderness);

    float widthGerman = 3 * normalizedGerman;
    float widthWilderness = 3 * normalizedWilderness;
    float widthRussian = 3 * normalizedRussian;

    if (playerPosition <= widthRussian) {
      return 2;
    } else if (widthRussian < playerPosition && playerPosition <= widthRussian + widthWilderness) {
      return 1;
    } else {
      return 3;
    }
  }
}
