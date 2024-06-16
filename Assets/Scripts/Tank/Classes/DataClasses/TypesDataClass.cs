using UnityEngine;

/// <summary>This is a data class that store all the types (roles) of the tanks.</summary>
[System.Serializable]
public class TypesDC
{
    public TypeDC[] Types;
}
/// <summary>This is a data class that store all the info about the rarity.</summary>
[System.Serializable]
public class TypeDC
{
    public LocalizableStringDC Name;
    public LocalizableStringDC Description;

    /// <summary>This function is for find by id the Type info</summary>
    /// <param name="TypeID">This is the ID (position on the array of the json)</param>
    /// <returns>The Type with the info or null if is not finded</returns>
    public static TypeDC GetTypeByID(int TypeID)
    {
        TypeDC[] types = FileReader.FromJson<TypesDC>("Data/TankTypes").Types;
        if (TypeID >= 0 && TypeID < types.Length) return types[TypeID];
        else return null;
    }
}