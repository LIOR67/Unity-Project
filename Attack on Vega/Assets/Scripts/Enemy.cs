using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int KillScore;
    [SerializeField] int HitPoints = 3;
    [SerializeField] GameObject DeathVfx;
    [SerializeField] GameObject HitFX;
    GameObject Parent;
    Score scoreBoard;
    private void Start()
    {
        scoreBoard = FindObjectOfType<Score>();
        Parent = GameObject.FindWithTag("RunTime"); 
    }

    private void OnParticleCollision(GameObject other)
    {
        if (HitPoints > 0)
        {
            GameObject HitFx = Instantiate(HitFX, transform.position, Quaternion.identity);
            HitFx.transform.parent =Parent.transform;
            HitPoints--;

        }
        else
        {
            scoreBoard.IncreaseScore(KillScore);
            GameObject Vfx = Instantiate(DeathVfx, transform.position, Quaternion.identity);
            Vfx.transform.parent =Parent.transform;
            Destroy(gameObject);
        }
    }
}
