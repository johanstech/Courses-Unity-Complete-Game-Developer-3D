using UnityEngine;

public class Movement : MonoBehaviour
{
  Rigidbody _rb;

  void Start()
  {
    _rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    ProcessThrust();
    ProcessRotation();
  }

  void ProcessThrust()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      _rb.AddRelativeForce(Vector3.up);
    }
  }

  void ProcessRotation()
  {
    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    {
      //* Rotate left
    }
    else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
      //* Rotate right
    }
  }
}
