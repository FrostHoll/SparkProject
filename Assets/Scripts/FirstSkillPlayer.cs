using System.Collections;
using UnityEngine;

public class FirstSkillPlayer : MonoBehaviour
{
    [Header("Skill settings")]
    [SerializeField] private float playerDisable = 0.5f; // Player control shutdown time
    [SerializeField] private float castTime = 1f; // The "lifetime" time of the skill area
    [SerializeField] private float skillCooldown = 5f;
    [SerializeField] private float skillDamage = 10f;
    [SerializeField] private float explosionRadius = 3f;
    [SerializeField] private KeyCode abilityKey = KeyCode.Alpha1;
    [SerializeField] LayerMask surfaceLayer;
    private bool isOnCooldown = false;
    PlayerMovement playerControlls;

    public void ApplyBuff(float addCoolDown, float addDamage, float addRadius)
    {
        skillCooldown += addCoolDown;
        skillDamage += addDamage;
        explosionRadius += addRadius;
    }

    void Start()
    {
        playerControlls = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(abilityKey) && !isOnCooldown)
        {
            isOnCooldown = true;
            StartCoroutine(UseAbility());
        }
    }

    private IEnumerator UseAbility()
    {
        if (playerControlls != null)
            playerControlls.enabled = false;

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

        yield return new WaitForSeconds(castTime);

        yield return new WaitForSeconds(playerDisable - castTime);
        if (playerControlls != null)
            playerControlls.enabled = true;

        yield return new WaitForSeconds(skillCooldown - playerDisable - castTime);
        isOnCooldown = false;
    }

}

interface IBuffable
{
    void ApplyBuff(float addCoolDown, float addDamage, float addRadius);
}