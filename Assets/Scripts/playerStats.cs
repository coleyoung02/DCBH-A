using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public bool dead = false;
    // Health
    public Slider hpSlider;
    public int maxHealth = 100;
    public int health = 100;
    public int damageAmount = 10;
    public int healAmount = 10;
    // Mana
    public Slider mpSlider;
    public float maxMana = 100;
    public float mana = 100;
    public float castedMana = 10;
    public float regainMana = 10;
    public float regenMana = 3;
    void Start() 
    { 
        //despacito    
    }

    void Update()
    {
        if (!dead)
        {
            HealthCode();
            ManaCode();
        }
    }
    void ManaCode()
    {
        mpSlider.value = mana;

        if (mana > maxMana)
        {
            mana = maxMana;
        }
        if (Input.GetKeyDown(KeyCode.E) && mana > castedMana)
        {
            mana -= castedMana;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mana += regainMana;
        }
        // regen
        if (mana < maxMana)
        {
            mana += regenMana * Time.deltaTime;
        }
    }

    void HealthCode()
    {
        hpSlider.value = health;

        if (health <= 0)
        {
            dead = true;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            heal(healAmount);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            damage(damageAmount);
        }

        void heal(int healAmount) { health += healAmount; }
        void damage(int damage) { health -= damage; }
    }
}
