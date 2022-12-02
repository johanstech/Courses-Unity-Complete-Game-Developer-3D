using UnityEngine;

public class Mover : MonoBehaviour
{
  [SerializeField]
  float moveSpeed = 10f;

  void Start()
  {
    PrintInstructions();
  }

  void Update()
  {
    Move();
  }

  void PrintInstructions()
  {
    Debug.Log("Welcome to the game!");
    Debug.Log("Move your player with WAS or the arrow keys.");
    Debug.Log("Don't hit the walls!");
  }

  void Move()
  {
    float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
    float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
    transform.Translate(xValue, 0, zValue);
  }
}
