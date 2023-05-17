using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToRay : MonoBehaviour
{
    Camera myCamera;
    private float camRayLength = 100f;
    private int boxMask;
    GameObject collideObject = null;
    public Game game;
    

    public GameObject goatObject;
    public GameObject goatRoot;
    public GameObject tigerObject;
    public GameObject tigerRoot;
    
  
    void Start()
    {
        myCamera = GetComponent<Camera>();
        boxMask = LayerMask.GetMask("Box");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray camRay = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, boxMask))
        {
            Debug.DrawLine(camRay.origin, floorHit.point, Color.yellow);
            Debug.Log("Box Found");
            collideObject = floorHit.transform.gameObject;
        }
        else
        {
            collideObject = null;
        }
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (collideObject != null)
            {
                string name = collideObject.transform.gameObject.name;
                game.setNewPoint(name);
            }
        }
    }
}