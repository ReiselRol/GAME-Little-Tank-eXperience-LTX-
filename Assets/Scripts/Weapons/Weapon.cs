using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Weapon : MonoBehaviour
{
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        this.BeforeStep();
        this.Step();
        this.AfterStep();
    }
}
