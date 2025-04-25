using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public LayerMask surfaceLayer;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, surfaceLayer))
        {
            Vector3 targetDirection = hitInfo.point - transform.position; 
            targetDirection.y = 0;
            Quaternion targetPlayerRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetPlayerRotation, rotationSpeed * Time.deltaTime); 
        }
    }
}
