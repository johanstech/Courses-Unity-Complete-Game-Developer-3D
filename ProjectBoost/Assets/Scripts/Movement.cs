using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float thrustPower = 1000f;
    [SerializeField]
    private float rotationPower = 100f;
    [SerializeField]
    private AudioClip mainEngine;
    [SerializeField]
    private ParticleSystem mainBooster;
    [SerializeField]
    private ParticleSystem forwardBooster;
    [SerializeField]
    private ParticleSystem backBooster;

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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }

    private void StartThrusting()
    {
        _rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(mainEngine);
        }
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }

    private void StopThrusting()
    {
        mainBooster.Stop();
        _audioSource.Stop();
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationPower);
        if (!backBooster.isPlaying)
        {
            backBooster.Play();
        }
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationPower);
        if (!forwardBooster.isPlaying)
        {
            forwardBooster.Play();
        }
    }

    private void StopRotation()
    {
        forwardBooster.Stop();
        backBooster.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        _rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rb.freezeRotation = false;
    }
}
