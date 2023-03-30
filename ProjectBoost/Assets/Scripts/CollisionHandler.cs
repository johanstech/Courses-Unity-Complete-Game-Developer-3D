using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    private float levelDelay = 1f;

    private void OnCollisionEnter(Collision other)
    {
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
        // TODO: Add SFX
        // TODO: Add particle effect
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelDelay);
    }

    private void SuccessSequence()
    {
        // TODO: Add SFX
        // TODO: Add particle effect
        GetComponent<Movement>().enabled = false;
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
