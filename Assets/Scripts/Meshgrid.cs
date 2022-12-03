using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Meshgrid
{
    private int numX, numY, numZ;
    private float minX, maxX, minY, maxY, minZ, maxZ;

    private Vector3[] mesh;

    // Constructor for 3D Grids
    public Meshgrid(int numX, int numY, int numZ, float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
    {
        this.numX = numX;
        this.numY = numY;
        this.numZ = numZ;
        this.minX = minX;
        this.maxX = maxX;
        this.minY = minY;
        this.maxY = maxY;
        this.minZ = minZ;
        this.maxZ = maxZ;
        createMeshgrid();
    }

    // Constructor for 2D Grids (Calls 3D Constructor with z = 0)
    public Meshgrid(int numX, int numY, float minX, float maxX, float minY, float maxY) : this(numX, numY, 1, minX, maxX, minY, maxY, 0, 0)
    {

    }

    // Empty Constructor for easy default 2D mesh
    public Meshgrid() : this(11, 11, 1, -5, 5, -5, 5, 0, 0)
    {

    }

    private void createMeshgrid()
    {
        float stepX = numX == 1 ? 0 : (maxX - minX) / (numX - 1);
        float stepY = numY == 1 ? 0 : (maxY - minY) / (numY - 1);
        float stepZ = numZ == 1 ? 0 : (maxZ - minZ) / (numZ - 1);

        List<Vector3> meshAsList = new List<Vector3>();

        for (int x = 0; x < numX; x++)
            for (int y = 0; y < numY; y++)
                for (int z = 0; z < numZ; z++)
                    meshAsList.Add(new Vector3(minX + x * stepX, minY + y * stepY, minZ + z * stepZ));

        mesh = meshAsList.ToArray();
    }

    public int getSize()
    {
        return mesh.Length;
    }

    public Vector3 getPoint(int index)
    {
        return mesh[index];
    }
}