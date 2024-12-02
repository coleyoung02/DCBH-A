using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor.Search;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public bool dead = false;

    [SerializeField] private GameObject deathMenu;

    // Health
    //public Slider hpSlider;
    public static int maxHealth = 100;
    public static int health = 100;
    public int damageAmount = 10;
    public int healAmount = 10;
    // Mana
    //public Slider mpSlider;
    public static float maxMana = 100;
    public static float mana = 100;
    public float castedMana = 10;
    public float regainMana = 10;
    public float regenMana = 3;

    [SerializeField] private GameObject molotovPrefab;
    [SerializeField] private GameObject fireballPrefab;
    private bool IFrames = false;
    private float IFrameTimer = 1f;

    private int molotovCount = 2;

    //a dictionary to declare which actions the player has equipped. This will need to be altered depending on how the player chooses
    //to equip their actions but for now it is hardcoded for simplicity
    private Dictionary<int, Action> actions = new Dictionary<int, Action>();

    private Animator animator;

  
    void Start() 
    {
        //despacito
        actions.Add(1, UseHealthPotion);
        actions.Add(2, UseManaPotion);
        actions.Add(3, CastFireball);
        actions.Add(4, ThrowMolotov);

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!GameManager.EnablePlayerInput)
        {
            return;
        }

        // Check if the player is dead and show the death menu
        if (dead == true)
        {
            // Set the active scene to the death scene
            SceneManager.LoadScene("Death");

            deathMenu.SetActive(true); // Show the death menu
            Time.timeScale = 0f; // Pause the game
        }

        if (!dead)
        {
            HealthCode();
            ManaCode();
        }
        if (IFrames)
        {
            if(IFrameTimer <= 0f)
            {
                IFrames = false;
                IFrameTimer = 1f;
            }
            else
            {
                IFrameTimer -= Time.deltaTime;
            }

        }
        if (Input.GetKeyDown("1"))
        {
            actions[1]();
        }
        if (Input.GetKeyDown("2"))
        {
            actions[2]();
        }
        if (Input.GetKeyDown("3"))
        {
            Debug.Log("Input detected");
            actions[3]();
        }
        if (Input.GetKeyDown("4"))
        {
            actions[4]();
        }
    }
    void ManaCode()
    {
        //mpSlider.value = mana;

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

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        // Reload the gameplay scenes (GameScene and PersistentObjects)
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single); // Reload the GameScene
        SceneManager.LoadScene("PersistentObjects", LoadSceneMode.Additive); // Reload PersistentObjects
        deathMenu.SetActive(false); // Hide the death menu
    }

    // Function to quit to the main menu
    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // Resume the game
        // Load the main menu scene
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        deathMenu.SetActive(false); // Hide the death menu
    }
    void HealthCode()
    {
       // hpSlider.value = health;

        if (health <= 0)
        {
            dead = true;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    heal(healAmount);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    damage(damageAmount);
        //}
        
        void heal(int healAmount) { health += healAmount; }
        void damage(int damage) { health -= damage; }
    }
    void UseManaPotion()
    {
        //adds to the players mana. Again, specific numbers are placeholders. 
        mana += 10;

        //We dont want the player to go over their maximum mana, so this makes sure to reset mana to max if it goes over
        if (mana > maxMana)
        {
            mana = maxMana;
        }

        Debug.Log("playerMana = " + mana);
    }

    //The last two methods are just placeholders for the purposes of testing if the "perform action" logic is working
    void CastFireball()
    {
        Debug.Log("Fireball is shot");
        if(mana > 25)
        {
            animator.SetTrigger("Cast");
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            fireball.GetComponent<Fireball>().Initialize(mousePosition);
            mana -= 25;
        }
        else
        {
            Debug.Log("YOU HAVE NO MANA");
        }
        
        
    }

     void ThrowMolotov()
    {
        if (molotovCount > 0) {
            animator.SetTrigger("Throw");
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            GameObject molotov = Instantiate(molotovPrefab, transform.position, Quaternion.identity);
            molotov.GetComponent<Molotov1>().Initialize(mousePosition);
            molotovCount--;
        }
        else
        {
            Debug.Log("No more cocktails");
        }
        
    }

    void HealSpell()
    {
        mana -= (maxMana/2);
        health = maxHealth;
    }
    void UseHealthPotion()
    {
        //simply adds to the players health. Again, specific numbers are placeholders. 
        health += 25;

        //We dont want the player to overheal, so this makes sure to reset health to max if it goes over
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Debug.Log("playerHealth = " + health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            IFrames = true;
            health -= 15;
            collision.gameObject.GetComponent<Enemy>().enemyHealth -= 15;
        }
    }

    public void takeDamage(int dmg)
    {
        health -= dmg;
    }
}
