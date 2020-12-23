using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberedBoxCreator : MonoBehaviour
{
    [SerializeField] Transform prefab;

    void Start()
    {
        ArrayList fibNums = new ArrayList{8, 13, 21};
        
        Transform newBox;
            int newRandomInt = Random.Range(1, 99);
            while (fibNums.Contains(newRandomInt))
            {
                newRandomInt = Random.Range(1, 99);
            }

            newBox = Instantiate(prefab, transform.position, Quaternion.identity);
            for (int j = 0; j < newBox.childCount; j++)
            {
                Transform temp = newBox.GetChild(j).GetChild(0);
                Text text = temp.GetComponent<Text>();
                text.text = newRandomInt + "";
            }
    }
}
