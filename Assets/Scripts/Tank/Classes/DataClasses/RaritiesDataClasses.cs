/// <summary>This is a data class that contains an array of all the ararities </summary>
[System.Serializable]
public class RaritiesDC
{
    public RarityDC[] Rarities; 
}
[System.Serializable]
/// <summary>This is a data class that contains all the info you need about that rarity </summary>
public class RarityDC
{
    public LocalizableStringDC Name;
    public LocalizableStringDC Description;
    public int Price;

    /// <summary>This function is for find by id the Rairity info</summary>
    /// <param name="RarityID">This is the ID (position on the array of the json)</param>
    /// <returns>The Rarity with the info or null if is not finded</returns>
    public static RarityDC GetRarityByID(int RarityID)
    {
        RarityDC[] rarities = FileReader.FromJson<RaritiesDC>("Data/TankRarities").Rarities;
        if (RarityID >= 0 && RarityID < rarities.Length) return rarities[RarityID];
        else return null;
    }
}