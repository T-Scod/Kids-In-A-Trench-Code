using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Range(0, 100)]
    public int randFillPercent;
    public int width;
    public int height;
    public string seed;
    public bool useRandomSeed;

    private int[,] m_map;

    private void Start()
    {
        GenerateMap();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateMap();
        }
    }

    private void GenerateMap()
    {
        m_map = new int[width, height];
        RandomFillMap();

        for (int i = 0; i < 5; i++)
        {
            SmoothMap();
        }

        MeshGenerator meshGen = GetComponent<MeshGenerator>();
        meshGen.GenerateMesh(m_map, 1);
    }

    private void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.realtimeSinceStartup.ToString();
        }

        // pseudo random number generator
        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    m_map[x, y] = 1;
                }
                else
                {
                    m_map[x, y] = (pseudoRandom.Next(0, 100) < randFillPercent) ? 1 : 0;
                }
            }
        }
    }

    private void SmoothMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighbourWallTiles = GetSurroundingWallCount(x, y);

                if (neighbourWallTiles > 4)
                {
                    m_map[x, y] = 1;
                }
                else if (neighbourWallTiles < 4)
                {
                    m_map[x, y] = 0;
                }
            }
        }
    }

    private int GetSurroundingWallCount(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        wallCount += m_map[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }

    //private void OnDrawGizmos()
    //{
    //    if (m_map != null)
    //    {
    //        for (int x = 0; x < width; x++)
    //        {
    //            for (int y = 0; y < height; y++)
    //            {
    //                Gizmos.color = (m_map[x, y] == 1) ? Color.black : Color.white;
    //                Vector3 pos = new Vector3(-width / 2.0f + x + 0.5f, 0.0f, -height / 2.0f + y + 0.5f);
    //                Gizmos.DrawCube(pos, Vector3.one);
    //            }
    //        }
    //    }
    //}
}