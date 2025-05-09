using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private int TyepOfItems;
    [SerializeField] private bool IsOpen = false;
    public Animator animator;
    public Interaction inter;
    public Looting looting = new Looting();

    public GameObject ItemFromChest;
    public float pushForce = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) // DEBUG
        {
            IsOpen = false;
        }
        if (inter.Interacting == true && inter.ListOfItemsInInteractionZone.Contains(gameObject.name) && IsOpen == false)
        {
            Interact(); // Анимка
            HorrorJumpItem(looting.GiveMeFromItems1(looting.items1)); // ВЫброс предмета
        }
    }
    public void Interact()
    {
        animator.SetBool("Openning", true);
        IsOpen = true;
    }
    public void HorrorJumpItem(string name)
    {
        GameObject item = Instantiate(ItemFromChest, transform.position, Quaternion.identity);
        TextMeshPro textMesh = item.GetComponentInChildren<TextMeshPro>();
        if (textMesh != null)
        {
            textMesh.text = name;
        }

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
