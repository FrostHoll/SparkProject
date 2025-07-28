using Unity.VisualScripting;
using UnityEngine;

public class NecromancerStaff : RangeWeapon
{
    [SerializeField] private EnemyBaseAI enemyPrefab;

    public override void RangeAttack()
    {
        Vector3 enemySpawnPosition = RandomTransformGenerator.CreateRandomTransformNearObject(transform, 1.5f, 3, 0.5f, true);
        EnemyBaseAI enemyInstance = Instantiate(enemyPrefab, enemySpawnPosition, transform.rotation);
        Killer killer = enemyInstance.AddComponent<Killer>();
        killer.deathTime = attackStats.AttackRange * rangeMultiplier;
        EnemyController enemyController = enemyInstance.GetComponent<EnemyController>();
        enemyController.SetSide(attackMask, "Summon", GetComponentInParent<Controller>().gameObject.layer);
        enemyController.SetEnemyAttackStats(GetAtkStat(AtkStat.Damage), GetAtkStat(AtkStat.Repulsion));
        enemyInstance.GetComponentInChildren<EnemyAgr>().targetTag = GetFirstLayerNameFromMask.GetFirstLayerNameFromMaskk(attackMask.LayerMask);
    }
}
