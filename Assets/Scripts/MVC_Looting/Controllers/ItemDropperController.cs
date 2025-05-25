using UnityEngine;

public static class ItemDropperController
{
	public static void DropItem(GameObject itemPrefab, Vector3 position, float pushForce = 10f)
	{
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
