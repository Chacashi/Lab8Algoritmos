using Lab5Algoritmos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphMapController : MonoBehaviour
{
    
    [SerializeField] TextAsset GraphMap;
    [SerializeField] TextAsset ConnectionsMap;
    string[] arrayNodeConnectionsRows;
    string[] arrayNodeConnectionsColums;
     string[] arrayNodeRows;
     string[] arrayNodeColumns;
    [SerializeField] GameObject NodePrefab;
   DoubleCircleList<NodeControll> ListNodes = new DoubleCircleList<NodeControll>();
    [SerializeField] PlayerController player;

    //soy bajito
    private void Start()
    {
  
        OnDrawGraph();
        ConnectNodes();
        SetInitialNode();
    }
    void OnDrawGraph()
    {
        GameObject currentNode;
        arrayNodeRows = GraphMap.text.Split('\n');
        for (int i = 0; i < arrayNodeRows.Length; i++)
        {
            arrayNodeColumns = arrayNodeRows[i].Split(";");
            currentNode =  Instantiate(NodePrefab, new Vector2(float.Parse(arrayNodeColumns[0]), 
                float.Parse(arrayNodeColumns[1])), transform.rotation);
            currentNode.name = "NODE" + i.ToString();
            ListNodes.AddAtEnd(currentNode.GetComponent<NodeControll>());
        }
       
    }

    void ConnectNodes()
    {
        
        arrayNodeConnectionsRows = ConnectionsMap.text.Split("\n");
        for(int i = 0; i < ListNodes.GetCount(); i++)
        {
            arrayNodeConnectionsColums = arrayNodeConnectionsRows[i].Split(";");
            for(int j = 0; j < arrayNodeConnectionsColums.Length; j++)
            {
                ListNodes.GetValueAtPosition(i).AddAdjacentNode(ListNodes.GetValueAtPosition(int.Parse(arrayNodeConnectionsColums[j])));
            }
        }
    }
    void SetInitialNode()
    {
        int position = Random.Range(0, ListNodes.GetCount());
        player.SetNewPosition(ListNodes.GetValueAtPosition(0).gameObject.transform.position);
    }
}
