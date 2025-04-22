using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public Vector3 rotation;

    public float followSpeed;

    private void Update()
    {
        if (target != null)
        {
            var playerPos = target.position;

            var targetPos = playerPos + offset;

            transform.rotation = Quaternion.Euler(rotation);

            transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        }
    }
}
