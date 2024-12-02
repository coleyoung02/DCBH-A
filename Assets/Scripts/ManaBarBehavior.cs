using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBarBehavior : MonoBehaviour
{
    public GameObject manabar; // Health bar GameObject
    public float default_width = 3f; // default width of mana bar

    void Start()
    {
        UpdateManaBar(); // Initialize
    }

    // Update is called once per frame
    void Update()
    {
        UpdateManaBar();
    }

    //Update the mana bar based on current mana
    void UpdateManaBar()
    {
        Vector3 newScale = manabar.transform.localScale;
        newScale.x = default_width * PlayerHealth.mana / PlayerHealth.maxMana; //change mana bar length
        manabar.transform.localScale = newScale;
    }

    //directly set mana to a proportion
    public void SetManaFraction(float fraction)
    {
        PlayerHealth.mana = Mathf.RoundToInt(PlayerHealth.maxMana * fraction);
        UpdateManaBar();
    }

    //test half mana
    [ContextMenu("Set Half Mana")]
    void SetHalfMana()
    {
        SetManaFraction(0.5f);
    }

    [ContextMenu("Set Full Mana")]
    void SetFullMana()
    {
        SetManaFraction(1.0f);
    }

}
