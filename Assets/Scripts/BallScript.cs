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

  private void FixedUpdate()
  {
    if (_rigidBody.velocity.magnitude > 0)
    {
      if (_rigidBody.velocity.magnitude < .5) // stop the ball completely
        _rigidBody.velocity = new Vector2(0, 0);
    }
  }

  public void Shoot(Vector2 direction)
  {
    _rigidBody.AddForce(direction * 100);
  }

  public bool IsMoving()
  {
    return _rigidBody.velocity.magnitude > 0;
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    var friction = collision.gameObject.GetComponent<Friction>();
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    var friction = collision.gameObject.GetComponent<Friction>();
  }
}