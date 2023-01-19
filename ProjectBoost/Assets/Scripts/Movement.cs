using UnityEngine;

public class Movement : MonoBehaviour
{
  void Start()
  {
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
      //* Thrust
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
