using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public Color normal;
    public Color aura;

    public SpriteRenderer spriteRenderer;

    public int spellDamage;
    public int staffDamage;
    public int health = 3;
    public int maxHealth = 3;

    public float speed;

    bool immune;

    [SerializeField] HeartSystem hearthSystem;

    private void Start()
    {
        hearthSystem.DrawHearts(health, maxHealth);
    }
    public void TakeDamage(int dmg)
    {
        if(health > 0 && !immune)
        {
            health -= dmg;
            hearthSystem.DrawHearts(health, maxHealth);
        }
        else if(health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
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
}