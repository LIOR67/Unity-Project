using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float TimetillDestroy=3f;
    void Start()
    {
        Destroy(gameObject, TimetillDestroy);
    }

  
}
