using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManagerCommodore : MonoBehaviour
{
    [SerializeField] private AudioSource commodore_AudioSourceMusic;
    [SerializeField] private AudioSource commodore_AudioSourceSFX;


    // All these sounds should be called once or loop when played, but should not be called in a looping function (such as Update)

    [Header("Commodore Sounds")]
    [SerializeField] private AudioClip SFX_commodoreMusic;
    [SerializeField] private AudioClip SFX_MenuValidation;
    [SerializeField] private AudioClip SFX_Purchasing;
    [SerializeField] private AudioClip SFX_Stealing;
    [SerializeField] private AudioClip SFX_TextWriting;
    [SerializeField] private AudioClip SFX_WitchSpeaking;


    // The function SFX_CommodoreMusicPlay() goes into another AudioSource, since it has custom parameters such as looping.

    public void SFX_CommodoreMusicPlay()
    {
        commodore_AudioSourceMusic.clip = SFX_commodoreMusic;
        commodore_AudioSourceMusic.Play();
        commodore_AudioSourceMusic.loop = true;
    }

    public void SFX_MenuValidationPlay()
    {
        commodore_AudioSourceSFX.PlayOneShot(SFX_MenuValidation);
    }
    public void SFX_PurchasingPlay()
    {
        commodore_AudioSourceSFX.PlayOneShot(SFX_Purchasing);
    }
    public void SFX_StealingPlay()
    {
        commodore_AudioSourceSFX.PlayOneShot(SFX_Stealing);
    }
    public void SFX_TextWritingPlay()
    {
        commodore_AudioSourceSFX.PlayOneShot(SFX_TextWriting);
    }
    public void SFX_WitchSpeakingPlay()
    {
        commodore_AudioSourceSFX.PlayOneShot(SFX_WitchSpeaking);
    }
}
