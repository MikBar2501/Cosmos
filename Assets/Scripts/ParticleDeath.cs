using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeath : MonoBehaviour
{
    
    void Start()
    {
        Destroy(this.gameObject, 3);
    }

   
}
