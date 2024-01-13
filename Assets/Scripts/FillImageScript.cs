using UnityEngine;

public class FillImageScript : MonoBehaviour
{
    public float lUnityPlaneSize = 10.0f; // 10 for a Unity3d plane
    void Update()
    {
        Camera lCamera = Camera.main;

   
            float lSizeY = lCamera.orthographicSize * 2.0f;
            float lSizeX = lSizeY * lCamera.aspect;
            transform.localScale = new Vector3(lSizeX / lUnityPlaneSize, 1, lSizeY / lUnityPlaneSize);
      
    }
}