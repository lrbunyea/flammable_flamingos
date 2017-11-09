using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static int whichTurn = 1;
    private int howManyActors;
    int[] speedList;

    void Start()
    {
        howManyActors = findActorNumber() + 1;
    }

    public int findActorNumber()
    {
        int tempCount;

        tempCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        return tempCount;
    }

    public void nextTurn()
    {
        if(whichTurn++ <= howManyActors)
        {
            whichTurn = whichTurn++;
        }
        else
        {
            whichTurn = 1;
        }
    }

    public void populateSpeedList()
    {

        GameObject[] tempObjList;
        GameObject player = GameObject.Find("Player");
        int i = 0;

        tempObjList = GameObject.FindGameObjectsWithTag("Enemy");
        tempObjList[tempObjList.Length] = player;

        foreach(GameObject obj in tempObjList)
        {
            SpeedStat speedStat = obj.GetComponent<SpeedStat>();
            
            speedList[i] = speedStat.speed;
            i++;

        }

        

        sortSpeedList(tempObjList);
    }

    public void sortSpeedList(GameObject [] tempObjList)
    {
        int[] tempSpeedList = speedList;
        int bestSpeed = tempSpeedList[0];
        int index = 0;
        GameObject fastest = tempObjList[0];
        GameObject[] sorted = new GameObject[tempObjList.Length];


        while (index < tempObjList.Length)
        {
            for (int i = 0; i < tempObjList.Length; i++)
            {
                for (int j = 0; j < sorted.Length; j++)
                {
                    if (tempSpeedList[i] < bestSpeed && tempObjList[i] != sorted[j])
                    {
                        bestSpeed = tempSpeedList[i];
                        fastest = tempObjList[i];
                    }
                }
            }

            sorted[index] = fastest;
            fastest.GetComponent<SpeedStat>().SetInitiative(index);
            index++;
        }
    }
}
