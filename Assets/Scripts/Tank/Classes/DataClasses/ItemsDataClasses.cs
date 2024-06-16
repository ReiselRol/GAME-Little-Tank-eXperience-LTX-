using Unity.VisualScripting;
using UnityEngine;
/// <summary>This is a data class that have a propertie that has all the items</summary>
[System.Serializable]
public class ItemsDC
{
    public ItemDC[] ItemList;
}
/// <summary>This data class have soe props for get all base props and functions for know what kind of items is that.</summary>
[System.Serializable]
public class ItemDC
{
    public LocalizableStringDC Name;
    public int RarityID = 0;
    public int TypeID = -1;
    public int CoreID = -1;
    public int TracksID = -1;
    public int FrontArmorID = -1;
    public int RearArmorID = -1;
    public string SpriteID;
    public int CrateID = -1;
    public int TitleID = -1;
    public bool IsThisItemSellable = false;
    public bool IsThisItemTradeable = false;

    public bool IsThisItemACrate () { return this.CrateID > -1; }
    public bool IsThisItemACore () { return this.CoreID > -1; }
    public bool IsThisItemATracks() { return this.TracksID > -1; }
    public bool IsThisItemAFrontArmor() { return this.FrontArmorID > -1; }
    public bool IsThisItemARearArmor() { return this.RearArmorID > -1; }
    public bool IsThisItemAPiece() { return this.TypeID > -1; }
    public bool IsThisItemATitle() { return this.TitleID > -1; }

    /// <summary>This function is for find by id the Item info</summary>
    /// <param name="ItemID">This is the ID (position on the array of the json)</param>
    /// <returns>The Item with the info or null if is not finded</returns>
    public static ItemDC GetItemInfoByID(int ItemID)
    {
        ItemDC[] items = FileReader.FromJson<ItemsDC>("Data/TankItems").ItemList;
        if (ItemID >= 0 && ItemID < items.Length) return items[ItemID];
        else return null;
    }
}
/// <summary>This dataClass has all the Especalizations in one prop</summary>
[System.Serializable]
public class EspecializationsDC
{
    public EspecializationDC [] Especializations;
}
/// <summary>This dataClass has the info about Especalizations</summary>
[System.Serializable]
public class EspecializationDC
{
    public LocalizableStringDC Name;
    public LocalizableStringDC Description;

    /// <summary>This function is for find by id the Especialization info</summary>
    /// <param name="EspecializationID">This is the ID (position on the array of the json)</param>
    /// <returns>The Especialization with the info or null if is not finded</returns>
    public static EspecializationDC GetEspecializationInfoByID(int EspecializationID)
    {
        EspecializationDC[] Especializations = FileReader.FromJson<EspecializationsDC>("Data/TankEspecializations").Especializations;
        if (EspecializationID >= 0 && EspecializationID < Especializations.Length) return Especializations[EspecializationID];
        else return null;
    }
}
/// <summary>This is a data that have all the colors in one prop.</summary>
[System.Serializable]
public class ColorsDC
{
    public ColorDC[] Colors;
}
/// <summary>This is a data that have the info abuot the color.</summary>
[System.Serializable]
public class ColorDC
{
    public LocalizableStringDC Name;
    public string Color = "FFFFFF";

    /// <summary>This function is for find by id the Color info</summary>
    /// <param name="ColorID">This is the ID (position on the array of the json)</param>
    /// <returns>The Color with the info or null if is not finded</returns>
    public static ColorDC GetColorInfoByID(int ColorID)
    {
        ColorDC[] Colors = FileReader.FromJson<ColorsDC>("Data/TankColors").Colors;
        if (ColorID >= 0 && ColorID < Colors.Length) return Colors[ColorID];
        else return null;
    }
    /// <summary>With the hexadecimal this color gonna create the unity class Color</summary>
    /// <returns>Color in UityEngine Class Color</returns>
    public Color GetColor () { return ColorManager.MakeColor(this.Color); }
}