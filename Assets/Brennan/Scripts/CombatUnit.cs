using UnityEngine;

public abstract class CombatUnit : MonoBehaviour
{
    #region Runtime Stats

    // Current HP during battle.
    // This is reset each time the unit is spawned.
    protected int currentHP;

    // Runtime combat stats.
    // These may differ from the base data due to
    // level scaling, buffs, debuffs, equipment, etc.
    protected int attack;
    protected int defense;

    protected float moveSpeed;
    protected float attackRange;
    protected float attackCooldown;

    #endregion

    #region Runtime State

    // Countdown until this unit can attack again.
    protected float attackTimer;

    // The unit this combatant is currently fighting.
    protected CombatUnit currentTarget;

    // Whether the unit has died.
    protected bool isDead = false;

    #endregion

    #region Cached Components

    protected Rigidbody2D rb;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    #endregion

    #region Unity

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        if (isDead)
            return;

        // Countdown attack cooldown.
        attackTimer -= Time.deltaTime;

        // ================================
        // COMBAT LOOP
        //
        // 1. Find a target if we don't have one.
        // 2. Move towards the target.
        // 3. Check attack range.
        // 4. Attack if cooldown is ready.
        //
        // CharacterCombat and EnemyCombat
        // will provide the target searching
        // and movement direction.
        // ================================
    }

    #endregion

    #region Initialization

    /// <summary>
    /// Initializes this combat unit using runtime stats.
    /// CharacterCombat and EnemyCombat will call this.
    /// </summary>
    protected void InitializeStats(
        int maxHP,
        int attack,
        int defense,
        float moveSpeed,
        float attackRange,
        float attackCooldown)
    {
        currentHP = maxHP;

        this.attack = attack;
        this.defense = defense;

        this.moveSpeed = moveSpeed;
        this.attackRange = attackRange;
        this.attackCooldown = attackCooldown;
    }

    #endregion

    #region Targeting

    /// <summary>
    /// CharacterCombat:
    ///     Find the nearest EnemyCombat.
    ///
    /// EnemyCombat:
    ///     Find the nearest CharacterCombat.
    /// </summary>
    protected abstract CombatUnit FindTarget();

    #endregion

    #region Movement

    /// <summary>
    /// CharacterCombat:
    ///     Returns Vector2.right.
    ///
    /// EnemyCombat:
    ///     Returns Vector2.left.
    /// </summary>
    protected abstract Vector2 GetMoveDirection();

    /// <summary>
    /// Handles movement.
    /// Can later support knockback,
    /// slows, stuns, etc.
    /// </summary>
    protected virtual void Move()
    {
        transform.Translate(
            GetMoveDirection() *
            moveSpeed *
            Time.deltaTime);
    }

    #endregion

    #region Combat

    /// <summary>
    /// Called whenever this unit attacks.
    ///
    /// Later this can:
    /// - Play animation
    /// - Spawn projectile
    /// - Trigger skills
    /// - Play sound
    /// </summary>
    protected virtual void Attack()
    {

    }

    /// <summary>
    /// Applies incoming damage.
    ///
    /// Later this can support:
    /// - Critical hits
    /// - Shields
    /// - Armor
    /// - Damage reduction
    /// </summary>
    public virtual void TakeDamage(int damage)
    {

    }

    /// <summary>
    /// Called when HP reaches zero.
    ///
    /// Later this can:
    /// - Play death animation
    /// - Notify WaveManager
    /// - Drop loot
    /// - Grant EXP
    /// </summary>
    protected virtual void Die()
    {

    }

    #endregion
}