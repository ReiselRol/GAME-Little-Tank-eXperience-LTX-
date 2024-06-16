using UnityEngine;

public static class ExtraTransform
{
    /// <summary>This will move the instance position to other instance position</summary>
    /// <param name="thisInstance">The instannce we want to move</param>
    /// <param name="toThisIntance">The new instance position we want</param>
    public static void GoToInstance(GameObject thisInstance, GameObject toThisIntance, bool CopyRotation = false)
    {
        if (thisInstance != null && toThisIntance != null)
        {
            thisInstance.transform.position = toThisIntance.transform.position;
            if (CopyRotation) thisInstance.transform.rotation = toThisIntance.transform.rotation;
        }
    }
}