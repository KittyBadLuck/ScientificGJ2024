using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManagerScene : MonoBehaviour
{
    // All these sounds should be called once or loop when played, but should not be called in a looping function (such as Update)

    [Header("Scene Sounds")]
    [Header("Corruption Settings")]
    [SerializeField] private AudioClip SFX_Corruption;
    [SerializeField] private Vector3 SFX_CorruptionPosition = new Vector3(4.25f, 0.85f, -1.75f);
    
    [Header("DoorOpening Settings")]
    [SerializeField] private AudioClip SFX_DoorOpening;
    [SerializeField] private Vector3 SFX_DoorOpeningPosition = new Vector3(6, 1, -4.75f);
    
    [Header("Falling Settings")]
    [SerializeField] private AudioClip SFX_Falling01;
    [SerializeField] private Vector3 SFX_Falling01Position = new Vector3(0, 0, 0);
    [Space]
    [SerializeField] private AudioClip SFX_Falling02;
    [SerializeField] private Vector3 SFX_Falling02Position = new Vector3(0, 0, 0);
    
    [Header("Moving Settings")]
    [SerializeField] private AudioClip SFX_Moving;
    [SerializeField] private Vector3 SFX_MovingPosition = new Vector3(4.25f, 0.85f, -1.75f);
    
    [Header("PageTurning Settings")]
    [SerializeField] private AudioClip SFX_PageTurning;
    [SerializeField] private Vector3 SFX_PageTuringPosition = new Vector3(2.5f, 0.85f, -1.7f);

    public void SFX_CorruptionPlay()
    {
        AudioSource.PlayClipAtPoint(SFX_Corruption, SFX_CorruptionPosition);
    }

    public void SFX_DoorOpeningPlay()
    {
        AudioSource.PlayClipAtPoint(SFX_DoorOpening, SFX_DoorOpeningPosition);
    }

    public void SFX_Falling01Play()
    {
        AudioSource.PlayClipAtPoint(SFX_Falling01, SFX_Falling01Position);
    }

    public void SFX_Falling02Play()
    {
        AudioSource.PlayClipAtPoint(SFX_Falling02, SFX_Falling02Position);
    }

    public void SFX_MovingPlay()
    {
        AudioSource.PlayClipAtPoint(SFX_Moving, SFX_MovingPosition);
    }

    public void SFX_PageTurningPlay()
    {
        AudioSource.PlayClipAtPoint(SFX_PageTurning, SFX_PageTuringPosition);
    }
}
