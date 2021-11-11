using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public int columnSize, rowSize;
    public float xSpace, zSpace;

    public GameObject grassPrefab;
    public GameObject[] currentGrid;

    public bool gotGrid;

    public GameObject fieldPrefab;

    public bool createFields;

    private GameObject hitted;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        for (int row = 0; row < rowSize; row++)
        {
            for (int column = 0; column < columnSize; column++)
            {
                Instantiate(grassPrefab, new Vector3(xSpace * (1 + column), 0, zSpace * (1 + row)), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gotGrid == false)
        {
            currentGrid = GameObject.FindGameObjectsWithTag("grid");

            gotGrid = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (createFields)
                {
                    if (hit.transform.tag == "grid")
                    {
                        hitted = hit.transform.gameObject;
                        Instantiate(fieldPrefab, hitted.transform.position, hitted.transform.rotation);

                        Destroy(hitted);
                    }
                }
            }
        }
    }

    public void CreateFields()
    {
        createFields = true;
    }

    public void ReturnToNormality()
    {
        createFields = false;
    }
}
