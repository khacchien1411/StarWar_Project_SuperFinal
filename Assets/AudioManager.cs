using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get => instance; }

    [SerializeField] protected AudioSource UISFX;
    [SerializeField] protected AudioSource shootingSFX;
    [SerializeField] protected AudioSource lootSFX;
    [SerializeField] protected AudioSource dashSFX;
    [SerializeField] protected AudioSource dieSFX;
    [SerializeField] protected AudioSource winSFX;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("There is only one AudioManager exist, please check again!");
        }
    }

    public virtual void PlayUISFX() => UISFX.Play();
    public virtual void PlayShootingSFX() => shootingSFX.Play();
    public virtual void PlayLootSFX() => lootSFX.Play();
    public virtual void PlayDashSFX() => dashSFX.Play();
    public virtual void PlayDieSFX() => dieSFX.Play();
    public virtual void PlayWinSFX() => winSFX.Play();

}
