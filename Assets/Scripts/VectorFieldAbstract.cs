using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

abstract class VectorFieldAbstract
{
    // <position, vector> of the final field
    protected Dictionary<Vector3, Vector3> vectorField = new Dictionary<Vector3, Vector3>();

    protected abstract Vector3 calculateVector(Vector3 point);

    protected void calculateField(Meshgrid mesh)
    {
        for (int i = 0; i < mesh.getSize(); i++)
            vectorField.Add(mesh.getPoint(i), calculateVector(mesh.getPoint(i)));
    }

    public Vector3 getPositionByIndex(int index)
    {
        return vectorField.Keys.ElementAt(index);
    }

    public Vector3 getVectorByIndex(int index)
    {
        return vectorField.Values.ElementAt(index);
    }
}