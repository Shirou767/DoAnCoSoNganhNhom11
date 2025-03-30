using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public int referenceHeight = 1080; // Độ cao pixel bạn muốn giữ nguyên
    public int pixelsPerUnit = 120; // PPU của sprite

    void Start()
    {
        Camera.main.orthographicSize = (float)referenceHeight / (2 * pixelsPerUnit);
    }
}
