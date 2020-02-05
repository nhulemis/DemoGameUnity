using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotateEarth : MonoBehaviour
{
    [SerializeField]
    float m_speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * m_speed * Time.deltaTime);
    }
}
