using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebug : MonoBehaviour
{
    public static TestDebug instance;

    [Space()]
    public GameObject Cube;
    public GameObject Sphere;
    List<GameObject> cubeList = new List<GameObject>();
    List<GameObject> sphereList = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public void DeleteAll()
    {
        DeleteAllBox();
        DeleteAllSphere();
    }

    public void DeleteAllBox()
    {
        for (int i = cubeList.Count - 1; i >= 0; i--)
        {
            Destroy(cubeList[i].gameObject);
            cubeList.Remove(cubeList[i]);
        }
    }

    public void DeleteAllSphere()
    {
        for (int i = sphereList.Count - 1; i >= 0; i--)
        {
            Destroy(sphereList[i].gameObject);
            sphereList.Remove(sphereList[i]);
        }
    }

    public void AddSphere()
    {
        GameObject gameObject = Instantiate(Sphere);
        sphereList.Add(gameObject);
    }

    public void AddSphere(int value)
    {
        for (int i = 0; i < value; i++)
        {
            GameObject gameObject = Instantiate(Sphere);
            sphereList.Add(gameObject);
        }
    }
    public void AddSphere(int value, Vector3 transform)
    {
        for (int i = 0; i < value; i++)
        {
            GameObject gameObject = Instantiate(Sphere);
            gameObject.transform.position = transform;
            sphereList.Add(gameObject);
        }
    }

    public void AddBox()
    {
        GameObject gameObject = Instantiate(Cube);
        cubeList.Add(gameObject);
    }

    public void AddBox(int value)
    {
        for (int i = 0; i < value; i++)
        {
            GameObject gameObject = Instantiate(Cube);
            cubeList.Add(gameObject);
        }
    }

    public void AddBox(int value, Vector3 transform)
    {
        for (int i = 0; i < value; i++)
        {
            GameObject gameObject = Instantiate(Cube);
            gameObject.transform.position = transform;
            cubeList.Add(gameObject);
        }
    }

    public void SetInt(int value)
    {
        Debug.Log("set " + value + " int");
    }
}
