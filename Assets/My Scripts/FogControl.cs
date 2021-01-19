// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

[AddComponentMenu("Rendering/Fog Layer")]
[RequireComponent(typeof(Camera))]
public class FogControl : MonoBehaviour
{
    private bool revertFogState = false;

    void OnPreRender()
    {
        revertFogState = RenderSettings.fog;
        RenderSettings.fog = enabled;
    }

    void OnPostRender()
    {
        RenderSettings.fog = revertFogState;
    }

    


}
