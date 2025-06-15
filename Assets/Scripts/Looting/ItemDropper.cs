using UnityEngine;
using System.Collections;
public class ItemDropper : MonoBehaviour
{
    [SerializeField] private float pushForce = 10f; // Вынесено отдельно от метода, причина - UnityEvent иначе не видит.
    public void DropItem(GameObject itemPrefab, Vector3 position, float timeToDrop)
    {
        StartCoroutine(IEDropItem(itemPrefab, position, timeToDrop));

    }
    public IEnumerator IEDropItem(GameObject itemPrefab, Vector3 position, float timeToDrop)
    {
        yield return new WaitForSeconds(timeToDrop);

        GameObject item = Object.Instantiate(itemPrefab, position, Quaternion.identity);
        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(0.8f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;

        if (item.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(randomDirection * pushForce, ForceMode.Impulse);
        }
    }
}