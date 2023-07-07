using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FootPrintSystem : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> FootprintPull = new(10);
    [HideInInspector]
    public float FootprintSide;

    private void Start()
    {
        for (int i = 0; i < FootprintPull.Capacity; i++)
        {
            FootprintPull.Add(Instantiate(Resources.Load<GameObject>("Prefabs/Footprint")));
        }
        FootprintSide = -0.4f;
    }
    public void StartShowing()
    {
        StartCoroutine(Show());
    }

    public void StopShowing()
    {
        StopAllCoroutines();
    }
    IEnumerator Show()
    {
        int firstActiveStepID = 0;
        while (true)
        {
            bool footprint = false;
            for (int i = 0; i < FootprintPull.Capacity; i++)
            {
                if (!FootprintPull[i].activeInHierarchy)
                {
                    FootprintPull[i].SetActive(true);
                    FootprintPull[i].transform.position = new Vector3(transform.position.x + FootprintSide, transform.position.y, transform.position.z);
                    FootprintPull[i].transform.rotation = transform.parent.rotation;
                    FootprintSide *= -1;
                    footprint = true;
                    break;
                }
            }
            if (!footprint)
            {
                FootprintPull[firstActiveStepID].transform.position = new Vector3(transform.position.x + FootprintSide, transform.position.y, transform.position.z);
                FootprintPull[firstActiveStepID].transform.rotation = transform.parent.rotation;
                firstActiveStepID++;
                if (firstActiveStepID >= FootprintPull.Capacity) firstActiveStepID = 0;
                FootprintSide *= -1;
            }
            yield return new WaitForSeconds(0.4f);
        }
    }
}
