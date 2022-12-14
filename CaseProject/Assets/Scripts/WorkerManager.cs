using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    List<GameObject> moneyList = new List<GameObject>();
    public Transform boxPoint,moneyDropPoint;
    public GameObject boxPrefab,moneyPrefab;

    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }
    IEnumerator GenerateMoney()
    {
        while (true)
        {
            if (boxList.Count > 0)
            {
                GameObject temp = Instantiate(moneyPrefab);
                temp.transform.position = new Vector3(moneyDropPoint.position.x,((float)moneyList.Count / 10), moneyDropPoint.position.z);
                moneyList.Add(temp);
                RemoveLast();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void GetPaper()
    {
        GameObject temp = Instantiate(boxPrefab);
        temp.transform.position = new Vector3(boxPoint.position.x, 0.8f + ((float)boxList.Count / 20), boxPoint.position.z);
        boxList.Add(temp);
    }
    public void RemoveLast()
    {
        if (boxList.Count > 0)
        {
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        }
    }
}
