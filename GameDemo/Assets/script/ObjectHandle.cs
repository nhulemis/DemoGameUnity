using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandle : MonoBehaviour
{
    [SerializeField]
    ParticleSystem m_particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("particle");
        m_particle.transform.position = collision.collider.transform.position;
        if (!m_particle.isPlaying)
        {
            m_particle.Play();
        }
    }
}
