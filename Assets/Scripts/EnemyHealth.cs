using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("HIT!!");
        }
    }
}
