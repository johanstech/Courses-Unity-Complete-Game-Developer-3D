using UnityEngine;

public class Movement : MonoBehaviour
{
  [SerializeField]
  float thrustPower = 1000f;
  [SerializeField]
  float rotationPower = 100f;

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
    if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
    {
      _rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
    }
  }

  void ProcessRotation()
  {
    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    {
      ApplyRotation(rotationPower);
    }
    else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
      ApplyRotation(-rotationPower);
    }
  }

  void ApplyRotation(float rotationThisFrame)
  {
    _rb.freezeRotation = true;
    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    _rb.freezeRotation = false;
  }
}
