using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManeger : MonoBehaviour
{
    public GameObject Black_ManyDeck_00;

    List<string> suto = new List<string>
    {
        "Club",
        "Diamond",
        "Heart",
        "Spade"
    };
    List<string> cardNumber = new List<string>
    {
        "01","02","03","04","05","06","07","08","09","10","11","12","13"
    };

    List<(string suto, string number)> cards=new List<(string suto, string number)>();
    // Start is called before the first frame update
    void Start()
    {
        // make cards
        foreach(string s in suto)
        {
            foreach(string n in cardNumber)
            {
                cards.Add((s, n));
            }
        }
        // make number for Egara

        // make choosed cards List
        List<string> pickedCard = new List<string>();
        // choose 5 card
        // for文で５回選ぶ
        for (int i = 0; i < 5; i++)
        {
            int count = 0;
            do
            {
                // make picked card
                int randomCardSutoNumber = UnityEngine.Random.Range(0, 4);
                // choose the number
                int randomCardNumber = UnityEngine.Random.Range(0, 13);
                Debug.Log(suto[randomCardSutoNumber] + cardNumber[randomCardNumber]);
                // add picked card
                pickedCard.Add(suto[randomCardSutoNumber] + cardNumber[randomCardNumber]);
                // check duplicate
                bool duplicateFound = false;
                for (int e = 0; e < count; e++)
                {
                    if (pickedCard[e] == suto[randomCardSutoNumber] + cardNumber[randomCardNumber])
                    {
                        duplicateFound = true;
                        break;
                    }
                }
                if (!duplicateFound)
                {
                    pickedCard[count] = suto[randomCardSutoNumber] + cardNumber[randomCardNumber];
                    count++;
                }
            } while (count < pickedCard.Count);
            // remake card



        }

        Vector3 spawnPosition = new Vector3(-40f, 0f, 0f);
        Quaternion spawnRotation = Quaternion.identity;

        // プレハブを配置
        //GameObject spawnedPrefab = Instantiate(Black_ManyDeck_00, spawnPosition, spawnRotation);
        //pickRadom

    }

    // Update is called once per frame
    void Update()
    {
      
    }

}
