public abstract partial class Weapon
{
    /// <summary>For balance the game the weapons have "ZoomPills" added based the WeaponTier</summary>
    public static int ZoomPillsForce = 5;
    /// <summary>This prop is the damage will do the weapon on hit one sinlge bullet</summary>
    private int Damage;
    /// <summary>The cooldown between bullets</summary>
    private Timer ShootCooldown;
    /// <summary>The cooldown that have the weapon reloading</summary>
    private Timer ReloadingCooldown;
    /// <summary>Total bullets that have the weapon on start</summary>
    private int TotalBullets;
    /// <summary>Total max bullets gonna recieve the bullets from TotalBullets when thr weapon is recharged</summary>
    private int MaxBulletsOnRecharge;
    /// <summary>The actual Bullets that have the weapon</summary>
    private int ActualBullets;
    /// <summary>The angle that default have opened</summary>
    private double AccuracityAngle;
    /// <summary>The angle that when is moving the tank has</summary>
    private double AccuracityOpenedAngle;
    /// <summary>The actual angle that have in that moment the weapon</summary>
    private double ActualAngle;
    /// <summary>The level of the weapon on grab it. 0 is Small, 1 is Large, 2 is Special</summary>
    private int Type;
    /// <summary> With this </summary>
    private int Tier;
    /// <summary>The boolean is selfexplainatory</summary>
    private bool IsWeaponDropped;
    /// <summary>The boolean is selfexplainatory</summary>
    private bool IsZooming;
    /// <summary>This double will be added to the camera size.</summary>
    private double ActualExtraZoom;
    /// <summary>The max of the Extra Zoom The weapon gona Have</summary>
    private double MaxExtraZoom;
    /// <summary>This Function is for try recharging and recharge the weapon if can do it.</summary>
    public void RechargeWeapon()
    {
        if (!WeaponIsBussy())
        {
            if (ActualBullets < MaxBulletsOnRecharge && TotalBullets > 0)
            {
                ReloadingCooldown.Reset();
                int BulletsCanRecharge;
                int totalBulletsWantToRecharge = MaxBulletsOnRecharge - ActualBullets;
                if (totalBulletsWantToRecharge <= TotalBullets)
                {
                    BulletsCanRecharge = totalBulletsWantToRecharge;
                    TotalBullets -= totalBulletsWantToRecharge;
                } else
                {
                    BulletsCanRecharge = TotalBullets;
                    TotalBullets = 0;
                }
                ActualBullets = BulletsCanRecharge;
            }
        }
    }
    /// <summary>This function return if the weapon is on any cooldown of shooting or recharging</summary>
    private bool WeaponIsBussy () { return ShootCooldown.IsFinished() && ReloadingCooldown.IsFinished(); }
    /// <summary>This function will be the action when is shoots</summary>
    public abstract void ShootAction();
    public void Shoot()
    {
        if (!WeaponIsBussy() && ActualBullets > 0)
        {
            ShootAction();
            ActualBullets--;
        }
    }
}