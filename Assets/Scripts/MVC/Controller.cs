using UnityEditor.Experimental;
using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    protected Model model;
    protected View view;
    public PlayerController characterController;
    public EnemyController enemyController;
    [SerializeField] protected BaseStats baseStats;

    private void Awake()
    {
        view = GetComponent<View>();
    }

    public void ApplyHealing(float amount)
    {
        model.ApplyHealing(amount);
        view.UpdateHealthBar(model.HP,model.stats.MaxHP);
    }

    public void TakeDamage(float damage)
    {
        model.TakeDamage(damage);
        view.UpdateHealthBar(model.HP,model.stats.MaxHP);
    }

    public void CharacterAddArtifact(Artifact artifact)
    {
        if (artifact == null) return;

        artifact.ApplyEffect(characterController);
    }

    public void EnemyAddArtifact(Artifact artifact)
    {
        if (artifact == null) return;

        artifact.ApplyEffect(enemyController);
    }

}
