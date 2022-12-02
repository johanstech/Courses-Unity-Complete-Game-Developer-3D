using UnityEngine;

public class ObjectHit : MonoBehaviour
{
  void OnCollisionEnter(Collision other)
  {
    Debug.Log("Collided with a wall...");
  }
}
