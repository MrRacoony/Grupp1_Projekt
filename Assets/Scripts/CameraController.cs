using UnityEngine;

public static class CameraService
{
    public static Camera ActiveCamera { get; private set; }

    public static void SetActiveCamera(Camera cam)
    {
        ActiveCamera = cam;
    }
}
