using UnityEngine;

/// <summary>This class has </summary>
public static class Angle
{
    public static void FixAngleTo(int angleToCheck, Rigidbody2D Rigidbody2D, int angleSpeed = 15)
    {
        int actualAngle = (int)GetAngle(Rigidbody2D);
        if (angleToCheck > actualAngle)
        {
            if (angleToCheck < actualAngle + angleSpeed) SetAngle(angleToCheck, Rigidbody2D);
            else SetAngle(actualAngle + angleSpeed, Rigidbody2D);
        }
        else
        {
            if (angleToCheck > actualAngle - angleSpeed) SetAngle(angleToCheck, Rigidbody2D);
            else SetAngle(actualAngle - angleSpeed, Rigidbody2D);
        }
    }
    public static void SetAngle (int angle, Rigidbody2D Rigidbody2D) {
        Rigidbody2D.transform.eulerAngles = new Vector3(Rigidbody2D.transform.eulerAngles.x, Rigidbody2D.transform.eulerAngles.y, (float)angle);
    }
    public static float GetAngle (Rigidbody2D Rigidbody2D) { return Rigidbody2D.transform.eulerAngles.z; }
}