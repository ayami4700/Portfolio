using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleonnoff : MonoBehaviour
{
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {

      
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
      
        particle.Play();
    }
}
