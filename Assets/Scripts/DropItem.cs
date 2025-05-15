using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private float pushForce = 30f;

    public void JumpItem(GameObject gameObject)
    {
        GameObject item = Instantiate(gameObject, transform.position, Quaternion.identity);
        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(0.5f, 1f),
            Random.Range(-1f, 1f)
            ).normalized;

        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(randomDirection * pushForce, ForceMode.Impulse);
        }

    }
}
