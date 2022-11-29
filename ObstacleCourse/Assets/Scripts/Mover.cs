using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
  void Start()
  {

  }

  void Update()
  {
    transform.Translate(0.01f, 0, 0);
  }
}
