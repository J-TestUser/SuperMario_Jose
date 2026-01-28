using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource fuenteAudio;
    public AudioClip gameBGM;

    void Awake()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }
    
    void Start()
    {
    PlayBGM ();
    }

    void PlayBGM()
    {
       fuenteAudio.loop= true;
       fuenteAudio.clip = gameBGM;
       fuenteAudio.Play();
    }
    public void StopBGM()
    {
        fuenteAudio.Stop();
    }
}
