using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootingSystem : MonoBehaviour // кста, точно не знаю, но virtual я понатыкал для возможности его редактирования в детях.
{
    [SerializeField] protected DropItems _dropItems;
    [SerializeField] protected float TimeToDrop = 0.5f;
    [SerializeField] protected bool AlreadeyDropped = false;
    [SerializeField] protected float pushForce = 10f;

    public virtual IEnumerator DropItem() // Олег думает, что я читал его статью. На самом деле я просто взял код из его кликера для своего хо-хо хи-хи ха-ха
    {
        yield return new WaitForSeconds(TimeToDrop);
        GiveMeFromItems(_dropItems.ListItems);
        AlreadeyDropped = true;
    }
    public virtual void JumpItem(GameObject gameObject)
    {
        GameObject item = Instantiate(gameObject, transform.position, Quaternion.identity);
        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(0.8f, 1f),
            Random.Range(-1f, 1f)
            ).normalized;

        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(randomDirection * pushForce, ForceMode.Impulse);
        }
    }
    protected virtual GameObject GiveMeFromItems(List<ItemDrop> items)
    {
        List<int> chances = new List<int>();
        List<GameObject> gameitems = new List<GameObject>();
        int sum = 0;
        foreach (var x in items)
        {
            sum += x.weight;
            chances.Add(x.weight);
            gameitems.Add(x.gameObject);
        }
        for (int i = 1; i < chances.Count; i++)
        {
            chances[i] += chances[i - 1];
        }
        int rndchsilo = Random.Range(1, sum + 1);
        for (int i = 0; i < chances.Count; i++)
        {
            if (i == 0)
            {
                if (rndchsilo < chances[i])
                {
                    return gameitems[i];
                }
            }
            else if (rndchsilo > chances[i - 1] && rndchsilo < chances[i])
            {
                return gameitems[i];
            }
        }
        return null;
    }

    public virtual void ResetDrop()
    {
        AlreadeyDropped = false;
    }
}