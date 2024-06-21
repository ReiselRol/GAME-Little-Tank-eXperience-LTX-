using UnityEngine;

public partial class Tank
{
    private void Animation()
    {
        TankRotationAnimation();
        TankPiecePositionAndRotationAnimation();
    }
    private void TankPiecePositionAndRotationAnimation()
    {
        TankTracksAnimation();
        TankMoveInstanceToPositionAndRotate(this.TracksAnimations[0]);
        TankMoveInstanceToPositionAndRotate(this.TracksAnimations[1]);
        TankMoveInstanceToPositionAndRotate(this.CoreGameObject);
        TankMoveInstanceToPositionAndRotate(this.RearArmorGameObject);
        TankMoveInstanceToPositionAndRotate(this.FrontArmorGameObject);
    }
    private void TankMoveInstanceToPositionAndRotate(GameObject ThisInstance)
    {
        ExtraTransform.GoToInstance(ThisInstance, this.gameObject);
        ThisInstance.transform.rotation = this.TankAngle;
    }
    private void TankTracksAnimation()
    {
        if (this.TracksAnimations[0] != null && this.TracksAnimations[1] != null)
        {
            bool IsMoving = !(this.MovementHorizontalAxis == 0 && this.MovementVerticalAxis == 0);
            this.TracksAnimations[0].GetComponent<Tracks>().SetTracksIsMoving(IsMoving);
            this.TracksAnimations[1].GetComponent<Tracks>().SetTracksIsMoving(IsMoving);
        }
    }
    private void TankRotationAnimation()
    {

        bool isPointingUpp = this.GetMovementVerticalAxis() > 0;
        bool isPointingDown = this.GetMovementVerticalAxis() < 0;
        bool isPointingLeft = this.GetMovementHorizontalAxis() < 0;
        bool isPointingRight = this.GetMovementHorizontalAxis() > 0;
        if (isPointingUpp && !isPointingDown)
        {
            if (isPointingLeft && !isPointingRight) Angle.FixAngleTo(135, ref this.TankAngle);
            else if (!isPointingLeft && isPointingRight) Angle.FixAngleTo(45, ref this.TankAngle);
            else Angle.FixAngleTo(90, ref this.TankAngle);
        }
        else if (!isPointingUpp && isPointingDown)
        {
            if (isPointingLeft && !isPointingRight) Angle.FixAngleTo(225, ref this.TankAngle);
            else if (!isPointingLeft && isPointingRight) Angle.FixAngleTo(315, ref this.TankAngle);
            else Angle.FixAngleTo(270, ref this.TankAngle);
        }
        else
        {
            if (isPointingLeft && !isPointingRight) Angle.FixAngleTo(180, ref this.TankAngle);
            else if (!isPointingLeft && isPointingRight)
            {
                if (Angle.GetAngle(ref this.TankAngle) <= 270) Angle.FixAngleTo(0, ref this.TankAngle);
                else Angle.FixAngleTo(270, ref this.TankAngle);
            }
        }
    }
}