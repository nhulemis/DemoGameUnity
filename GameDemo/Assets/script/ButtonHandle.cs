using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    static public GameObject Limit;
    //[SerializeField]
    GameObject m_treeBase;
    GameObject m_buildingBase;

    private GameObject m_cube;
    private bool m_isHoldingTree;
    private bool m_isHoldingBuilding;
    private GameObject m_tree;

    private void Start()
    {
        m_isHoldingTree = false;
        m_isHoldingBuilding = false;
        // m_startLine = GameObject.FindGameObjectWithTag("Line");
        RandomNextTypeWooden();
        RandomNextTypeBuilding();
        //Debug.Log("SCWR: " + Screen.width * 3 / 5);
    }
    public void CreateTree()
    {
        m_tree = Instantiate(m_treeBase);
        m_tree.transform.position = GetMouseWorldPosition(0);
        // m_cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);        
    }

    public Vector3 GetMouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        var obj = GameObject.FindGameObjectWithTag("mark1").transform.position;
        return obj;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type">1 = right , 0 = left</param>
    /// <returns></returns>
    public Vector3 GetMouseWorldPosition(int type)
    {
        Vector3 objPos;
        if (type == 1)
        {
            objPos = GameObject.FindGameObjectWithTag("mark3").transform.position;
        }
        else
        {
            objPos = GameObject.FindGameObjectWithTag("mark1").transform.position;
        }
        return objPos;
    }

    public void CreateBuilding()
    {
        //Debug.Log("Building");
        m_cube = Instantiate(m_buildingBase);
        m_cube.transform.position = GetMouseWorldPosition(1);
    }

    private void Update()
    {
        var deltaMouseX = Input.GetAxis("Mouse X");
        var deltaMouseY = Input.GetAxis("Mouse Y");
        if (m_isHoldingTree)
        {   
            var limit1 = GameObject.FindGameObjectWithTag("mark1").transform.position;
            var limit2 = GameObject.FindGameObjectWithTag("mark2").transform.position;
            Vector3 pos = m_tree.transform.position + Vector3.right * deltaMouseX * 10 * Time.deltaTime;
            pos.x = Limit2Constan(pos.x, limit1.x, limit2.x);
            m_tree.transform.position = pos;
           // Debug.Log("CurX: "+ pos.x + " Min: "+ limit1.x + " Max: "+limit2.x);
            
        }
        else if (m_isHoldingBuilding)
        {
            var limit3 = GameObject.FindGameObjectWithTag("mark4").transform.position;
            var limit4 = GameObject.FindGameObjectWithTag("mark3").transform.position;
            Vector3 pos = m_cube.transform.position + Vector3.right * deltaMouseX * 10 * Time.deltaTime;
            pos.x = Limit2Constan(pos.x, limit3.x, limit4.x);
            m_cube.transform.position = pos;
        }
    }

    float Limit2Constan(float number, float min, float max)
    {
        if (number > max)
        {
            return max;
        }
        if (number < min)
        {
            return min;
        }
        return number;
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
            RandomNextTypeWooden();
        }
        else if (m_isHoldingBuilding)
        {
            var collider = m_cube.GetComponent<Collider>();
            var body = collider.attachedRigidbody;
            body.useGravity = true;
            m_isHoldingBuilding = false;
            RandomNextTypeBuilding();
        }
    }

    private void RandomNextTypeBuilding()
    {
        int type = Random.Range(1, 4);
        //Debug.Log("Type: " + type);
        switch (type)
        {
            case 1:
                m_buildingBase = GameObject.FindGameObjectWithTag("BuildingType1");
                break;
            case 2:
                m_buildingBase = GameObject.FindGameObjectWithTag("BuildingType2");
                break;
            case 3:
                m_buildingBase = GameObject.FindGameObjectWithTag("BuildingType3");
                break;
        }
    }
    private void RandomNextTypeWooden()
    {
        int type = Random.Range(1, 4);
        //Debug.Log("Type: " + type);
        switch (type)
        {
            case 1:
                m_treeBase = GameObject.FindGameObjectWithTag("TreeType1");
                break;
            case 2:
                m_treeBase = GameObject.FindGameObjectWithTag("TreeType2");
                break;
            case 3:
                m_treeBase = GameObject.FindGameObjectWithTag("TreeType3");
                break;
        }
    }

}
