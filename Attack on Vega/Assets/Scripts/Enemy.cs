using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject DeathVfx; 
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(DeathVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
   
}
