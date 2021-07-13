using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
  public Portal OtherPortal;
  public Collider2D Collider { get; private set; }

  // Start is called before the first frame update
  void Start()
  {
    Collider = gameObject.GetComponent<Collider2D>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    var velocity = collision.attachedRigidbody.velocity;
    velocity.Normalize();
    collision.gameObject.transform.position = OtherPortal.transform.position + ((Vector3)velocity / 2) + (Vector3)(velocity * (OtherPortal.Collider.bounds.size.x));
    //collision.attachedRigidbody.velocity = Vector2.zero;
  }
}
