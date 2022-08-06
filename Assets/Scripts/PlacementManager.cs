// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlacementManager : MonoBehaviour
// {
//     public GameObject basicTowerObject;

//     private GameObject dummyPlacement;

//     private GameObject hoverTile;

//     public LayerMask mask;

//     public bool isBuilding;

//     public void Start()
//     {
//         StartBuilding();
//     }

//     public Vector2 GetMousePosition()
//     {
//         //return GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
//         Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         return new Vector2(camera.ScreenToWorldPoint(Input.mousePosition.x), camera.ScreenToWorldPoint(Input.mousePosition.y));
//     }

//     public void currentHoverTile()
//     {
//         Vector2 mousePosition = GetMousePosition();

//         RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0, 0), 0.1f, mask, -100, 100);

//         if (hit.collider != null)
//         {
//             if (MapGenerator.mapTiles.Contains(hit.collider.gameObject) && !MapGenerator.pathTiles.Contains(hit.collider.gameObject))
//             {
//                 hoverTile = hit.collider.gameObject;
//             }
//         }
//     }

//     public void StartBuilding()
//     {
//         isBuilding = true;

//         dummyPlacement = Instantiate(basicTowerObject);

//         if (dummyPlacement.GetComponent<Tower>() != null)
//         {
//             Destroy(dummyPlacement.GetComponent<Tower>());
//         }

//         if (dummyPlacement.GetComponent<TowerRotation>() != null)
//         {
//             Destroy(dummyPlacement.GetComponent<TowerRotation>());
//         }
//     }

//     public void EndBuilding()
//     {
//         isBuilding = false;
//     }

//     public void Update()
//     {
//         if (isBuilding)
//         {
//             if (dummyPlacement != null)
//             {
//                 currentHoverTile();

//                 dummyPlacement.transform.position = hoverTile.transform.position;
//             }
//         }
//     }
// }
