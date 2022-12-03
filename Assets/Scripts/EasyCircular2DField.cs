using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EasyCircular2DField : VectorFieldAbstract
{
    public EasyCircular2DField(Meshgrid mesh)
    {
        calculateField(mesh);
    }

    protected override Vector3 calculateVector(Vector3 point)
    {
        return new Vector3(-point.y, point.x, 0);
    }
}
