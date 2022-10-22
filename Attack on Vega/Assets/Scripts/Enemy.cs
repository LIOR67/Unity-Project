using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int KillScore;
    [SerializeField] GameObject DeathVfx;
    [SerializeField] Transform Parent;
    Score scoreBoard;
    private void Start()
    {
        scoreBoard = FindObjectOfType<Score>(); 
    }
    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.IncreaseScore(KillScore);
        GameObject Vfx =Instantiate(DeathVfx, transform.position, Quaternion.identity);
        Parent = Vfx.transform.parent;
        Destroy(gameObject);
    }
   
}
