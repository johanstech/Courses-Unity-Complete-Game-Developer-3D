using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float thrustPower = 1000f;
    [SerializeField]
    private float rotationPower = 100f;
    [SerializeField]
    private AudioClip mainEngine;

    private Rigidbody _rb;
    private AudioSource _audioSource;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            _rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            _audioSource.Stop();
        }
    }

    private void ProcessRotation()
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

    private void ApplyRotation(float rotationThisFrame)
    {
        _rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rb.freezeRotation = false;
    }
}
