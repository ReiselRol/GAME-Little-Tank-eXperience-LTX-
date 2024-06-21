using UnityEngine;

/// <summary>This class has </summary>
public static class Angle
{
    public static void FixAngleTo(int angleToCheck, ref Quaternion Quaternion, int angleSpeed = 15)
    {
        int actualAngle = (int)GetAngle(ref Quaternion);
        if (angleToCheck > actualAngle)
        {
            if (angleToCheck < actualAngle + angleSpeed) SetAngle(angleToCheck, ref Quaternion);
            else SetAngle(actualAngle + angleSpeed, ref Quaternion);
        }
        else
        {
            if (angleToCheck > actualAngle - angleSpeed) SetAngle(angleToCheck, ref Quaternion);
            else SetAngle(actualAngle - angleSpeed, ref Quaternion);
        }
    }
    public static void FixAngleTo(int angleToCheck, Transform Transform, int angleSpeed = 15) {
        Quaternion rotation = Transform.rotation;
        FixAngleTo(angleToCheck, ref rotation, angleSpeed);
    }
    public static void FixAngleTo(int angleToCheck, Rigidbody2D Rigidbody2D, int angleSpeed = 15) { FixAngleTo(angleToCheck, Rigidbody2D.transform, angleSpeed); }
    public static void SetAngle(int angle, ref Quaternion Quaternion)
    {
        Quaternion.eulerAngles = new Vector3(Quaternion.eulerAngles.x, Quaternion.eulerAngles.y, (float)angle);
    }
    public static void SetAngle(int angle, Rigidbody2D Rigidbody2D) { SetAngle(angle, Rigidbody2D.transform); }
    public static void SetAngle(int angle, Transform Transform) {
        Quaternion rotation = Transform.rotation;
        SetAngle(angle, ref rotation);
    }
    public static float GetAngle (Rigidbody2D Rigidbody2D) { return GetAngle(Rigidbody2D.transform); }
    public static float GetAngle (Transform Transform) {
        Quaternion rotation = Transform.rotation;
        return GetAngle(ref rotation);
    }
    public static float GetAngle(ref Quaternion Quaternion) { return Quaternion.eulerAngles.z; }
}