using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject m_limitLine;

    //[SerializeField]
    GameObject m_treeBase;
    GameObject m_buildingBase;

    private GameObject m_cube;
    private bool m_isHoldingTree;
    private bool m_isHoldingBuilding;
    private Vector3 m_offset;
    private GameObject m_tree;

    private void Start()
    {
        m_isHoldingTree = false;
        m_isHoldingBuilding = false;
        // m_startLine = GameObject.FindGameObjectWithTag("Line");
        m_treeBase = GameObject.FindGameObjectWithTag("TreeBase");
        m_buildingBase = GameObject.FindGameObjectWithTag("Building");
    }
    public void CreateTree()
    {
        m_tree = Instantiate(m_treeBase);
        m_tree.transform.position = GetMouseWorldPosition();
        // m_cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);        
    }

    public Vector3 GetMouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = m_limitLine.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void CreateBuilding()
    {
        Debug.Log("Building");
        m_cube = Instantiate(m_buildingBase);
        m_cube.transform.position = GetMouseWorldPosition();
    }

    private void Update()
    {
        if (m_isHoldingTree)
        {
            m_tree.transform.position = GetMouseWorldPosition();
        }
        else if (m_isHoldingBuilding)
        {
            m_cube.transform.position = GetMouseWorldPosition();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(eventData.selectedObject.name);
        if (!m_isHoldingTree && !m_isHoldingBuilding)
        {
            string pressingButtonName = eventData.selectedObject.name;
            if (pressingButtonName == "Tree")
            {
                m_isHoldingTree = true;
                CreateTree();
            }
            else if (pressingButtonName == "Building")
            {
                m_isHoldingBuilding = true;
                CreateBuilding();
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("up");
        if (m_isHoldingTree)
        {
            m_tree.GetComponent<Collider>().attachedRigidbody.useGravity = true;
            m_isHoldingTree = false;
        }
        else if (m_isHoldingBuilding)
        {
            m_cube.GetComponent<Collider>().attachedRigidbody.useGravity = true;
            m_isHoldingBuilding = false;
        }
    }

}
