using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Collision : MonoBehaviour
{
    [SerializeField] float ReloadTIme=1f;
    [SerializeField] ParticleSystem Explosion;
    [SerializeField] GameObject[] PlayerParts;
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        CrashSequance();
    }
    void CrashSequance()
    {
        Explosion.Play();
       for(int i=0;i<PlayerParts.Length;i++)
        {
            PlayerParts[i].GetComponent<MeshRenderer>().enabled = false;
        }
        GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<PlayerMovment>().enabled = false;
        Invoke("LoadLevelAfterCollision", ReloadTIme);
    }
    void LoadLevelAfterCollision()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
