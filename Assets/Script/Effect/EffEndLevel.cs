using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffEndLevel : MonoBehaviour
{
    public ParticleSystem emoji;
    public ParticleSystem emoji1;
    public ParticleSystem emoji2;
    public ParticleSystem emoji3;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
        emoji.Play();
        emoji1.Play();
        emoji2.Play();
        emoji3.Play();
    }
    public void Hide()
    {
          gameObject.SetActive(false);
        emoji.Stop();
        emoji1.Stop();
        emoji2.Stop();
        emoji3.Stop();
    }
}
