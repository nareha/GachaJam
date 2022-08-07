using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() { instance = this; }

    public TowerSpawner spawner;
    public HealthSystem health;
    public ResearchPointSystem points;

    void Start()
    {
        GetComponent<HealthSystem>().Init();
        GetComponent<ResearchPointSystem>().Init();
    }
}
