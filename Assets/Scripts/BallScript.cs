using UnityEngine;

public class BallScript : MonoBehaviour
{
  Rigidbody2D _rigidBody;
  public float DefaultFriction = 0.99f;
  public float CurrentFriction;

  // Start is called before the first frame update
  void Start()
  {
    _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    CurrentFriction = DefaultFriction;
  }

  // Update is called once per frame
  void Update()
  {
    if(_rigidBody.velocity.magnitude > 0)
    {
      _rigidBody.velocity *= CurrentFriction;
    }
  }

  public void Shoot(Vector2 direction)
  {
    _rigidBody.AddForce(direction);
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    var friction = collision.gameObject.GetComponent<Friction>();
    if (friction != null)
      CurrentFriction = friction.FrictionValue;
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    var friction = collision.gameObject.GetComponent<Friction>();
    if (friction != null)
      CurrentFriction = DefaultFriction;
  }
}