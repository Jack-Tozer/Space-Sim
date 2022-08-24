using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Particle : MonoBehaviour
{

    public enum ParticleState
    {
        gas,
        liquid,
        solid,
        plasma
    };


    public ParticleState m_state;


    public int m_size;


    public float m_temp;

    public int mass;
    public abstract void TempCheck();

    public abstract void CheckNearby();



}