using UnityEngine;

public class ResolutionChange : MonoBehaviour
{
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
