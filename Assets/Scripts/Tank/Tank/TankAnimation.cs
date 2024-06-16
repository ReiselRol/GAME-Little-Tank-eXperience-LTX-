public partial class Tank
{
    private void Animation()
    {
        TankRotationAnimation();
        TankPiecePositionAndRotationAnimation();
    }
    private void TankPiecePositionAndRotationAnimation()
    {
        TankTracksAniation();
        ExtraTransform.GoToInstance(this.CoreGameObject, this.gameObject, true);
        ExtraTransform.GoToInstance(this.RearArmorGameObject, this.gameObject, true);
        ExtraTransform.GoToInstance(this.FrontArmorGameObject, this.gameObject, true);
    }
    private void TankTracksAniation()
    {
        if (this.TracksAnimations[0] != null && this.TracksAnimations[1] != null)
        {
            bool IsMoving = !(this.MovementHorizontalAxis == 0 && this.MovementVerticalAxis == 0);

            ExtraTransform.GoToInstance(this.TracksAnimations[0], this.gameObject, true);
            ExtraTransform.GoToInstance(this.TracksAnimations[1], this.gameObject, true);
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
            if (isPointingLeft && !isPointingRight) Angle.FixAngleTo(135, this.Rigidbody2D);
            else if (!isPointingLeft && isPointingRight) Angle.FixAngleTo(45, this.Rigidbody2D);
            else Angle.FixAngleTo(90, this.Rigidbody2D);
        }
        else if (!isPointingUpp && isPointingDown)
        {
            if (isPointingLeft && !isPointingRight) Angle.FixAngleTo(225, this.Rigidbody2D);
            else if (!isPointingLeft && isPointingRight) Angle.FixAngleTo(315, this.Rigidbody2D);
            else Angle.FixAngleTo(270, this.Rigidbody2D);
        }
        else
        {
            if (isPointingLeft && !isPointingRight) Angle.FixAngleTo(180, this.Rigidbody2D);
            else if (!isPointingLeft && isPointingRight)
            {
                if (Angle.GetAngle(this.Rigidbody2D) <= 270) Angle.FixAngleTo(0, this.Rigidbody2D);
                else Angle.FixAngleTo(270, this.Rigidbody2D);
            }
        }
    }
}