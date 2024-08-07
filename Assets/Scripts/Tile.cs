using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool current;
    public bool target;
    public bool selectable;
    public bool walkable;

    //needed for BFS
    public bool visited = false;
    public Tile parent = null;
    public int distance = 0;

    private List<Tile> adjacencyList = new List<Tile>();

    //For A*
    public float f = 0;
    public float g = 0;
    public float h = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (selectable)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void ResetValues()
    {
        current = false;
        target = false;
        selectable = false;

        visited = false;
        parent = null;
        distance = 0;

        f = g = h = 0;
    }
    
    public void FindNeighbors(float jumpHeight)
    {
        ResetValues();
        CheckTiles(Vector3.forward, jumpHeight);
        CheckTiles(Vector3.back, jumpHeight);
        CheckTiles(Vector3.right, jumpHeight);
        CheckTiles(Vector3.left, jumpHeight);
    }

    public void CheckTiles(Vector3 direction, float jumpHeight)
    {
        Vector3 halfExtents = new(0.25f, (1+jumpHeight)/2 , 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);
        foreach (Collider item in colliders)
        {
            Tile tile = item.GetComponent<Tile>();
            if (tile != null && tile.walkable)
            {
                RaycastHit hit;
                if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
                {
                    adjacencyList.Add(tile);
                }
            }
        }
    }
}
