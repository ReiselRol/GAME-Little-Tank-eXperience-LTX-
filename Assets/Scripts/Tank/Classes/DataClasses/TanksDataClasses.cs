/// <summary> This is a Data Class that with it we can read the Json of all the Tanks Info </summary>
[System.Serializable]
public class TanksDC
{
    public TankDC[] Tanks;
}
/// <summary> This Dataclass have all the info about the tanks</summary>
[System.Serializable]
public class TankDC
{
    /// <summary>With this prop you can find the infor about the Type of the tank (duelist, iniciator...)</summary>
    public int TypeID;
    public LocalizableStringDC Name;
    public LocalizableStringDC Lore;
    public StatsDC Stats;
    public PiecesID PiecesID;

    /// <summary>This function is for find by id the Tank info</summary>
    /// <param name="TankID">This is the ID (position on the array of the json)</param>
    /// <returns>The Tank with the info or null if is not finded</returns>
    public static TankDC GetTankByID(int TankID)
    {
        TankDC[] tanks = FileReader.FromJson<TanksDC>("Data/TankTanks").Tanks;
        if (TankID >= 0 && TankID < tanks.Length) return tanks[TankID];
        else return null;
    }
    /// <summary> This will return the Type info of that Tank. </summary>
    /// <returns>TypeDC or Null</returns>
    public TypeDC GetTypeInfo() { return TypeDC.GetTypeByID(this.TypeID); }
}
/// <summary> This Dataclass have the info of how expendede the 7 point are on the stats</summary>
[System.Serializable]
public class StatsDC
{
    public int MaxLife;
    public int MaxShield;
    public int ExtraDamage;
    public int Speed;
}
/// <summary>This data class is for know what pieces is from that tank</summary>
[System.Serializable]
public class PiecesID
{
    public int CoreID;
    public int TracksID;
    public int FrontArmor;
    public int RearArmor;

    public PieceDC GetCorePiece() { return PieceDC.GetCoreByID(this.CoreID); }
    public PieceDC GetTracksPiece() { return PieceDC.GetCoreByID(this.TracksID); }
    public PieceDC GetFrontArmorPiece() { return PieceDC.GetCoreByID(this.FrontArmor); }
    public PieceDC GetRearArmorPiece() { return PieceDC.GetCoreByID(this.RearArmor); }
}