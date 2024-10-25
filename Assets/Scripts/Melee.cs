using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private KeyCode attackHotkey;
    [SerializeField] private float weaponSpeed;
    [SerializeField] private float weaponRange;
    [SerializeField] private float weaponDamage;
    [SerializeField] private GameObject weapon;
    [SerializeField] private ContactFilter2D enemyFilter;

    private Collider2D weaponCollider;
    private List<Collider2D> hitEnemies;
    private float nextAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        nextAttackTime = 0f;
        weaponCollider = weapon.GetComponent<Collider2D>();
        List<Collider2D> hitEnemies = new List<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Attack every weaponSpeed seconds when holding down attack hotkey
        if (Input.GetKey(attackHotkey) && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + weaponSpeed;
            Attack();
        }
    }

    void Attack()
    {
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = targetPos - weapon.transform.position;

        // Rotate the weapon towards the mouse cursor, with an additional offset spread angle
        float zRot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0f, 0f, zRot);

        Physics2D.OverlapCollider(weaponCollider, enemyFilter, hitEnemies);

        foreach (Collider2D enemy in hitEnemies)
        {
            // TODO add in proper enemy function when that is implemented
        }
        // TODO Play an animation for the weapon
    }

    }
}
