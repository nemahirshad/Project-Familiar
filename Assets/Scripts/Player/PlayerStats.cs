using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public UpgradeObject upgradeObject;

    public Color normal;
    public Color aura;

    public SpriteRenderer spriteRenderer;

    public int spellDamage;
    public int staffDamage;
    public int health = 3;
    public int maxHealth = 3;
    public int armor = 0;

    public float speed;
    public float spellCooldown;

    public string sceneName;

    public bool levelZero;

    bool immune;

    [SerializeField] HeartSystem heartSystem;

    private void Start()
    {
        if (upgradeObject.melee)
        {
            UpgradeMelee();
        }

        if (upgradeObject.ranged)
        {
            UpgradeRanged();
        }

        if (upgradeObject.armor)
        {
            UpgradeArmor();
        }

        if (upgradeObject.health1)
        {
            UpgradeHealth();
        }

        if (upgradeObject.health2)
        {
            UpgradeHealth();
        }

        if (upgradeObject.health3)
        {
            UpgradeHealth();
        }

        if (!levelZero)
        {
            heartSystem.DrawHearts(health, maxHealth);
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void TakeDamage(int dmg)
    {
        if(health > 0 && !immune)
        {
            health -= dmg - armor;
            heartSystem.DrawHearts(health, maxHealth);
        }
    }

    public IEnumerator ActivateAura(int duration)
    {
        immune = true;
        spriteRenderer.color = aura;
        yield return new WaitForSeconds(duration);
        immune = false;
        spriteRenderer.color = normal;
    }

    public void UpgradeMelee()
    {
        staffDamage = 2;
    }

    public void UpgradeRanged()
    {
        spellCooldown = 1f;
    }

    public void UpgradeArmor()
    {
        armor = 1;
    }

    public void UpgradeHealth()
    {
        maxHealth++;
        health++;
    }
}