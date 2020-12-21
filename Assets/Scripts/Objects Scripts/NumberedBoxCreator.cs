using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberedBoxCreator : MonoBehaviour
{
    [SerializeField] Transform prefab;
    Random rand;

    void Start()
    {
        ArrayList fibNums = new ArrayList{ 8, 13, 21, 34, 55 };
        
        Transform newBox;
        for (int i = 0; i < 10; i++)
        {
            int newRandomInt = Random.Range(1, 99);
            while (fibNums.Contains(newRandomInt))
            {
                newRandomInt = Random.Range(1, 99);
            }

            newBox = Instantiate(prefab, new Vector3(8.5f, 4.5f, 13.5f), Quaternion.identity);
            for (int j = 0; j < newBox.childCount; j++)
            {
                Transform temp = newBox.GetChild(j).GetChild(0);
                Text text = temp.GetComponent<Text>();
                text.text = newRandomInt + "";
            }
        }
    }
}
