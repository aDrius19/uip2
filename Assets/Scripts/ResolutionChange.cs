/* ResolutionChange.cs
 * This file contains the ResolutionChange class which controls the settings of the screen resolution.
 */
using UnityEngine;

public class ResolutionChange : MonoBehaviour
{

    /// <summary>
    /// Depending on the resolution selected in settings, these methods will update the screen resolution when in windowed mode.
    /// </summary>
    public void Resolution1()
    {
        Screen.SetResolution(800, 600, FullScreenMode.Windowed);
    }

    public void Resolution2()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }

    public void Resolution3()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }
}
