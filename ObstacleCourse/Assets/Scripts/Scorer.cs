using UnityEngine;

public class Scorer : MonoBehaviour
{
  int _score;

  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "Hit") return;

    _score++;
    Debug.Log($"Times bumped into something: {_score}");
  }
}
