using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    private float levelDelay = 1f;
    [SerializeField]
    private AudioClip successClip;
    [SerializeField]
    private AudioClip crashClip;
    [SerializeField]
    private ParticleSystem successParticles;
    [SerializeField]
    private ParticleSystem crashParticles;

    private AudioSource _audioSource;

    private bool isTransitioning = false;
    private bool debugCollisionDisabled = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            debugCollisionDisabled = !debugCollisionDisabled;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || debugCollisionDisabled) { return; };

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly.");
                break;
            case "Finish":
                SuccessSequence();
                break;
            default:
                CrashSequence();
                break;
        }
    }

    private void CrashSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        _audioSource.Stop();
        _audioSource.PlayOneShot(crashClip);
        crashParticles.Play();
        Invoke("ReloadLevel", levelDelay);
    }

    private void SuccessSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        _audioSource.Stop();
        _audioSource.PlayOneShot(successClip);
        successParticles.Play();
        Invoke("LoadNextLevel", levelDelay);
    }

    private void ReloadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        LoadLevel(currentLevel);
    }

    private void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;
        if (nextLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 0;
        }
        LoadLevel(nextLevel);
    }

    private void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
