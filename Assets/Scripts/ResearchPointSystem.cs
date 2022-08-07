using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchPointSystem : MonoBehaviour
{
    public Text txt_Points;
    public int defaultPoints;
    public int points;

    public void Init()
    {
        points = defaultPoints;
        UpdateUI();
    }

    public void Gain(int val)
    {
        points += val;
        UpdateUI();
    }

    public bool Use(int val)
    {
        if (EnoughPoints(val))
        {
            points -= val;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool EnoughPoints(int val)
    {
        return (val <= points);
    }

    void UpdateUI()
    {
        txt_Points.text = points.ToString();
    }

    public void USE_TEST()
    {
        Debug.Log(Use(3));
    }
}
