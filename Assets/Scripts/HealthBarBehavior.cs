using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehavior : MonoBehaviour
{
    public GameObject healthbar; // Health bar GameObject
    public float default_width = 3f; // default width of health bar

    void Start()
    {
        UpdateHealthBar(); // Initialize
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    //Update the health bar based on current health
    void UpdateHealthBar()
    {
        Vector3 newScale = healthbar.transform.localScale;
        newScale.x = default_width * PlayerHealth.health / PlayerHealth.maxHealth; //change health bar length
        healthbar.transform.localScale = newScale;
    }

    //directly set health to a proportion
    public void SetHealthFraction(float fraction)
    {
        PlayerHealth.health = Mathf.RoundToInt(PlayerHealth.maxHealth * fraction);
        UpdateHealthBar();
    }

    //test half health
    [ContextMenu("Set Half Health")]
    void SetHalfHealth()
    {
        SetHealthFraction(0.5f);
    }

    [ContextMenu("Set Full Health")]
    void SetFullHealth()
    {
        SetHealthFraction(1.0f);
    }

}
