using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class GameManeger : MonoBehaviour
{
    //カードの配列
    public GameObject[] blackPlayingCards;
    //ターンの処理の定義
    enum Turn
    {
        player,Enemy1,Enemy2,Enemy3
    }
    List<string> playerCards = new List<string>();
    List<string> EnemyCards1 = new List<string>();
    List<string> EnemyCards2 = new List<string>();
    List<string> EnemyCards3 = new List<string>();
    //シャッフルの定義
    void Shuffle<T>(T[] blackPlayingCards)
    {
        Random ram = new Random();

        // フィッシャー–イェーツシャッフルアルゴリズムを使用して配列をシャッフル
        for (int i = blackPlayingCards.Length - 1; i > 0; i--)
        {
            int j = ram.Next(i + 1);
            T temp = blackPlayingCards[i];
            blackPlayingCards[i] = blackPlayingCards[j];
            blackPlayingCards[j] = temp;
        }
    }


    void Start()
    {
        //カードの配列にカードを入れる
        //for (int i = 1; i <= 13; i++)
        //{
        //    blackPlayingCards[i - 1] = (GameObject)Resources.Load("Black_PlayingCards_Club" + i.ToString("00"));
        //}
        //for (int i = 1; i <= 13; i++)
        //{
        //    blackPlayingCards[i + 12] = (GameObject)Resources.Load("Black_PlayingCards_Diamond" + i.ToString("00"));
        //}
        //for (int i = 1; i <= 13; i++)
        //{
        //    blackPlayingCards[i + 25] = (GameObject)Resources.Load("Black_PlayingCards_Heart" + i.ToString("00"));
        //}
        //for (int i = 1; i <= 13; i++)
        //{
        //    blackPlayingCards[i + 38] = (GameObject)Resources.Load("Black_PlayingCards_Spade" + i.ToString("00"));
        //}
        //ここで配列をシャッフルする
        Shuffle(blackPlayingCards);
        int ofsetPlayer = 22;
        int ofsetEnemy = 18;
        //ここでシャッフルした配列の最初から５枚ずつカードを生成
        for (int y = 0; y < 20; y++)
        {
            if (0 <= y && y <= 4)
            {
                Instantiate(blackPlayingCards[y], new Vector3(-50 + y * ofsetPlayer, 14, 60), Quaternion.Euler(50, 0, 0));
                playerCards.Add
            }
            if (5 <= y && y <= 9)
            {
                Instantiate(blackPlayingCards[y], new Vector3(58, 14, 40 + y * ofsetEnemy * -1), Quaternion.Euler(90, 90, -20));
                EnemyCards1.Add
            }
            if (10 <= y && y <= 14)
            {
                Instantiate(blackPlayingCards[y], new Vector3(36 + y * ofsetEnemy * -1, 14, -40), Quaternion.Euler(-100, 0, 0));
                EnemyCards2.Add
            }
            if (15 <= y && y <= 19)
            {
                Instantiate(blackPlayingCards[y], new Vector3(-57, 14, -40 + y * ofsetEnemy), Quaternion.Euler(90, -90, 20));
                EnemyCards3.Add
            }
        }


    }
    void Update()
    {
        //手札の処理
        if (/*自分のターン*/)
        {
            if(/*press 選ぶボタン*/)
            {
                //カードを選んだ状態にする

                if(/*press 捨てるボタン*/)
                {
                    //選ばれたカードを捨てる
                }
            }
        }
        if(/*Enemy1 && Enemy2 && Enemy3 のターン*/)
        {
            //期待値が一番高いカードを選ぶ
            //カードを捨てる
        }


    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------


    //遺産

    // dictionaryを作成
    //Dictionary<string, GameObject> cardNameToObject = new Dictionary<string, GameObject>();

    //// スートの配列
    //string[] suits = { "Diamond", "Club", "Spade", "Heart" };
    //int numberOfCardsPerSuit = 13;

    //// 各スートに対して1から13までのカードを生成して辞書に追加
    //foreach (string suit in suits)
    //{
    //    // 1から13までのカードを作成
    //    for (int j = 1; j <= numberOfCardsPerSuit; j++)
    //    {
    //        // カード名を生成 (例: "Diamond01", "Diamond02", ... "Heart13")
    //        string cardName = suit+ j.ToString("00");

    //        // "Black_PlayingCards_" + カード名 + "_00" の名前のGameObjectを検索
    //        GameObject cardObject = GameObject.Find("Black_PlayingCards_" + cardName + "_00");

    //        // 辞書にカード名をキーとして、対応するGameObjectを追加
    //        cardNameToObject.Add(cardName, cardObject);
    //    }
    //}
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
    //HashSet<string> pickedCard = new HashSet<string>();

    //int count = 0;
    //while (count < numberOfPrefabs)
    //{
    //    int randomCardSutoNumber = UnityEngine.Random.Range(0, 4);
    //    int randomCardNumber = UnityEngine.Random.Range(0, 13);
    //    string card = suto[randomCardSutoNumber] + cardNumber[randomCardNumber];

    //    if (!pickedCard.Contains(card))
    //    {
    //        pickedCard.Add(card);
    //        count++;
    //        Debug.Log(card);
    //    }
    //}


    //basePosition = originalPosition + originePositionChange;
    //Debug.Log(pickedCard.Count);

    //perfectPositionを操作が終わった後に初期化する

    //選んだカードのリストをgameObjectのリストに変換
    //gameObjectのリストのカードを並べる
    //Instantiate(prefabToSpawn, transform.position, transform.rotation);
    //GameObject card01 = cardNameToObject["Club01"];
    //Vector3 newScale = new Vector3(2.0f, 2.0f, 2.0f);
    //Vector3 newScale = new Vector3(2.0f, 2.0f, 2.0f);

    //foreach (string inDictionary in pickedCard)
    //{
    //    Vector3 position = basePosition;
    //    basePosition = basePosition + offset;
    //    Instantiate(cardNameToObject[inDictionary], position, transform.rotation);
    //}

}