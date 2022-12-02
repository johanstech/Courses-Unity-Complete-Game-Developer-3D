using UnityEngine;

public class Dropper : MonoBehaviour
{
  [SerializeField]
  float dropDelay = 3f;

  MeshRenderer _meshRenderer;
  Rigidbody _rigidBody;
  bool _hasDropped;

  void Awake()
  {
    _meshRenderer = GetComponent<MeshRenderer>();
    _rigidBody = GetComponent<Rigidbody>();
  }

  void Start()
  {
    ToggleDropper(_hasDropped);
  }

  void Update()
  {
    if (!_hasDropped && Time.time >= dropDelay)
    {
      _hasDropped = true;
      ToggleDropper(_hasDropped);
    }
  }

  void ToggleDropper(bool value)
  {
    _meshRenderer.enabled = value;
    _rigidBody.useGravity = value;
  }
}
