using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    private ParticleSystem ps;
    private int numEnter;
    public delegate void Score(int num);
    public static event Score OnScore;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            //p.position = new Vector3(0, 0, 0);
            p.remainingLifetime = 0;
            enter[i] = p;
        }
        OnScore(1);      
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}

