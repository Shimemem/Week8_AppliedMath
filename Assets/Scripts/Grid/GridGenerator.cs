using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int width, height;
    public GameObject tilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region AddMaterialToTiles
    public void AssignMaterial()
    {
        // Find All Gameobject with Tag as Tile
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        Material material = Resources.Load<Material>("Tile");
        foreach(GameObject t in tiles)
        {
            t.GetComponent<Renderer>().material = material;
        }
    }
    #endregion
    public void GenerateGrid()
    {
        if (tilePrefab == null)
        {
            Debug.LogError("No Prefab Assigned");
            return;
        }
        // Loop throught the grid positions
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // calculate the position for each cube
                Vector3 position = new Vector3(x, 0, y);
                // Instantiate the at the calculated position
                GameObject newTile = Instantiate(tilePrefab, position, Quaternion.identity);
                newTile.transform.parent = transform;
                newTile.tag = "Tile";
            }
        }
    }

    public void DestroyGrid()
    {
        // Find all gameobjects tagged as "Tiles"
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in tiles)
        {
            DestroyImmediate(tile); 
        }
    }

    public void AssignTileScript()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in tiles)
        {
            tile.AddComponent<Tile>();
        }
    }
}
