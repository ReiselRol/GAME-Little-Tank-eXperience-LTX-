using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightStarter : MonoBehaviour
{
    void Start()
    {
        Light2D GlobalLight = GetComponent<Light2D>();
        GlobalLight.intensity = 0f;
    }
}
