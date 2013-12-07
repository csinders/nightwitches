using UnityEngine;
using System.Collections;

public class TargetIndicators : MonoBehaviour {

  public GameObject airplane;
  public Texture symbol;

	// Use this for initialization
	void Start () {
	}

  void OnGUI() {
    var targets = GameObject.FindGameObjectsWithTag("Target");

    GameObject closest = null;
    float minimum = float.PositiveInfinity;

    foreach (var target in targets) {
      var distance = Vector3.Distance(airplane.transform.position, target.transform.position);
      if (distance < minimum && !target.renderer.isVisible) {
        minimum = distance;
        closest = target;
      }
    }

    if (closest) {
      var indicatorPosition = CalculateIndicatorPosition(closest.transform.position);
      GUI.DrawTexture(new Rect(indicatorPosition.x, indicatorPosition.y, 25, 25), symbol);
    }
  }

  Vector2 CalculateIndicatorPosition(Vector3 position) {
    var direction = (airplane.transform.position - position).normalized;
    direction /= Mathf.Max(Mathf.Abs(direction.x), Mathf.Abs(direction.z));
    direction *= 0.9f;
    return new Vector2(Screen.width / 2, Screen.height / 2) + Vector2.Scale(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(-direction.x, direction.z));
  }
}
