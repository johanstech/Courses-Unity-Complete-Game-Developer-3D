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

    private AudioSource _audioSource;

    private bool isTransitioning = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; };

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
        // TODO: Add particle effect
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        _audioSource.Stop();
        _audioSource.PlayOneShot(crashClip);
        Invoke("ReloadLevel", levelDelay);
    }

    private void SuccessSequence()
    {
        // TODO: Add particle effect
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        _audioSource.Stop();
        _audioSource.PlayOneShot(successClip);
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
