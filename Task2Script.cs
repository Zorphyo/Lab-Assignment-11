using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Task2Script : MonoBehaviour
{
    string[] firstNames = {"Alex", "Bailey", "Chris", "Delaney", "Evan", "Fiona", "Gary", "Heather", "Ike", "Jessica", "Kyle", "Leah", "Mark", "Nicole", "Omar", "Piper", "Quinn", "Ryan", "Sam", "Tyler", "Updog", "Vincent", "Wayne", "Xavier", "Yelan", "Zeke"};
    List<string> duplicates = new List<string>();
    HashSet<string> noDuplicates = new HashSet<string>();

    // Start is called before the first frame update
    void Start()
    {
        string[] randomNames = new string[15];
        Random random = new Random();
        int num;

        for (int i = 0; i < randomNames.Length; i++)
        {
            num = random.Next(0, 26);
            randomNames[i] = firstNames[num];
        }

        Debug.Log("Created the name array: " + randomNames[0] + ", " + randomNames[1] + ", " + randomNames[2] + ", " + randomNames[3] + ", " + randomNames[4] + ", " + randomNames[5] + ", " + randomNames[6] + ", " + randomNames[7] 
        + ", " + randomNames[8] + ", " + randomNames[9] + ", " + randomNames[10] + ", " + randomNames[11] + ", " + randomNames[12] + ", " + randomNames[13] + ", " + randomNames[14] + ".");

        for (int i = 0; i < randomNames.Length; i++)
        {
            if (noDuplicates.Add(randomNames[i]) == false && duplicates.Contains(randomNames[i]) == false)
            {
                duplicates.Add(randomNames[i]);
                Debug.Log("The array has the duplicate name: " + randomNames[i] + ".");
            }
        }
    }
}
