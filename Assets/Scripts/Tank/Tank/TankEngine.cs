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
        TankCameraPosition();
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

        if (speedX != 0 || speedY != 0)
        {
            this.Rigidbody2D.velocity = new Vector2(speedX, speedY);
        }

        /*
         * Esto equivale pisar el Hielo:
         Vector2 force = new Vector2(speedX, speedY);
         this.Rigidbody2D.AddForce(force);
        */
    }
    private void TankCameraPosition()
    {
        ExtraTransform.GoToInstance(this.CameraGameObject, this.gameObject, false);
        ExtraTransform.GoToInstance(this.LightGameObject, this.gameObject, false);
        this.CameraGameObject.transform.position = new Vector3(this.CameraGameObject.transform.position.x, this.CameraGameObject.transform.position.y, -10);
    }
}