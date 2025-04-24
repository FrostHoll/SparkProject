using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    public float rotationSpeed = 45f;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 targetDirection = hitInfo.point - transform.position; 
            targetDirection.y = 0;
            Quaternion targetTowerRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetTowerRotation, rotationSpeed * Time.deltaTime); 
        }
    }
}
