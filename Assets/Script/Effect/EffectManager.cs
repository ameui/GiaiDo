using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }
    public ParticleSystem emoji;
    public ParticleSystem emoji1;
    public ParticleSystem emoji2;
    public ParticleSystem emoji3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void effectEndLevelShow()
    {
        gameObject.SetActive(true);
        emoji.Play();
        emoji1.Play();
        emoji2.Play();
        emoji3.Play();
    }
    public void effectEndLevelHide()
    {
          gameObject.SetActive(false);
        emoji.Stop();
        emoji1.Stop();
        emoji2.Stop();
        emoji3.Stop();
    }
}
