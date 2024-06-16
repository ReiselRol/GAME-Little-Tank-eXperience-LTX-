using UnityEngine;
public partial class Tank : StepEvents
{
    public void BeforeStep()
    {
        this.TankReadInputs();
    }

    public void Step()
    {
        this.TankMovement();
    }
    public void AfterStep()
    {
        Animation();
    }
    private void TankReadInputs()
    {
        this.MovementVerticalAxis = Input.GetAxis("Vertical");
        this.MovementHorizontalAxis = Input.GetAxis("Horizontal");
    }
    private void TankMovement()
    {
        float speedX = this.MovementHorizontalAxis * this.Speed;
        float speedY = this.MovementVerticalAxis * this.Speed;

        this.Rigidbody2D.velocity = new Vector2(speedX, speedY);
    }
}