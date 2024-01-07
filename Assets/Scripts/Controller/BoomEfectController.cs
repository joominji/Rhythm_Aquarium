using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEfectController : MonoBehaviour
{
    [SerializeField] public bool createBoomButton = false;
    [SerializeField] private ParticleSystem BoomEfectSystem;

    public void CreateBoomEfect()
    {
        if (createBoomButton)
        {
            BoomEfectSystem.Stop();
            BoomEfectSystem.Play();
        }
    }
}
