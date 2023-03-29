using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
  void OnCollisionEnter(Collision other)
  {
    switch (other.gameObject.tag)
    {
      case "Friendly":
        Debug.Log("This thing is friendly.");
        break;
      case "Finish":
        Debug.Log("You reached the finish.");
        break;
      default:
        Debug.Log("Sorry, you blew up.");
        break;
    }
  }
}
