public class Piece : PieceDC
{
    /// <summary> On the game how much points have the piece for the hability</summary>
    public int ActualCharges = 0;
    public Piece (PieceDC PieceInfo)
    {
        this.TankID = PieceInfo.TankID;
        this.Charges = PieceInfo.Charges;
        this.Price = PieceInfo.Price;
        this.Name = new LocalizableStringDC(PieceInfo.Name.ES, PieceInfo.Name.EN);
        this.AbilityName = new LocalizableStringDC(PieceInfo.AbilityName.ES, PieceInfo.AbilityName.EN);
        this.AbilityDescription = new LocalizableStringDC(PieceInfo.AbilityDescription.ES, PieceInfo.AbilityDescription.EN);
        this.PrefabID = PieceInfo.PrefabID;
    }
}
[System.Serializable]  
public class Item : ItemDC
{
    public int EspecializationID = -1;
    public int EspecializationCounter = 0;
    public int ColorID = -1;
    public int Cuantity = 1;
    /// <summary>Account name + # + AccountID</summary>
    public string AccountFrom = "Unknown";
    /// <summary> This will return the Especialization of that item. </summary>
    /// <returns>Especialization or Null</returns>
    public EspecializationDC GetEspecializationInfo() { return EspecializationDC.GetEspecializationInfoByID(this.EspecializationID);  }
    /// <summary> This will return the ColorDC of that item. </summary>
    /// <returns>Especialization or Null</returns>
    public ColorDC GetColorInfo() { return ColorDC.GetColorInfoByID(this.ColorID); } 
    public bool IsThisItemHaveEspecialization () { return this.EspecializationID > -1;  }
    public bool IsThisItemHaveColor () {  return this.ColorID > -1; }
}