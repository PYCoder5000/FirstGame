using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpwaner : MonoBehaviour
{
    public GameObject cube;
    public GameObject objectParents;
    GameObject spawnObject;
    new Camera camera;
    private void Start()
    {
        spawnObject = cube;
        camera = Camera.main;
    }
    Vector3 flatVector(Vector3 vect)
    {
        return new Vector3(vect.x, vect.y, 0);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject obj = Instantiate(spawnObject, objectParents.transform);
            obj.transform.position = flatVector(camera.ScreenToWorldPoint(Input.mousePosition));
            obj.SetActive(true);
        }
    }
    public void SetSawnItem(GameObject obj)
    {
        spawnObject = obj;
    }
}
