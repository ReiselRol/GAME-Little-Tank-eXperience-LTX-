using UnityEngine;
/// <summary>This is a dtataclass for read the TankPiece.json</summary>
[System.Serializable]
public class PiecesDC
{
    public PieceDC[] Core;
    public PieceDC[] Tracks;
    public PieceDC[] FrontArmor;
    public PieceDC[] RearArmor;
}
/// <summary>This is a data class that have all the info about a piece</summary>
[System.Serializable]
public class PieceDC
{
    /// <summary> This is the part of the path to find the prefab</summary>
    public string PrefabID;
    /// <summary>This ID is for search on other JSON the tank is from that piece.</summary>
    public int TankID;
    /// <summary>The value you need to pay to buy a ability</summary>
    public int Price = -1;
    public LocalizableStringDC Name;
    public LocalizableStringDC AbilityName;
    public LocalizableStringDC AbilityDescription;
    /// <summary> The cuantity that can have of max charges for habilities</summary>
    public int Charges;

    /// <summary>This function is for find by id the Core Piece</summary>
    /// <param name="CoreID">This is the ID (position on the array of the json)</param>
    /// <returns>The Piece with the info or null if is not finded</returns>
    public static PieceDC GetCoreByID(int CoreID)
    {
        PieceDC[] pieces = FileReader.FromJson<PiecesDC>("Data/TankPieces").Core;
        if (CoreID >= 0 && CoreID < pieces.Length) return pieces[CoreID];
        else return null;
    }
    /// <summary>This function is for find by id the Tracks Piece</summary>
    /// <param name="TracksID">This is the ID (position on the array of the json)</param>
    /// <returns>The Piece with the info or null if is not finded</returns>
    public static PieceDC GetTracksByID(int TracksID)
    {
        PieceDC[] pieces = FileReader.FromJson<PiecesDC>("Data/TankPieces").Tracks;
        if (TracksID >= 0 && TracksID < pieces.Length) return pieces[TracksID];
        else return null;
    }
    /// <summary>This function is for find by id the Front Armor Piece</summary>
    /// <param name="FrontArmorID">This is the ID (position on the array of the json)</param>
    /// <returns>The Piece with the info or null if is not finded</returns>
    public static PieceDC GetFrontArmorByID(int FrontArmorID)
    {
        PieceDC[] pieces = FileReader.FromJson<PiecesDC>("Data/TankPieces").FrontArmor;
        if (FrontArmorID >= 0 && FrontArmorID < pieces.Length) return pieces[FrontArmorID];
        else return null;
    }
    /// <summary>This function is for find by id the Rear Armor Piece</summary>
    /// <param name="RearArmorID">This is the ID (position on the array of the json)</param>
    /// <returns>The Piece with the info or null if is not finded</returns>
    public static PieceDC GetRearArmorByID(int RearArmorID)
    {
        PieceDC[] pieces = FileReader.FromJson<PiecesDC>("Data/TankPieces").RearArmor;
        if (RearArmorID >= 0 && RearArmorID < pieces.Length) return pieces[RearArmorID];
        else return null;
    }
    /// <summary> This will return the Tankinfo of that piece. </summary>
    /// <returns>TankDC or Null</returns>
    public TankDC GetTankInfo() { return TankDC.GetTankByID(this.TankID); }
    /// <summary>This return a gameObject of the piece prefab for be instantiated</summary>
    /// <returns>a prefab</returns>
    public GameObject GetPiecePrefab () {
        return Resources.Load<GameObject>(this.PrefabID); 
    }

    override public string ToString()
    {
        string ToString =
                        "  Name : " + this.Name.EN
                    + "\n  Piece Role : " + this.GetTankInfo().GetTypeInfo().Name.EN + "  [ID : " + this.GetTankInfo().TypeID + "]"
                    + "\n  Tank From : " + this.GetTankInfo().Name.EN + "  [ID : " + this.TankID + "]";
        return ToString;
    }
}