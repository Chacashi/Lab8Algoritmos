using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphMapController : MonoBehaviour
{
    [SerializeField] TextAsset GraphMap;
     string[] arrayNodeRows;
     string[] arrayNodeColumns;
    [SerializeField] GameObject NodePrefab;


    private void Start()
    {
        OnDrawGraph();
    }
    void OnDrawGraph()
    {
        GameObject currentNode;
        arrayNodeRows = GraphMap.text.Split('\n');
        for (int i = 0; i < arrayNodeRows.Length; i++)
        {
            arrayNodeColumns = arrayNodeRows[i].Split(";");
             Instantiate(NodePrefab, new Vector2(float.Parse(arrayNodeColumns[0]), 
                float.Parse(arrayNodeColumns[1])), transform.rotation);
        }
    }

}
