using UnityEngine;

public class ShootIntensityDisplay : MonoBehaviour
{
  public float LineWidth = 0.04f;
  private LineRenderer _lineRenderer;
  private Vector3 _initialPosition;
  private Vector3 _currentPosition;
  private BallScript _ball;

  // Start is called before the first frame update
  void Start()
  {
    _lineRenderer = gameObject.AddComponent<LineRenderer>();
    _lineRenderer.startWidth = LineWidth;
    _lineRenderer.endWidth = LineWidth;
    _lineRenderer.enabled = false;
    _ball = gameObject.GetComponent<BallScript>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnMouseDown()
  {
    _initialPosition = this.gameObject.transform.position;
    _lineRenderer.SetPosition(0, _initialPosition);
    _lineRenderer.positionCount = 1;
  }


  private void OnMouseDrag()
  {
    _currentPosition = GetCurrentMousePosition().GetValueOrDefault();
    _lineRenderer.enabled = true;
    _lineRenderer.positionCount = 2;
    _lineRenderer.SetPosition(1, _currentPosition);
  }

  void OnMouseUp()
  {
    Vector2 shootyVec = (_lineRenderer.GetPosition(0) - _lineRenderer.GetPosition(1));
    _ball.Shoot(shootyVec);
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
