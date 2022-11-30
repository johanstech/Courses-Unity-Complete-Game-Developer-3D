using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
  [SerializeField]
  float xValue = 0;
  [SerializeField]
  float yValue = 0.01f;
  [SerializeField]
  float zValue = 0;

  void Start()
  {

  }

  void Update()
  {
    transform.Translate(xValue, yValue, zValue);
  }
}
