using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public Vector3 offset = new Vector3(0, 8, -10);

    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (player == null)
            return;

        Vector3 targetPosition = player.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.LookAt(player);
    }

    public void SetTarget(Transform newTarget)
    {
        player = newTarget;
    }

    public void ZoomIn()
    {
        offset.z = -6f;
    }

    public void ZoomOut()
    {
        offset.z = -12f;
    }

    public void ResetCamera()
    {
        offset = new Vector3(0, 8, -10);
    }
}
