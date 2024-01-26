using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System;
using Random = System.Random;


public class GameManeger : MonoBehaviour
{
    //カードの配列
    public GameObject[] blackPlayingCards;
    List<GameObject> instantiatedCards = new List<GameObject>();

    //ターンの処理の定義
    List<string> playerCards = new List<string>();
    List<string> EnemyCards1 = new List<string>();
    List<string> EnemyCards2 = new List<string>();
    List<string> EnemyCards3 = new List<string>();

    List<int> ChoseCard = new List<int>();
    int t = 0;
    int lapsTurn = 0;

    //シャッフルの定義

    void Shuffle<S>(S[] blackPlayingCards)
    {
        Random ram = new Random();

        // フィッシャー–イェーツシャッフルアルゴリズムを使用して配列をシャッフル
        for (int i = blackPlayingCards.Length - 1; i > 0; i--)
        {
            int j = ram.Next(i + 1);
            S temp = blackPlayingCards[i];
            blackPlayingCards[i] = blackPlayingCards[j];
            blackPlayingCards[j] = temp;
        }
    }
    static Dictionary<int, int> GetDuplicatesAndCount(int[] array)
    {
        var ParseCardNumdict = new Dictionary<int, int>();

        foreach (int num in array)
        {
            if (ParseCardNumdict.ContainsKey(num))
            {
                ParseCardNumdict[num]++;
            }
            else
            {
                ParseCardNumdict[num] = 1;
            }
        }

        return ParseCardNumdict.Where(pair => pair.Value >= 2).ToDictionary(pair => pair.Key, pair => pair.Value);
    }




    void Start()
    {
        //ここで配列をシャッフルする
        Shuffle(blackPlayingCards);
        int ofsetPlayer = 22;
        int ofsetEnemy = 18;
        //ここでシャッフルした配列の最初から５枚ずつカードを生成

        // kimoi
        for (int y = 0; y < 20; y++)
        {
            if (0 <= y && y <= 4)
            {
                instantiatedCards.Add(Instantiate(blackPlayingCards[y], new Vector3(-50 + y * ofsetPlayer, 14, 60), Quaternion.Euler(50, 0, 0)));
                playerCards.Add(blackPlayingCards[y].name);
            }
            if (5 <= y && y <= 9)
            {
                instantiatedCards.Add(Instantiate(blackPlayingCards[y], new Vector3(58, 14, 40 + y * ofsetEnemy * -1), Quaternion.Euler(90, 90, -20)));
            }
            if (10 <= y && y <= 14)
            {
                instantiatedCards.Add(Instantiate(blackPlayingCards[y], new Vector3(36 + y * ofsetEnemy * -1, 14, -40), Quaternion.Euler(-100, 0, 0)));
                EnemyCards2.Add(blackPlayingCards[y].name);
            }
            if (15 <= y && y <= 19)
            {
                instantiatedCards.Add(Instantiate(blackPlayingCards[y], new Vector3(-57, 14, -40 + y * ofsetEnemy), Quaternion.Euler(90, -90, 20)));
                EnemyCards3.Add(blackPlayingCards[y].name);
            }

        }

        // kimoi owari

        for (int i = 0; i <= 4; i++)
        {
            Debug.Log(playerCards[i]);
        }
        //手札の処理
    }

    void FixedUpdate()
    {
        int ofsetPlayer2nd = 22;
        //Debug.Log("Update");


        if (lapsTurn == 2 && Input.GetKeyUp(KeyCode.T))
        {
            //役判定
            // プレイヤーの役判定
            ParseCardName(playerCards[0])
            List<string> suit = new List<string> ();
            // suitの配列にParseCardNameで取ってきたsuitを代入する

            // ロイヤルフラッシュ
            // TODO: SuitとNumberの配列を作る
            // if(suit[0] = [4])
            // {
            //     if(number[0]= 1)
            //     {

            //     }
            //     else
            //     {
            //     Debug.Log("Flush");
            //     }
            }
            
        }
            // COMの約判定

        }

        if (t == 0)
        {            //tが０の時に１、２、３、４、５の数字をおしてカードを選んでfを押して選ばれているカードを全て捨てる。

            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                Debug.Log("1 is pushed");
                //ChoseCardに数字の情報を入れて、Fを押した時にPlayerCardsの数字の情報番目を消す
                ChoseCard.Add(0);
            }
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                Debug.Log("2 is pushed");
                ChoseCard.Add(1);
            }
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                Debug.Log("3 is pushed");
                ChoseCard.Add(2);
            }
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                Debug.Log("4 is pushed");
                ChoseCard.Add(3);
            }
            if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                Debug.Log("5 is pushed");
                ChoseCard.Add(4);
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                // 配列を逆順にして後ろから削除：消す順番がズレるのを防ぐため
                ChoseCard = ChoseCard.Distinct().ToList();
                ChoseCard.Reverse();
                // ChoseCardの要素を使用してarrayから要素を削除
                for (int i = 0; i <= ChoseCard.Count - 1; i++)
                {
                    //注意！ChoseCardには押されたカードの情報しか入っていないよ！！
                    int index = ChoseCard[i];
                    // index out of range 対策
                    if (index >= 0 && index < playerCards.Count)
                    {
                        //Destroy(playerCards[index]);

                        //名前からゲームオブジェクトを指定して削除する
                        playerCards.RemoveAt(index);
                        playerCards.Add(blackPlayingCards[i + 20 + 5 * lapsTurn].name);
                        Destroy(instantiatedCards[index]);
                        //二週目以降にも対応
                        instantiatedCards[index] = Instantiate(blackPlayingCards[i + 20 + 5 * lapsTurn], new Vector3(-50 + index * ofsetPlayer2nd, 14, 60), Quaternion.Euler(50, 0, 0));
                        // instantiatedCards.Add(Instantiate(blackPlayingCards[index + 20 + 5 * lapsTurn], new Vector3(-50 + index -1 * ofsetPlayer2nd, 14, 60), Quaternion.Euler(50, 0, 0)));

                    }

                }
                t++;
                ChoseCard.Clear();
            }
        }

        if (t == 1)
        {
            Debug.Log("t: " + t);
            t++;
        }
        if (t == 2)
        {
            Debug.Log("t: " + t);
            t++;
        }
        if (t == 3)
        {
            Debug.Log("t: " + t);
            t = 0;
            lapsTurn++;
            Debug.Log(lapsTurn + "lap");


        }

    }


    public static void ParseCardName(string cardName, out int number, out string suit)
    {
        // 正規表現を使用して数字とスートを抽出
        Match match = Regex.Match(cardName, @"Black_PlayingCards_(\w+)(\d\d)_(\d+)$");
        if (match.Success && match.Groups.Count == 4)
        {
            // スートと数字を取得
            suit = match.Groups[1].Value;
            number = Convert.ToInt32(match.Groups[2].Value);
        }
        else
        {
            // マッチしない場合はデフォルト値を設定
            suit = "";
            number = -1;
            Debug.Log("Invalid card name format: " + cardName);
        }
        
    }


}
