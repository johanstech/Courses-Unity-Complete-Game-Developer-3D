using UnityEngine;

public class Spinner : MonoBehaviour
{
  [SerializeField]
  float spinValue = 1f;

  void Update()
  {
    transform.Rotate(0, spinValue, 0);
  }
}
