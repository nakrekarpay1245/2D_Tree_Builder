using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gold;

    public Text goldText;

    private Building buildingToPlace;

    public GameObject grid;

    public CustomCursor customCursor;

    public Tile[] tiles;
    void Update()
    {
        goldText.text = "G : " + gold.ToString();

        if (Input.GetMouseButton(0) && buildingToPlace != null)
        {
            Tile nearestTile = null;
            float nearestDistance = float.MaxValue;
            foreach (Tile tile in tiles)
            {
                float distance = Vector2.Distance(tile.transform.position,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestTile = tile;
                }
            }

            if (!nearestTile.isOccupied)
            {
                Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity);
                buildingToPlace = null;
                nearestTile.isOccupied = true;
                grid.SetActive(false);
                customCursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }

    public void BuyBuilding(Building building)
    {
        if (gold >= building.cost)
        {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;
            gold -= building.cost;
            buildingToPlace = building;
            grid.SetActive(true);
        }
    }
}
