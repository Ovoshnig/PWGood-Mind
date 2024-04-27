using UnityEngine;
using UnityEngine.Video;

public class ClipPlay : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private CameraController cameraController;

    void Update()
    {
        videoPlayer.enabled = cameraController.LastHit == this.gameObject;
    }
}
