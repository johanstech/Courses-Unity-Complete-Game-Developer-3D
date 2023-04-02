using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField]
    private Vector3 movementVector;
    [SerializeField]
    private float period = 3f;

    // Constant value of 6.283 (Pi * 2)
    private const float tau = Mathf.PI * 2;

    private Vector3 startingPosition;
    private float movementFactor;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period;

        // Cycling between -1 and 1
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
