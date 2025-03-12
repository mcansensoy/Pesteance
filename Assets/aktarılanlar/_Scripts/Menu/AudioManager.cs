using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelAudioClip
{
    public int levelIndex;
    public AudioClip audioClip;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private LevelAudioClip[] levelAudioClips;
    private AudioSource audioSource;

    private int currentLevelIndex;
    private AudioClip currentAudioClip;

    private void Awake()
    {
        int numAudioManagers = FindObjectsOfType<AudioManager>().Length;

        if (numAudioManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentLevelIndex = GetCurrentLevelIndex();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int newLevelIndex = GetCurrentLevelIndex();
        if (newLevelIndex != currentLevelIndex)
        {
            currentLevelIndex = newLevelIndex;
            PlayLevelAudio();
        }
    }

    private void PlayLevelAudio()
    {
        AudioClip audioClip = GetAudioClipForLevel(currentLevelIndex);

        if (audioClip != null && audioClip != currentAudioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            currentAudioClip = audioClip;
        }
        else
        {
            Debug.LogWarning("No audio clip assigned for the current level or the same audio clip is already playing.");
        }
    }

    private AudioClip GetAudioClipForLevel(int levelIndex)
    {
        foreach (LevelAudioClip levelAudioClip in levelAudioClips)
        {
            if (levelAudioClip.levelIndex == levelIndex)
            {
                return levelAudioClip.audioClip;
            }
        }

        return null;
    }

    private int GetCurrentLevelIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
