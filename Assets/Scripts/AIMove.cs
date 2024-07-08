using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    List<Tile> selectableTiles = new();
    GameObject[] tiles;

    Stack<Tile> path = new();
    Tile currentTile;

    public int move = 5;
    public float jumpHeight = 2;
    public float moveSpeed;
    public bool moving = false;
    public float jumpVelocity = 4.5f;

    Vector3 velocity = new();
    Vector3 heading = new();

    float halfHeight = 0;

    bool fallingDown = false;
    bool JumpingUp = false;
    bool movingEdge = false;
    Vector3 jumpTarget;

    public Tile actualTargetTile;

    protected void Init()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        halfHeight = GetComponent<Collider>().bounds.extents.y;
    }

    public void GetCurrentTile()
    {
        currentTile = GetTargetTile(gameObject);
        currentTile.current = true;
    }     

    public Tile GetTargetTile(GameObject target)
    {
        RaycastHit hit;
        Tile tile = null;

        if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1)) 
        {
            tile = hit.collider.GetComponent<Tile>();
        }
        return tile;
    }

    public void FindSelectableTiles()
    {
        ComputeAdjacencyLists(jumpHeight, null);
        GetCurrentTile();

        Queue<Tile>
    }
}
