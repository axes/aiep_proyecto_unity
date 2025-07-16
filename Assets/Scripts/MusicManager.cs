using UnityEngine;

public class MusicaManager : MonoBehaviour
{
    public AudioClip musicaMenu;
    public AudioClip musicaHistoria;
    public AudioClip musicaNivel1;

    private AudioSource source;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // persiste entre escenas
        source = gameObject.AddComponent<AudioSource>();
        source.loop = true;
        source.playOnAwake = false;
    }

    void Start()
    {
        CambiarMusicaSegunEscena(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        CambiarMusicaSegunEscena(scene.name);
    }

    void CambiarMusicaSegunEscena(string nombreEscena)
    {
        switch (nombreEscena)
        {
            case "MenuInicial":
                source.clip = musicaMenu;
                break;
            case "Historia":
                source.clip = musicaHistoria;
                break;
            case "Nivel1":
                source.clip = musicaNivel1;
                break;
            default:
                source.clip = null;
                break;
        }

        if (source.clip != null && !source.isPlaying)
            source.Play();
    }
}
