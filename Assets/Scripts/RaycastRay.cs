using UnityEngine;
using Unity.VisualScripting;

public class RaycastRay : MonoBehaviour
{
    public static void ability(LayerMask surfaceLayer, float explosionRadius, float skillDamage)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, surfaceLayer))
        {
            Collider[] colliders = Physics.OverlapSphere(hitInfo.point, explosionRadius, surfaceLayer);
            foreach (Collider hit1 in colliders)
            {
                Controller health = hit1.GetComponent<Controller>();
                if (health != null)
                {
                    health.TakeDamage(skillDamage);
                }
            }
        }
    }
}

