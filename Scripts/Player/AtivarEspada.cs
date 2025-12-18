using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarEspada : Unico<AtivarEspada>
{
    public MonoBehaviour CurrentActiveWeapon { get; private set; }

    private PlayerControlo playerControlo;
    private float timeBetweenAttacks;

    private bool attackButtonDown, isAttacking = false;

    protected override void Awake() {
        base.Awake();

        playerControlo = new PlayerControlo();
    }

    private void OnEnable()
    {
        playerControlo.Enable();
    }

    private void Start()
    {
        playerControlo.Combate.Ataque.started += _ => StartAttacking();
        playerControlo.Combate.Ataque.canceled += _ => StopAttacking();

        AttackCooldown();
    }

    private void Update() {
        Attack();
    }

    public void NewWeapon(MonoBehaviour newWeapon) {
        CurrentActiveWeapon = newWeapon;

        AttackCooldown();
    }

    public void WeaponNull() {
        CurrentActiveWeapon = null;
    }

    private void AttackCooldown() {
        isAttacking = true;
        StopAllCoroutines();
        StartCoroutine(TimeBetweenAttacksRoutine());
    }

    private IEnumerator TimeBetweenAttacksRoutine() {
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking = false;
    }

    private void StartAttacking()
    {
        attackButtonDown = true;
    }

    private void StopAttacking()
    {
        attackButtonDown = false;
    }

    private void Attack() {
        if (attackButtonDown && !isAttacking && CurrentActiveWeapon) {
            AttackCooldown();
        }
    }
}
