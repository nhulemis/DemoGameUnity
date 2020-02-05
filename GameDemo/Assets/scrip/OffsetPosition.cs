using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPosition : MonoBehaviour
{
    [SerializeField]
    GameObject m_target;
    // Start is called before the first frame update
    void Start()
    {
        if (m_target)
        {
            var pos = new Vector3(m_target.transform.position.x, transform.position.y, transform.position.z);
            transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
