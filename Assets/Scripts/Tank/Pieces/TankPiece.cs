using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary> This class is for make the Hability functions about a piece, important to do:<br></br> 1.- Implement functions CanHabilityRightClick and CanHabilityLeftClick.<br></br> 2.- Implement functions with base of the  hability HabilityLeftClick and HabilityRightClick (override). <br></br> 3.- Implement functions HabilityFiredRestartingPiece for do the clean up for the next hability<br></br> usage (try do a call of this function after you finish to do an hability) 4.- Implements the functions of HabilityPrepared and HabilityPreparationCleanUp </summary>
public abstract class TankPiece : MonoBehaviour
{
    /// <summary>This boolean is for check if is Before using hability</summary>
    private bool IsHoldingPreparation = false;
    /// <summary>This boolean is for check if is firing hability</summary>
    private bool IsFiring = false;
    /// <summary>This Piece Object is the Same that Has the dad Gameobject</summary>
    private Piece PieceInfo;
    /// <summary>This function is for the animation of the hability before use it.</summary>
    public virtual void HabilityPrepared()
    {
        this.IsHoldingPreparation = true;
        this.IsFiring = false;
    }
    /// <summary>This function is for the clean up animation of the hability after use it or cancel it.</summary>
    public virtual void HabilityPreparationCleanUp()
    {
        this.IsHoldingPreparation = false;
        this.IsFiring = false;
    }
    /// <summary>This function is for the right click Hability</summary>
    public virtual void HabilityRightClick()
    {
        if (CanHabilityRightClick() == false) return;
        this.IsHoldingPreparation = false;
        this.IsFiring = true;
    }
    /// <summary>This function is for the Left click Hability</summary>
    public virtual void HabilityLeftClick()
    {
        if (CanHabilityLeftClick() == false) return;
        this.IsHoldingPreparation = false;
        this.IsFiring = true;
    }
    /// <summary>This function is for reset the values after we use some hability about this piece</summary>
    public virtual void HabilityFiredRestartingPiece()
    {
        this.IsHoldingPreparation = false;
        this.IsFiring = false;
    }
    /// <summary>This hability is for check if the piece can do the Right Click Hability (HabilityRightClick)</summary>
    public abstract bool CanHabilityRightClick();
    /// <summary>This hability is for check if the piece can do the Left Click Hability (HabilityLeftClick)</summary>
    public abstract bool CanHabilityLeftClick();
    public bool GetIsHoldingPreparation () { return this.IsHoldingPreparation; }
    public bool GetIsFiring () { return this.IsFiring; }
    public Piece GetPieceInfo () { return this.PieceInfo; }
    public void SetPieceInfo (Piece PieceInfo) { this.PieceInfo = PieceInfo; }
}
