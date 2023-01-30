using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
     public static SoundManager S;
     public AudioClip JumpClip;
     public AudioClip PlayerClip;
     public AudioClip CoinClip;
     public AudioClip ChestClip;
     public AudioClip WinClip;
     public AudioClip DieClip;
     public AudioClip AttackClip;


    private AudioSource audio;

    public AudioSource ambientSound;



    private void Awake()
    {
            S = this; // Singleton Definition
            audio=GetComponent<AudioSource>();
    }
    
    public void JumpSound()
    {
        audio.PlayOneShot(JumpClip);
    }

    public void PlayerSound()
    {
        audio.PlayOneShot(PlayerClip);
    }

    public void CoinSound()
    {
        audio.PlayOneShot(CoinClip);
    }

    public void ChestSound()
    {
        audio.PlayOneShot(ChestClip);
    }

    public void WinSound()
    {
        audio.PlayOneShot(WinClip);
    }

    public void DieSound()
    {
        audio.PlayOneShot(DieClip);
    }

    public void AttackSound()
    {
        audio.PlayOneShot(AttackClip);
    }

    public void StopAllSounds()
    {
        //stop the ambient noise
        ambientSound.Stop();

        //stop all child sound
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void StartAllSounds()
    {
        ambientSound.Play();
    }
    // Start is called before the first frame update
    
}
