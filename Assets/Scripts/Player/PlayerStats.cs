using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public int damage;
    public float speed;
    public int hearts = 3;
    public int maxHearts = 3;
    private float EmptyHearts = 0;
    [SerializeField] HeartSystem hs;


    private void Start()
    {
        hs.DrawHearts(hearts, maxHearts);
    }
    public void TakeDamage(int dmg)
    {
        if(hearts > 0)
        {
            hearts -= dmg;
            hs.DrawHearts(hearts, maxHearts);
        }
        else if(hearts <= EmptyHearts)
        {
            SceneManager.LoadScene("SampleScene");
        }
        
        
}
}
