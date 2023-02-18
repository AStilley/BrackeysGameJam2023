using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] soundEffects;
    public AudioClip[] music;
    [SerializeField] public string[] ClipsNotOnRandomPlay;

    private static SoundManager instance;
    private static AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
		if (instance == null) {  instance = FindObjectOfType<SoundManager>(); }
        PlayRandomMusic();
    }

    public static void PlaySound(string soundName, float volume, bool randomVolume)
    {
        for (int i = 0; i < instance.soundEffects.Length; i++)
        {
            if (instance.soundEffects[i].name == soundName)
            {
                // Create a new game object with an AudioSource component
                GameObject soundObject = new GameObject(soundName + "SoundInst");
                AudioSource audioSource2 = soundObject.AddComponent<AudioSource>();
                audioSource2.clip = instance.soundEffects[i];
                audioSource2.pitch = (randomVolume ? Random.Range(1f, 4f) : 1f);
                audioSource2.PlayOneShot(instance.soundEffects[i], (randomVolume ? Random.Range(2, 4) : volume));
                Destroy(soundObject, instance.soundEffects[i].length);
                return;
            }
        }
        //Debug.Log("Invalid sound name: " + soundName);
    }

    
    public static void PlayMusic(string soundName)
    {
        for (int i = 0; i < instance.soundEffects.Length; i++)
        {
            if (instance.soundEffects[i].name == soundName)
            {
                audioSource.clip = instance.soundEffects[i];
                audioSource.Play();
                return;
            }
        }
        //Debug.Log("Invalid sound name: " + soundName);
    }

    public static void PlayRandomMusic()
    {
        int randomIndex = Random.Range(0, instance.music.Length);
        Debug.Log(instance.music[randomIndex].name);
        Debug.Log(System.Array.IndexOf(instance.ClipsNotOnRandomPlay, instance.music[randomIndex].name));
        if (System.Array.IndexOf(instance.ClipsNotOnRandomPlay, instance.music[randomIndex].name) >= 0) { PlayRandomMusic(); }
        else {
            audioSource.clip = instance.music[randomIndex];
            audioSource.Play();
        }
    }
}