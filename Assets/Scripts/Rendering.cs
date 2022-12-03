using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendering : MonoBehaviour
{
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        GameObject currentObject;

        Meshgrid mesh = new Meshgrid(7, 7, 1, -2, 2, -2, 2, 0, 0);
        EasyCircular2DField field = new EasyCircular2DField(mesh);

        Vector3 initiateVector = new Vector3(0, 1, 0);

        for (int i = 0; i < mesh.getSize(); i++)
        {
            Vector3 currentPosition = field.getPositionByIndex(i);
            Vector3 currentVector = field.getVectorByIndex(i);

            float scale = currentVector.magnitude;
            Vector3 rotationAxis = Vector3.Cross(initiateVector, currentVector);
            float rotationAngle = Mathf.Acos(Vector3.Dot(initiateVector, currentVector) / (Vector3.Magnitude(currentVector))) * 180/Mathf.PI    ;

            currentObject = Instantiate(arrow, currentPosition, Quaternion.AngleAxis(rotationAngle, rotationAxis));
            currentObject.transform.localScale = new Vector3(1, scale, 1);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
