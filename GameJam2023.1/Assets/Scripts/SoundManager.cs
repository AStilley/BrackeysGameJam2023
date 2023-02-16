using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] soundEffects;
    public AudioClip[] music;

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
                AudioSource audioSource = soundObject.AddComponent<AudioSource>();
                audioSource.clip = instance.soundEffects[i];

                audioSource.PlayOneShot(instance.soundEffects[i], (randomVolume ? Random.Range(1, 6) : volume));
                Destroy(soundObject, instance.soundEffects[i].length);
                return;
            }
        }
        Debug.Log("Invalid sound name: " + soundName);
    }

    public static void PlayRandomMusic()
    {
        int randomIndex = Random.Range(0, instance.music.Length);
        audioSource.clip = instance.music[randomIndex];
        audioSource.Play();
    }
}