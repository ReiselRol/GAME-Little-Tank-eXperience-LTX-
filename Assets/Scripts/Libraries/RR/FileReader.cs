using UnityEngine;
public static class FileReader
{
    /// <summary>This Function will return the information that contaain some file to you DataClass model that you create</summary>
    /// <typeparam name="T">You need to pass your DataClass</typeparam>
    /// <param name="filePath">the path starting from the "Assets/Resources/"</param>
    /// <returns>The DataClass Object with the info</returns>
    public static T FromJson<T>(string filePath)
    {
        return JsonUtility.FromJson<T>(Resources.Load<TextAsset>(filePath).text);
    }
}