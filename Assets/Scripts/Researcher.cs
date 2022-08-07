using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Researcher : Tower
{
    public float interval;
    public int incomeValue;

    public override void Init()
    {
        StartCoroutine(Interval());
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        IncreaseIncome();
    }

    public void IncreaseIncome()
    {
        GameManager.instance.points.Gain(incomeValue);
        StartCoroutine(Interval());
    }
}
