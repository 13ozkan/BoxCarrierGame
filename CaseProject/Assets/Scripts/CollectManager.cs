using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    public GameObject boxPrefab;
    public Transform collectPoint;

    int paperLimit = 10;

    private void OnEnable()
    {
        TriggerManager.OnBoxCollect += GetBox;
        TriggerManager.OnBoxGive += GiveBox;
    }
    private void OnDisable()
    {

        TriggerManager.OnBoxCollect -= GetBox;
        TriggerManager.OnBoxGive -= GiveBox;
    }
    void GetBox()
    {
        if (boxList.Count <= paperLimit)
        {
            GameObject temp = Instantiate(boxPrefab, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, 0.5f+((float)boxList.Count / 20), collectPoint.position.z);
            boxList.Add(temp);
            if (TriggerManager.boxManager != null)
            {
                TriggerManager.boxManager.RemoveLast();
            }
        }
    }
    void GiveBox()
    {
        if (boxList.Count > 0)
        {
            TriggerManager.workerManager.GetPaper();
            RemoveLast();
        }
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
