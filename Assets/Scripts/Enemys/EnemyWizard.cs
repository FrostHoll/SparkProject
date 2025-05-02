using UnityEngine;

public class EnemyWizard : BaseEnemy
{
    public float teleportMaxRadius = 10f;
    public float teleportMinRadius = 6f;
    public float teleportHeight = 0.5f;
    public float teleportTime = 2f;
    private float timer = 0f;

    public GameObject bullet;
    [SerializeField]private Transform shotPoint;
    private RandomTransformGenerator transformGenerator;
    private Animator animator;

    private void Start()
    {
        transformGenerator = GetComponent<RandomTransformGenerator>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isAngry)
        {
            LookAtTarget(player);
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                MoveEnemy(player);
            }
        }
    }

    public override void Attack()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation * Quaternion.Euler(0, 0, 180f));
    }

    public override void MoveEnemy(Transform target)
    {
        animator.SetTrigger("isTeleporting");
        timer = teleportTime;
    }

    public void EnemyTeleportation()
    {
        transform.position = transformGenerator.CreateRandomTransformNearObject(player, teleportMaxRadius, teleportMinRadius, teleportHeight);
    }
}
