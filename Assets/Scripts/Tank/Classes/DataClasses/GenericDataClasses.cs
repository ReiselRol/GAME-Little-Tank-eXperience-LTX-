/// <summary>This is a Data Class for read strings in diferent localizations.</summary>
[System.Serializable]
public class LocalizableStringDC
{
    /// <summary>The String on Spanish Languaje</summary>
    public string ES;
    /// <summary>The String on English Languaje</summary>
    public string EN;
    public LocalizableStringDC(string ES, string EN)
    {
        this.ES = ES;
        this.EN = EN;
    }
    /// <summary> This function will return the string of the language you pass by id:<br></br> - 0: English (EN).<br></br> - 1: Spanish (ES). </summary>
    /// <param name="LocalizationID">This is the Int id you need to pass, if you dont pass any this will be a English version</param>
    /// <returns>The translated string.</returns>
    public string GetStringByLocalizableID(int LocalizationID = 0)
    {
        switch (LocalizationID)
        {
            case 0: return this.EN;
            case 1: return this.ES;
            default: return this.EN;
        }
    }
    /// <summary> This function will return the string of the language you pass by id:<br></br>  - 0: English (EN).<br></br>  - 1: Spanish (ES).  </summary>  <param name="LocalizationID">This is the String id you need to pass, if you dont pass any this will be a English version</param>
    /// <returns>The translated string.</returns>
    public string GetStringByLocalizableID(string LocalizationID)
    {
        switch (LocalizationID.ToUpper())
        {
            case "EN": return this.EN;
            case "ES": return this.ES;
            default: return this.EN;
        }
    }
}