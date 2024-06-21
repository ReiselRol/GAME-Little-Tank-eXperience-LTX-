using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Tank : MonoBehaviour
{
    
    private void Start() {
        this.TankStartPropertiesSetter();
        Debug.Log(this.ToString());
    }

    
    private void FixedUpdate()
    {
        if (this.ConfiguredIsActived)
        {
            this.BeforeStep();
            this.Step();
        }
        this.AfterStep();
    }
}
