using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Car : Observer
{
    private GameObject objCar;
    private CarEvents carEvent;

    public Car(GameObject objCar, CarEvents carEvent)
    {
        this.objCar = objCar;
        this.carEvent = carEvent;
    }


    public override void OnNotify()
    {
        
        Move(carEvent.getMovement());
    }

    void Move(Vector3 movement)
    {
        objCar.GetComponent<Rigidbody>().AddForce(
            movement * 2000f);
    }
}
