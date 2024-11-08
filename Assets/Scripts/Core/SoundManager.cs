using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager instance { get; private set; }
   private AudioSource soundSource;
   private AudioSource musicSource;

   private void Awake(){
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed when loading new scenes
      }
      else if (instance != this)
      {
         Destroy(gameObject); // Destroy duplicate instance
         return;
      }
      
      instance = this;
      soundSource = GetComponent<AudioSource>();
      musicSource = transform.GetChild(0).GetComponent<AudioSource>();
      
      
   }

   public void PlaySound(AudioClip _sound){
      soundSource.PlayOneShot(_sound);
   }

    public void ChangeSoundVolume(float _change)
    {
        ChangeSourceVolume(1, "soundVolume", _change, soundSource);
    }
    public void ChangeMusicVolume(float _change)
    {
        ChangeSourceVolume(0.45f, "musicVolume", _change, musicSource);
    }

    private void ChangeSourceVolume(float baseVolume, string volumeName, float change, AudioSource source)
    {
        //Get initial value of volume and change it
        float currentVolume = PlayerPrefs.GetFloat(volumeName, 1);
        currentVolume += change;

        //Check if we reached the maximum or minimum value
        if (currentVolume > 1)
            currentVolume = 0;
        else if (currentVolume < 0)
            currentVolume = 1;

        //Assign final value
        float finalVolume = currentVolume * baseVolume;
        source.volume = finalVolume;

        //Save final value to player prefs
        PlayerPrefs.SetFloat(volumeName, currentVolume);
    }
}
