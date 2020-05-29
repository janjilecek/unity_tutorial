using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarEvents
{
    public abstract Vector3 getMovement();
}

public class MoveBack : CarEvents
{
    public override Vector3 getMovement()
    {
        return Vector3.back;
    }
}

public class MoveLeft : CarEvents
{
    public override Vector3 getMovement()
    {
        return Vector3.left;
    }
}

public class MoveUp : CarEvents
{
    public override Vector3 getMovement()
    {
        return Vector3.up;
    }
}