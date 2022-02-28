using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    public GameObject prefab;
    public Transform point;
    public float livinTime;

    public void Instantiate()
    {
        GameObject instantiateObject = Instantiate(prefab, point.position, Quaternion.identity)as GameObject;
        if (livinTime > 0f)
        {
            Destroy(instantiateObject, livinTime);
        }
    }

}
