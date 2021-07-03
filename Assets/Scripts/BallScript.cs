using UnityEngine;

public class BallScript : MonoBehaviour
{
  Rigidbody2D _rigidBody;
  // Start is called before the first frame update
  void Start()
  {
    _rigidBody = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Shoot(Vector2 direction)
  {
    _rigidBody.AddForce(direction);
  }
}