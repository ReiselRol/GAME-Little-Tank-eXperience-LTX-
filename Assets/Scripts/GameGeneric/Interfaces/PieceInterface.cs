/// <summary>This Interface id for make a custom hability piece.</summary>
public interface PieceInterface
{
    /// <summary>This function is for the right click Hability (Use Base.HabilityRightClick();)</summary>
    void HabilityRightClick();
    /// <summary>This function is for the Left click Hability (Use Base.HabilityLeftClick();)</summary>
    void HabilityLeftClick();
    /// <summary>This function is for reset the values after we use some hability about this piece (Use Base.HabilityFiredRestartingPiece();)</summary>
    void HabilityFiredRestartingPiece();
    /// <summary>This function is for the animation of the hability before use it (Use Base.HabilityPrepared();).</summary>
    void HabilityPrepared();
    /// <summary>This function is for the clean up animation of the hability after use it or cancel it (Use Base.HabilityPreparationCleanUp();).</summary>
    void HabilityPreparationCleanUp();
}