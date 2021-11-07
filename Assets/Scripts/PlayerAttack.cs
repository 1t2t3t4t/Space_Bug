using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public ParticleSystem GunFlash;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GunFlash.Play();
        }
    }
}
