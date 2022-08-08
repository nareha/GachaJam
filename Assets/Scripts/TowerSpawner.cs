using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{
    public List<GameObject> towersPrefabs;
    public Transform spawnTowerRoot;
    public List<Image> towersUI;

    public Tilemap spawnTilemap;

    int spawnID = -1;

    private bool selected = false;

    public void SelectTower(int id)
    {
        if (selected)
        {
            return;
        }

        spawnID = id;
        towersUI[spawnID].color = Color.white;
        selected = true;
    }

    public void DeselectTower()
    {
        towersUI[spawnID].color = new Color(0.5f, 0.5f, 0.5f);
        spawnID = -1;
        selected = false;
    }

    private void DetectSpawnPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);

            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                int towerCost = towersPrefabs[spawnID].GetComponent<Tower>().cost;
                if (GameManager.instance.points.EnoughPoints(towerCost))
                {
                    GameManager.instance.points.Use(towerCost);
                    SpawnTower(cellPosCentered);
                    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else
                {
                    DeselectTower();
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DeselectTower();
        }
    }

    private void SpawnTower(Vector3 position)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);

        tower.transform.position = position;

        tower.GetComponent<Tower>().Init();

        DeselectTower();
    }

    private void Update()
    {
        if (spawnID != -1)
        {
            DetectSpawnPoint();
        }
    }
}
