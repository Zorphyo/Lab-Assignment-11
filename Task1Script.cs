using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class Task1Script : MonoBehaviour
{
    string[] firstNames = {"Alex", "Bailey", "Chris", "Delaney", "Evan", "Fiona", "Gary", "Heather", "Ike", "Jessica", "Kyle", "Leah", "Mark", "Nicole", "Omar", "Piper", "Quinn", "Ryan", "Sam", "Tyler", "Updog", "Vincent", "Wayne", "Xavier", "Yelan", "Zeke"};
    string[] lastNames = {"A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I.", "J.", "K.", "L.", "M.", "N.", "O.", "P.", "Q.", "R.", "S.", "T.", "U.", "V.", "W.", "X.", "Y.", "Z."};

    Queue<string> login = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        login.Enqueue("Ash H.");
        login.Enqueue("Nick K.");
        login.Enqueue("Mitch J.");
        login.Enqueue("Sid P.");
        login.Enqueue("Dana L.");

        Debug.Log("Initial login queue created. Currently there are " + login.Count + " players in the queue: Ash H., Nick K., Mitch J., Sid P., Dana L.");

        InvokeRepeating("LoginPlayer", 5.0f, 5.0f);
    }

    void LoginPlayer()
    {
        Debug.Log(login.Peek() + " is now inside the game.");
        login.Dequeue();

        Random random = new Random();
        int firstName = random.Next(0, 26);
        int lastName = random.Next(0, 26);

        string nextPlayer = firstNames[firstName] + " " + lastNames[lastName];
        Debug.Log(nextPlayer + " is trying to log in and has been added to the login queue.");
        login.Enqueue(nextPlayer);
    }
}
