using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManeger : MonoBehaviour
{
    public Vector3 offset = new Vector3(0f, 0f,-30f);
    public int numberOfPrefabs = 5;
    Vector3 originalPosition = new Vector3(0f, 0f, 0f);
    Vector3 originePositionChange = new Vector3(50, 0, 50);
    Vector3 basePosition;

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
    [Obsolete]
    void Start()
    {
        // make cards
        foreach (string s in suto)
        {
            foreach(string n in cardNumber)
            {
                cards.Add((s, n));
            }
        }

        // dictionaryを作成
        Dictionary<string, GameObject> cardNameToObject = new Dictionary<string, GameObject>();

        // スートの配列
        string[] suits = { "Diamond", "Club", "Spade", "Heart" };
        int numberOfCardsPerSuit = 13;

        // 各スートに対して1から13までのカードを生成して辞書に追加
        foreach (string suit in suits)
        {
            // 1から13までのカードを作成
            for (int j = 1; j <= numberOfCardsPerSuit; j++)
            {
                // カード名を生成 (例: "Diamond01", "Diamond02", ... "Heart13")
                string cardName = suit+ j.ToString("00");

                // "Black_PlayingCards_" + カード名 + "_00" の名前のGameObjectを検索
                GameObject cardObject = GameObject.Find("Black_PlayingCards_" + cardName + "_00");

                // 辞書にカード名をキーとして、対応するGameObjectを追加
                cardNameToObject.Add(cardName, cardObject);
            }
        }
        // make choosed cards List
        //List<string> pickedCard = new List<string>();
        // choose 5 card
        // for文で５回選ぶ
        //for (int i = 0; i < numberOfPrefabs; i++)
        //{
        //    int count = 0;
        //    do
        //    {
        //        // make picked card
        //        int randomCardSutoNumber = UnityEngine.Random.Range(0, 4);
        //        // choose the number
        //        int randomCardNumber = UnityEngine.Random.Range(0, 13);
        //        Debug.Log(suto[randomCardSutoNumber] + cardNumber[randomCardNumber]);
        //        // add picked card
        //        pickedCard.Add(suto[randomCardSutoNumber] + cardNumber[randomCardNumber]);

        //        // check duplicate
        //        bool duplicateFound = false;
        //        for (int e = 0; e < count; e++)
        //        {
        //            //if (pickedCard[e] == suto[randomCardSutoNumber] + cardNumber[randomCardNumber])
        //            if(string.Equals(pickedCard[e], suto[randomCardSutoNumber] + cardNumber[randomCardNumber]))
        //            {
        //                duplicateFound = true;
        //                pickedCard.RemoveAt(pickedCard.Count - 1);
        //                break;
        //            }
        //        }
        //        if (!duplicateFound)
        //        {
        //            pickedCard[count] = suto[randomCardSutoNumber] + cardNumber[randomCardNumber];
        //            count++;
        //        }
        //    } while (count < 1);
        //}
        HashSet<string> pickedCard = new HashSet<string>();

        int count = 0;
        while (count < numberOfPrefabs)
        {
            int randomCardSutoNumber = UnityEngine.Random.Range(0, 4);
            int randomCardNumber = UnityEngine.Random.Range(0, 13);
            string card = suto[randomCardSutoNumber] + cardNumber[randomCardNumber];

            if (!pickedCard.Contains(card))
            {
                pickedCard.Add(card);
                count++;
                Debug.Log(card);
            }
        }


        basePosition = originalPosition + originePositionChange;
        Debug.Log(pickedCard.Count);
        
        //perfectPositionを操作が終わった後に初期化する

        //選んだカードのリストをgameObjectのリストに変換
        //gameObjectのリストのカードを並べる
        //Instantiate(prefabToSpawn, transform.position, transform.rotation);
        //GameObject card01 = cardNameToObject["Club01"];
        //Vector3 newScale = new Vector3(2.0f, 2.0f, 2.0f);
        //Vector3 newScale = new Vector3(2.0f, 2.0f, 2.0f);

        foreach (string inDictionary in pickedCard)
        {
            Vector3 position = basePosition;
            basePosition = basePosition + offset;
            Instantiate(cardNameToObject[inDictionary], position, transform.rotation);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        



    }
}
