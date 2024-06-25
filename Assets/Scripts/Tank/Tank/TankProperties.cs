using UnityEngine;
using System;

public partial class Tank
{
    [Header("Stats")]
    /// <summary>This is the Max shield the Tank has.</summary>
    [SerializeField] public int ConfiguredMaxShield = 50;
    /// <summary>This is the Max Life the Tank has.</summary>
    [SerializeField] public int ConfiguredMaxLife = 100;
    /// <summary>This is the Base seed that have the tank</summary>
    [SerializeField] public int ConfiguredSpeed = 11;
    [Header("Pieces")]
    /// <summary>This is the Piece ID of Core</summary>
    [SerializeField] public int ConfiguredCoreID = 0;
    /// <summary>This is the Piece ID of Tracks</summary>
    [SerializeField] public int ConfiguredTracksID = 0;
    /// <summary>This is the Piece ID of Front Armor</summary>
    [SerializeField] public int ConfiguredFrontArmorID = 0;
    /// <summary>This is the Piece ID of Rear Armor</summary>
    [SerializeField] public int ConfiguredRearArmorID = 0;
    [Header("Vanities")]
    /// <summary>This is the Piece ID of Core Vanity</summary>
    [SerializeField] public int ConfiguredCoreVanityID = -1;
    /// <summary>This is the Piece ID of Front Armor Vanity</summary>
    [SerializeField] public int ConfiguredFrontArmorVanityID = -1;
    /// <summary>This is the Piece ID of Rear Armor Vanity.</summary>
    [SerializeField] public int ConfiguredRearArmorVanityID = -1;
    [Header("Other Configs")]
    /// <summary>This is If we want to be an unactived Tank</summary>
    [SerializeField] public bool ConfiguredIsActived = true;
    /// <summary>This is If we want to be an unactived Tank</summary>
    [SerializeField] public bool ConfiguredIsABot = false;
    /// <summary> </summary>
    [SerializeField] public bool ConfiguredIsMainCamera = false;
    /// <summary>
    /// This Propertie is for define the team that is the tank from<br></br>
    /// If the team is -1 is for noone team.
    /// </summary>
    private int Team = -1;
    private Quaternion TankAngle = new Quaternion(0,0,0,0); 
    /// <summary> This Propertie represent the Base value of Spped that Have the Tank. </summary>
    private int BaseSpeed;
    /// <summary> This Propertie represent the Name of the player is playing this Tank. </summary>
    private string Name = "Unnamed";
    /// <summary> This Propertie represent the Max value of Life can Have the Tank. </summary>
    private int MaxLife = 100;
    /// <summary> This Propertie represent the Actual Life that has the Tank. </summary>
    private int Life;
    /// <summary> This Propertie represent the Max value of Shield can Have the Tank. </summary>
    private int MaxShield = 50;
    /// <summary> This Propertie represent the Actual Shield that has the Tank. </summary>
    private int Shield;
    /// <summary> This Propertie represent the Actual Speed that has the Tank. </summary>
    private int Speed;
    /// <summary> This Propertie represent the Actual Extra Damage that has the Tank. </summary>
    private double ExtraDamage = 1;
    /// <summary> This Propertie represent the Kills that has the Tank do it in the round. </summary>
    private int RoundKills = 0;
    /// <summary> This Propertie represent the Kills that has the Tank do it in the match. </summary>
    private int MatchKills = 0;
    /// <summary> This Propertie represent the Assists that has the Tank do it in the match. </summary>
    private int MatchAssists = 0;
    /// <summary> This Propertie represent the Divisa that has the Tank on the match. </summary>
    private int Divisa = 0;
    /// <summary>This props contains all the info about the piece called Core</summary>
    private Piece Core;
    /// <summary> On this Variable gonna have the Core GameObject</summary>
    private GameObject CoreGameObject;
    /// <summary>This props contains all the info about the piece called Tracks</summary>
    private Piece Tracks;
    /// <summary> On this Variable gonna have the Tracks GameObject</summary>
    private GameObject TracksGameObject;
    /// <summary>This is because the track gameobject about the piece never gonna have a custom image</summary>
    private GameObject [] TracksAnimations = new GameObject[2];
    /// <summary>This props contains all the info about the piece called Front Armor</summary>
    private Piece FrontArmor;
    /// <summary> On this Variable gonna have the Front Armor GameObject</summary>
    private GameObject FrontArmorGameObject;
    /// <summary>This props contains all the info about the piece called Rear Armor</summary>
    private Piece RearArmor;
    /// <summary> On this Variable gonna have the Rear Armor GameObject</summary>
    private GameObject RearArmorGameObject;
    /// <summary> The component of the SpriteRender </summary>
    private SpriteRenderer SpriteRender;
    /// <summary> The component of the Rigidbody2D </summary>
    private Rigidbody2D Rigidbody2D;
    /// <summary>This propertie saves de axis of the vertical movement (-1 to bottom and 1 to top)</summary>
    private float MovementVerticalAxis;
    /// <summary>This propertie saves de axis of the horizontal movement (-1 to left and 1 to right)</summary>
    private float MovementHorizontalAxis;
    /// <summary>This prop has the Main Camera of that tank (normally is disabled)</summary>
    private GameObject CameraGameObject;
    /// <summary>This is an important Gameobject that only gonna have actived the Main Tank</summary>
    private GameObject LightGameObject;
    /// <summary> This Function is gonna to set some properties to default values that other properties<br></br> Has defined but because is not static i can't assign it at the start.</summary>
    private void TankStartPropertiesSetter ()
    {
        this.TankLoadComponents();
        this.InitializeWheelsAnimations();
        this.BuildTank(ConfiguredCoreID, ConfiguredRearArmorID, ConfiguredFrontArmorID, ConfiguredTracksID);
    }
    private void  InitializeWheelsAnimations ()
    {
        GameObject TracksPrefab = Resources.Load<GameObject>("Objects/Tank/Tracks");
        GameObject CameraPrefab = Resources.Load<GameObject>("Objects/Tank/MainCamera");
        GameObject LightPrefab = Resources.Load<GameObject>("Objects/Tank/TankLight");

        this.CameraGameObject = Instantiate(CameraPrefab);
        this.LightGameObject = Instantiate(LightPrefab);
        this.LightGameObject.transform.SetParent(this.transform);

        if (!ConfiguredIsMainCamera)
        {
            this.CameraGameObject.SetActive(false);
            this.LightGameObject.SetActive(false);
        }

        this.TracksAnimations[0] = Instantiate(TracksPrefab, this.transform);
        this.TracksAnimations[1] = Instantiate(TracksPrefab, this.transform);

        this.TracksAnimations[0].transform.SetParent(this.transform);
        this.TracksAnimations[1].transform.SetParent(this.transform);

        this.TracksAnimations[0].transform.localScale = this.transform.localScale;
        this.TracksAnimations[1].transform.localScale = this.transform.localScale;

        this.TracksAnimations[1].GetComponent<SpriteRenderer>().flipY = true;
        this.TracksAnimations[1].GetComponent<SpriteRenderer>().sortingOrder = this.SpriteRender.sortingOrder - 1;
        this.TracksAnimations[0].GetComponent<SpriteRenderer>().sortingOrder = this.SpriteRender.sortingOrder - 1;
    }
    /// <summary>This function is for restart or reapply the properties of the tank about the stats<br></br> that  have the tank setted.</summary>
    private void TankRestartPropertiesSetter() {
        this.RestartBaseProperties();
        this.SetTankPiecesStatBonus();
        this.RestartProperties();
    }
    /// <summary>This function Take all the configured properties to set as a Base properties</summary>
    private void RestartBaseProperties()
    {
        this.BaseSpeed = this.ConfiguredSpeed;
        this.MaxLife = this.ConfiguredMaxLife;
        this.MaxShield = this.ConfiguredMaxShield;
        this.ExtraDamage = 1;
    }
    /// <summary>This function set the Life to the actual MaxLife, and do the same with the Speed and Shield</summary>
    private void RestartProperties()
    {
        this.Life = this.GetMaxLife();
        this.Shield = this.MaxShield - this.ConfiguredMaxShield;
        this.Speed = this.GetBaseSpeed();
    }
    /// <summary>This function gonna Load The components for use it.</summary>
    private void TankLoadComponents ()
    {
        this.SpriteRender = this.GetComponent<SpriteRenderer>();
        this.Rigidbody2D = this.GetComponent<Rigidbody2D>();
        this.SpriteRender.color = ColorManager.MakeColor(255, 255, 255, 0);
        this.Rigidbody2D.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    /// <summary> This Function is for set the extra stat bonus that the tank recive <br></br>For choosing some specific pieces.</summary>
    private void SetTankPiecesStatBonus()
    {
        double extraDamage = 0;
        double extraSpeed = 1;
        double extraLife = 1;
        double extraShield = 1;

        Piece[] pieces = { this.Core, this.Tracks, this.FrontArmor, this.RearArmor };
        for (int selectedPiece = 0; selectedPiece < pieces.Length; selectedPiece++)
        {
            if (pieces[selectedPiece] != null)
            {
                int multiplier = 1;
                if (selectedPiece == 0) multiplier = 3;

                TankDC TankFromThisPiece = pieces[selectedPiece].GetTankInfo();

                if (TankFromThisPiece != null)
                {
                    extraDamage += ((double)TankFromThisPiece.Stats.ExtraDamage / 100) * multiplier;
                    extraSpeed += ((double)TankFromThisPiece.Stats.Speed / 100) * multiplier;
                    extraLife += ((double)TankFromThisPiece.Stats.MaxLife / 100) * multiplier;
                    extraShield += ((double)TankFromThisPiece.Stats.MaxShield / 100) * multiplier;
                }
            }
        }
        this.MaxLife = (int)Math.Ceiling(this.MaxLife * extraLife);
        this.MaxShield = (int)Math.Ceiling(this.MaxShield * extraShield);
        this.BaseSpeed = (int)Math.Ceiling(this.BaseSpeed * extraSpeed);
        this.ExtraDamage += extraDamage;
    }
    /// <summary>This functionchange the pieces values and restart the props base the new pieces and ew bonusses</summary>
    private void BuildTank(int CoreID, int RearArmorID, int FrontArmorID, int TracksID)
    {
        this.BuildCore(CoreID);
        this.BuildRearArmor(RearArmorID);
        this.BuildFrontArmor(FrontArmorID);
        this.BuildTracks(TracksID);
        TankRestartPropertiesSetter();
    }
    /// <summary> This Function set the values of the core based on the Core ID</summary>
    private void BuildCore(int CoreID)
    {
        this.Core = new Piece(PieceDC.GetCoreByID(CoreID));
        GameObject PiecePrefab = this.Core.GetPiecePrefab();
        if (PiecePrefab != null)
        {
            if (this.CoreGameObject != null) Destroy(this.CoreGameObject);
            this.CoreGameObject = Instantiate(PiecePrefab, this.transform);
            this.CoreGameObject.transform.SetParent(this.transform);
            this.CoreGameObject.transform.localScale = this.transform.localScale;
            BuildCoreVanity();
        }
    }
    /// <summary>This gonna Change the vanity of </summary>
    private void BuildCoreVanity()
    {
        BuildCoreVanity(this.ConfiguredCoreVanityID);
    }
    /// <summary>This change the sprite of the piece Core</summary>
    /// <param name="VanityID">the id of the piece you want to renplce the sprite</param>
    private void BuildCoreVanity(int VanityID)
    {
        if (VanityID > -1)
        {
            SpriteRenderer pieceSpriteRenderer = this.CoreGameObject.GetComponent<SpriteRenderer>();
            if (pieceSpriteRenderer != null)
            {
                Sprite sprite = Resources.Load<Sprite>("Imgs/Tanks/Core/Core_" + VanityID);
                if (sprite != null) pieceSpriteRenderer.sprite = sprite;
            }
        }
    }
    /// <summary>Reset the Core Vanity</summary>
    private void UnBuildCoreVanity()
    {
        BuildCoreVanity(this.ConfiguredCoreID);
    }
    /// <summary> This Function set the values of the rear armor based on the RearArmor ID</summary>
    private void BuildRearArmor (int RearArmorID)
    {
        this.RearArmor = new Piece(PieceDC.GetRearArmorByID(RearArmorID));
        GameObject PiecePrefab = this.RearArmor.GetPiecePrefab();
        if (PiecePrefab != null)
        {
            if (this.RearArmorGameObject != null) Destroy(this.RearArmorGameObject);
            this.RearArmorGameObject = Instantiate(PiecePrefab, this.transform);
            this.RearArmorGameObject.transform.SetParent(this.transform);
            this.RearArmorGameObject.transform.localScale = this.transform.localScale;
            this.RearArmorGameObject.GetComponent<SpriteRenderer>().sortingOrder = this.SpriteRender.sortingOrder + 2;
            BuildRearArmorVanity();
        }
    }
    /// <summary>This gonna Change the vanity of Rear Armor</summary>
    private void BuildRearArmorVanity()
    {
        BuildRearArmorVanity(this.ConfiguredRearArmorVanityID);
    }
    /// <summary>This change the sprite of the piece Core</summary>
    /// <param name="VanityID">the id of the piece you want to renplce the sprite</param>
    private void BuildRearArmorVanity(int VanityID)
    {
        if (VanityID > -1)
        {
            SpriteRenderer pieceSpriteRenderer = this.RearArmorGameObject.GetComponent<SpriteRenderer>();
            if (pieceSpriteRenderer != null)
            {
                Sprite sprite = Resources.Load<Sprite>("Imgs/Tanks/RearArmor/RearArmor_" + VanityID);
                if (sprite != null) pieceSpriteRenderer.sprite = sprite;
            }
        }
    }
    /// <summary>Reset the Core Vanity</summary>
    private void UnBuildRearArmorVanity()
    {
        BuildRearArmorVanity(this.ConfiguredRearArmorID);
    }
    /// <summary> This Function set the values of the front armor based on the FrontArmor ID</summary>
    private void BuildFrontArmor(int FrontArmorID)
    {
        this.FrontArmor = new Piece(PieceDC.GetFrontArmorByID(FrontArmorID));
        GameObject PiecePrefab = this.FrontArmor.GetPiecePrefab();
        if (PiecePrefab != null)
        {
            if (this.FrontArmorGameObject != null) Destroy(this.FrontArmorGameObject);
            this.FrontArmorGameObject = Instantiate(PiecePrefab, this.transform);
            this.FrontArmorGameObject.transform.SetParent(this.transform);
            this.FrontArmorGameObject.transform.localScale = this.transform.localScale;
            this.FrontArmorGameObject.GetComponent<SpriteRenderer>().sortingOrder = this.SpriteRender.sortingOrder + 2;
            BuildFrontArmorVanity();
        }
    }
    /// <summary>This gonna Change the vanity of Front Armor</summary>
    private void BuildFrontArmorVanity()
    {
        BuildFrontArmorVanity(this.ConfiguredFrontArmorVanityID);
    }
    /// <summary>This change the sprite of the piece Core</summary>
    /// <param name="VanityID">the id of the piece you want to renplce the sprite</param>
    private void BuildFrontArmorVanity(int VanityID)
    {
        if (VanityID > -1)
        {
            SpriteRenderer pieceSpriteRenderer = this.FrontArmorGameObject.GetComponent<SpriteRenderer>();
            if (pieceSpriteRenderer != null)
            {
                Sprite sprite = Resources.Load<Sprite>("Imgs/Tanks/FrontArmor/FrontArmor_" + VanityID);
                if (sprite != null) pieceSpriteRenderer.sprite = sprite;
            }
        }
    }
    /// <summary>Reset the Core Vanity</summary>
    private void UnBuildFrontArmorVanity()
    {
        BuildFrontArmorVanity(this.ConfiguredFrontArmorID);
    }
    /// <summary> This Function set the values of the tracks based on the Tracks ID</summary>
    private void BuildTracks(int TracksID)
    {
        this.Tracks = new Piece(PieceDC.GetTracksByID(TracksID));
    }
    /// <summary>This Function is only used when the creation of the tank, don't use it on other site.</summary>
    /// <param name="MaxLife">If you put the MaxLife, this will increase this stat by the value</param>
    /// <param name="BaseSpeed">If you put the BaseSpeed, this will increase this stat by the value</param>
    /// <param name="MaxShield">If you put the MaxShield, this will increase this stat by the value</param>
    /// <param name="ExtraDamage">If you put the ExtraDamage, this will increase this stat by the value</param>
    private void UpgradeBaseAndMaxStats(int MaxLife = 0, int BaseSpeed = 0, int MaxShield = 0, int ExtraDamage = 0)
    {
        this.MaxLife += MaxLife;
        this.BaseSpeed += BaseSpeed;
        this.MaxShield += MaxShield;
        this.ExtraDamage += ExtraDamage;
    }
    /// <summary> This Function is for get the value of the Life form other class.</summary>
    /// <returns>Actual Life that has the Tank.</returns>
    public int GetLife() { return this.Life; }
    /// <summary> This Function is for get the value of the Max Life form other class.</summary>
    /// <returns> Max Life that has the Tank.</returns>
    public int GetMaxLife() { return this.MaxLife; }
    /// <summary> This Function is for get the value of the Shield form other class.</summary>
    /// <returns>Actual Shield that has the Tank.</returns>
    public int GetShield() { return this.Shield; }
    /// <summary> This Function is for get the value of the Max Shield form other class.</summary>
    /// <returns> Max Shield that has the Tank.</returns>
    public int GetMaxShield() { return this.MaxShield; }
    /// <summary> This Function is for get the value of the Speed form other class.</summary>
    /// <returns> Speed that has the Tank.</returns>
    public int GetSpeed() { return this.Speed; }
    /// <summary> This Function is for get the value of the Extra amage form other class.</summary>
    /// <returns> Extra Damage that has the Tank.</returns>
    public double GetExtraDamage() { return this.ExtraDamage; }
    /// <summary> This Function is for get the value of the Base Speed form other class.</summary>
    /// <returns> Base Speed that has the Tank.</returns>
    public int GetBaseSpeed() { return this.BaseSpeed; }
    /// <summary> This Function is for get the value of the Tank's Player Username form other class.</summary>
    /// <returns> Username that has the Tank.</returns>
    public string GetName() { return this.Name; }
    /// <summary> This Function is for get the value of the tank team form other class.</summary>
    /// <returns> Team that has the Tank.</returns>
    public int GetTeam() { return this.Team; }
    /// <summary> This Function is for get the value of the Kills done in this round form other class.</summary>
    /// <returns> Kills that has the Tank.</returns>
    public int GetRoundKills() {  return this.RoundKills; }
    /// <summary> This Function is for get the value of the Kills done in all the match form other class.</summary>
    /// <returns> Kills that has the Tank.</returns>
    public int GetMatchKills() { return this.MatchKills; }
    /// <summary> This Function is for get the value of the Assists done in all the match form other class.</summary>
    /// <returns> Assists that has the Tank.</returns>
    public int GetMatchAssists() { return this.MatchAssists; }
    /// <summary> This Function is for get the value of the Divisa form other class.</summary>
    /// <returns> Divisa that has the Tank on that Match.</returns>
    public int GetDivisa() { return this.Divisa; }
    /// <summary> This Function is for get the Info about Core piece.</summary>
    /// <returns> An object with de info about Core Piece.</returns>
    public Piece GetCorePiece() { return this.Core; }
    /// <summary> This Function is for get the Info about Core piece.</summary>
    /// <returns> An object with de info about Tracks Piece.</returns>
    public Piece GetTracksPiece() { return this.Tracks; }
    /// <summary> This Function is for get the Info about Core piece.</summary>
    /// <returns> An object with de info about Front Armor Piece.</returns>
    public Piece GetFrontArmorPiece() { return this.FrontArmor; }
    /// <summary> This Function is for get the Movement Vertical Axis.</summary>
    /// <returns> -1 is to bottom and 1 is to top</returns>
    public float GetMovementVerticalAxis() {  return this.MovementVerticalAxis; }
    /// <summary> This Function is for get the Movement Horizontal Axis.</summary>
    /// <returns> -1 is to Left and 1 is to Right</returns>
    public float GetMovementHorizontalAxis() { return this.MovementHorizontalAxis; }
    /// <summary> This Function return the Rigibody2D of that Object</summary>
    /// <returns> Rigibody2D component</returns>
    public Rigidbody2D GetRigidbody2D() {  return this.Rigidbody2D; }
    /// <summary> This Function return the SpriteRender of that Object</summary>
    /// <returns> SpriteRender component</returns>
    public SpriteRenderer GetSpriteRenderer() { return this.SpriteRender; }
    /// <summary> This Functions return the GameObject of Core Piece</summary>
    /// <returns>GameObject of Core Piece</returns>
    public GameObject GetCoreGameObject() {  return this.CoreGameObject; }
    /// <summary> This Functions return the GameObject of Tracks Piece</summary>
    /// <returns>GameObject of Tracks Piece</returns>
    public GameObject GetTracksGameObject() { return this.TracksGameObject; }
    /// <summary> This Functions return the GameObject of Front Armor Piece</summary>
    /// <returns>GameObject of Front Armor Piece</returns>
    public GameObject GetFrontArmorGameObject() { return this.FrontArmorGameObject; }
    /// <summary> This Functions return the GameObject of Rear Armor Piece</summary>
    /// <returns>GameObject of Rear Armor Piece</returns>
    public GameObject GetRearArmorGameObject() { return this.RearArmorGameObject; }
    /// <summary>Normal setter to determinate if this tank is a bot</summary>
    public void SetIsABot(bool IsABot){ this.ConfiguredIsABot = IsABot; }
    public void SetConfiguredPieces(int CoreID, int RearArmorID, int FrontArmorID, int TracksID)
    {
        this.ConfiguredCoreID = CoreID;
        this.ConfiguredRearArmorID = RearArmorID;
        this.ConfiguredFrontArmorID = FrontArmorID;
        this.ConfiguredTracksID = TracksID;
        BuildTank(CoreID, RearArmorID, FrontArmorID, TracksID);
    }
    /// <summary>Returns if this tank is a bot or no</summary>
    public bool GetIsABot() {  return this.ConfiguredIsABot; }
    /// <summary>If you want to see all the Tank props on console use this</summary>
    /// <returns>The tank info in a String</returns>
    override public string ToString()
    {
        string ToString = 
                          "--------------------------------------------------------------"
                      + "\n                    T A N K   S T A T S"
                      + "\n--------------------------------------------------------------" + "\n"
                      + "\n  Life : " + this.Life + " / " + this.MaxLife
                      + "\n  Shield : " + this.Shield + " / " + this.MaxShield
                      + "\n  Damage : " + (this.ExtraDamage * 100) + "%"
                      + "\n  Speed : " + this.BaseSpeed + "\n"
                      + "\n--------------------------------------------------------------"
                      + "\n                        P I E C E S"
                      + "\n--------------------------------------------------------------"
                      + "\n\n  Core:"
                      + "\n" + this.Core.ToString()
                      + "\n\n  Tracks:"
                      + "\n" + this.Tracks.ToString()
                      + "\n\n  Front Armor:"
                      + "\n" + this.FrontArmor.ToString()
                      + "\n\n  Rear Armor:"
                      + "\n" + this.RearArmor.ToString() + "\n"
                      + "\n--------------------------------------------------------------";
        return ToString;
    }
    /// <summary>This function will change the sprites of the pieces to original pieces</summary>
    public void UnBuildVanity ()
    {
        UnBuildCoreVanity();
        UnBuildRearArmorVanity();
        UnBuildFrontArmorVanity();
    }
    /// <summary>This functions will change the sprites of the ppieces to the vanities one</summary>
    public void BuildVanity ()
    {
        BuildCoreVanity();
        BuildRearArmorVanity();
        BuildFrontArmorVanity();
    }
}