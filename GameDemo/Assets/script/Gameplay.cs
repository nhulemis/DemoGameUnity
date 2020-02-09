using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    //[SerializeField]
   // GameObject m_limit;
    // Start is called before the first frame update
    public float m_moveSpeed = 5.0f;
    public GameObject m_target;
    private static bool s_moveToNewPos;
    Vector3 m_oldPos;
    void Start()
    {
        s_moveToNewPos = false;
        m_oldPos = transform.position;
       // SetMoveCamera(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (s_moveToNewPos)
        {
            //transform.position = transform.position + Vector3.back * m_moveSpeed/3 * Time.deltaTime;
            transform.position = transform.position + Vector3.up * m_moveSpeed /2* Time.deltaTime;
            if (m_oldPos.y + 3 < transform.position.y)
            {
                Debug.Log("OK");
                m_oldPos = transform.position;
                SetMoveCamera(false);
            }
            // Camera.main.fieldOfView += 10;
        }
        //transform.LookAt(m_target.transform.position);
    }

    public static void SetMoveCamera(bool move)
    {
        s_moveToNewPos = move;
    }
}
