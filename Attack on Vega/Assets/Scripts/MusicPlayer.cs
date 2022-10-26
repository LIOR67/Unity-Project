using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int NumofMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if(NumofMusicPlayers>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
        
}
