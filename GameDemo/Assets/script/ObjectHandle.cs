using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandle : MonoBehaviour
{
    [SerializeField]
    ParticleSystem m_particle;
    [SerializeField]
    GameObject m_top;

    List< GameObject> m_objects;

    private bool m_isReadyForCheck;
    // Start is called before the first frame update
    void Start()
    {
        m_objects = new List<GameObject>();
        m_isReadyForCheck = false;
        m_objects.Add(GameObject.FindGameObjectWithTag("mark1"));
        m_objects.Add(GameObject.FindGameObjectWithTag("mark2"));
        m_objects.Add(GameObject.FindGameObjectWithTag("mark3"));
        m_objects.Add(GameObject.FindGameObjectWithTag("mark4"));
        m_objects.Add(GameObject.FindGameObjectWithTag("Line"));
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isReadyForCheck )
        {
            var target = GameObject.FindGameObjectWithTag("Line");
            if ( target && m_top.transform.position.y >= target.transform.position.y)
            {
                Debug.Log("ok");
                Gameplay.SetMoveCamera(true);
                MoveUpTarget();
            }
        }
    }

    void MoveUpTarget()
    {
        foreach (var gObj in m_objects)
        {
            gObj.transform.position = gObj.transform.position + Vector3.up * 3;
        }
    }

    bool CheckTagTree()
    {
        if (transform.tag == "TreeType1")
        {
            return true;
        }
        if (transform.tag == "TreeType2")
        {
            return true;
        }
        if (transform.tag == "TreeType3")
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.name != "wooden_balance")
        {
            m_particle.transform.position = collision.collider.transform.position;
            if (!m_particle.isPlaying)
            {
                m_particle.Play();
            }
            m_isReadyForCheck = true;
        }
        //Debug.Log("Height: "+ collision.collider.transform.position.y);
    }
}
