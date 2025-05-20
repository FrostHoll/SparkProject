using UnityEngine;

public class EnemyController : Controller
{
    [SerializeField] private BaseEnemy baseEnemy;
    private void Start()
    {
        model = new EnemyModel(baseStats);
        model.HealthChanged += view.OnHealthChanged;
        baseEnemy = GetComponent<BaseEnemy>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) //для проверки
        {
            ApplyHealing(10f);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamage(10f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            baseEnemy.isAngry = true;
            baseEnemy.player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            baseEnemy.isAngry = false;
        }
    }
}
