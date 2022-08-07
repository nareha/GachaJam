using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health;

    public void LoseHealth(int amount)
    {
        health -= amount;

        StartCoroutine(BlinkRed());

        if (health <= 0)
        {
            GameManager.instance.points.Gain(1);
            Destroy(transform.gameObject);
        }
    }

    IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
