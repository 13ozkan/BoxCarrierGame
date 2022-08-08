using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    public GameObject boxPrefab;
    public Transform exitPoint;
    bool isWorking;
    int stackCount = 10;
    void Start()
    {
        StartCoroutine(PrintBox());
    }
    public void RemoveLast()
    {
        if (boxList.Count > 0)
        {
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        }
    }
    IEnumerator PrintBox()
    {
        while (true)
        {
            float boxCount = boxList.Count;
            int rowCount = (int)boxCount / stackCount;
            if (isWorking==true)
            {
                GameObject temp = Instantiate(boxPrefab);
                temp.transform.position = new Vector3(exitPoint.position.x+((float)rowCount/3), (boxCount%stackCount) / 20, exitPoint.position.z);
                boxList.Add(temp);
                if (boxList.Count >= 30)
                {
                    isWorking = false;
                }
            }
            else if(boxList.Count<30)
            {
                isWorking = true;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
