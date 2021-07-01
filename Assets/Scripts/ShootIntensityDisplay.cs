using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIntensityDisplay : MonoBehaviour
{
  private LineRenderer _lineRenderer;
  private Vector3 _initialPosition;
  private Vector3 _currentPosition;

  // Start is called before the first frame update
  void Start()
  {
    _lineRenderer = gameObject.AddComponent<LineRenderer>();
    _lineRenderer.startWidth = 0.1f;
    _lineRenderer.endWidth = 0.1f;
    _lineRenderer.enabled = false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnMouseDown()
  {
    _initialPosition = GetCurrentMousePosition().GetValueOrDefault();
    _lineRenderer.SetPosition(0, _initialPosition);
    _lineRenderer.positionCount = 1;
  }

  private void OnMouseDrag()
  {
    Debug.Log("Wee");
    _currentPosition = GetCurrentMousePosition().GetValueOrDefault();
    _lineRenderer.enabled = true;
    _lineRenderer.positionCount = 2;
    _lineRenderer.SetPosition(1, _currentPosition);
  }

  void OnMouseUp()
  {
    _lineRenderer.enabled = false;
  }

  private Vector3? GetCurrentMousePosition()
  {
    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    var plane = new Plane(Vector3.forward, Vector3.zero);

    float rayDistance;
    if (plane.Raycast(ray, out rayDistance))
    {
      return ray.GetPoint(rayDistance);

    }

    return null;
  }
}
