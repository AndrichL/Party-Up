using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixerGroup mixer;
    
    [SerializeField] private bool soundOnVolumeChanged;
    
    public string mixerFloat;
    // Start is called before the first frame update

    
    public void SetLevel(float sliderValue)
    {
        mixer.audioMixer.SetFloat(mixerFloat, Mathf.Log10(sliderValue) * 20);

        if (soundOnVolumeChanged)
        {
            AudioManager.instance.Play("Hit");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
