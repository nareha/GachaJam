using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Text txt_lifeCount;
    public int defaultHealthCount;
    public int healthCount;

    public void Init()
    {
        healthCount = defaultHealthCount;
        txt_lifeCount.text = healthCount.ToString();
    }

    public void LoseHealth()
    {
        if (healthCount <= 0)
        {
            return;
        }
        
        healthCount--;
        txt_lifeCount.text = healthCount.ToString();
        CheckHealthCount();
    }

    void CheckHealthCount()
    {
        if (healthCount <= 0)
        {
            Debug.Log("you lost");
        }
    }
}
