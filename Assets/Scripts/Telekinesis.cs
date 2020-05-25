using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    public Camera mainCamera;
    public float interactionDistance;
    public Transform holdPosition;
    public float attractionSpeed;
    public float minThrowForce;
    public float maxThrowForce;

    private float throwForce;
    private GameObject heldObject;
    private Rigidbody rbOfHeldObject;
    private bool holdsObject = false;
    private Vector3 rotateVector = Vector3.one;
    
    void Start()
    {
        throwForce = minThrowForce;
    }
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !holdsObject)
        {
            Raycast();
        }

        if (Input.GetMouseButton(1) && holdsObject)
        {
            float lightSpeed = 35f;
            float amount = 0.001f;
            float randSin;
            
            randSin = Mathf.Sin(Time.time * lightSpeed) * amount;


            heldObject.transform.position = new Vector3(heldObject.transform.position.x, heldObject.transform.position.y+randSin, heldObject.transform.position.z);


            float diff = 0.001f;
            throwForce += 0.1f;
            rotateVector = new Vector3(rotateVector.x +diff,rotateVector.y+diff,rotateVector.z+diff);
        }

        if (Input.GetMouseButtonUp(1) && holdsObject)
        {
            ShootObject();
        }

        if (Input.GetKeyDown(KeyCode.F) && holdsObject)
        {
            ReleaseObject();
        }

        if (holdsObject)
        {
            RotateObject();

            if (CheckDistance() >= 1f)
            {
                MoveObjectToPosition();
            } 
        }
    }
    
    
    // ----------------------------- POLISHING SECTION 
    private void CalculateRotationVector()
    {
        float x = Random.Range(-0.5f, 0.5f); // will rotate with different speed
        float y = Random.Range(-0.5f, 0.5f); 
        float z = Random.Range(-0.5f, 0.5f); 
        
        rotateVector = new Vector3(x,y,z);
    }

    private void RotateObject()
    {
        heldObject.transform.Rotate(rotateVector);
    }
    
    
    
    
    
    
    
    
    // ---------------------------------- FUNCTIONAL SECTION
    public float CheckDistance()
    {
        return Vector3.Distance(heldObject.transform.position, holdPosition.transform.position);
    }

    private void MoveObjectToPosition()
    {
        heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, holdPosition.transform.position, attractionSpeed * Time.deltaTime);
    }

    private void ReleaseObject()
    {
        rbOfHeldObject.constraints = RigidbodyConstraints.None;
        heldObject.transform.parent = null;
        heldObject = null;
        holdsObject = false;
    }

    private void ShootObject()
    {
        throwForce = Mathf.Clamp(throwForce, minThrowForce, maxThrowForce);
        rbOfHeldObject.AddForce(mainCamera.transform.forward * throwForce, ForceMode.Impulse);
        throwForce = minThrowForce;
        ReleaseObject();
    }

    private void Raycast()
    {
        //Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Box"))
            {
                heldObject = hit.collider.gameObject;
                heldObject.transform.SetParent(holdPosition);

                rbOfHeldObject = heldObject.GetComponent<Rigidbody>();
                rbOfHeldObject.constraints = RigidbodyConstraints.FreezeAll; // we want it to be stuck

                holdsObject = true;
                
                CalculateRotationVector(); 
            }
        }
    }
}
