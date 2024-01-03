using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.UI;


//파티클 건들고 싶어서 임시로 만들어 논 스크립트 입니다. 아직 아무것도 안건드렸어요
public class ParticleManager : MonoBehaviour
{

    private ParticleSystem particle;

    
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void PlayPaticle()
    {

    }
}
