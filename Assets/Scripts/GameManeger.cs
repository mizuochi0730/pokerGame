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
    List<string> playerCards = new List<string>();
    List<string> EnemyCards1 = new List<string>();
    List<string> EnemyCards2 = new List<string>();
    List<string> EnemyCards3 = new List<string>();
    int t = 0;

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
                Instantiate(blackPlayingCards[y], new Vector3(-50 + y * ofsetPlayer, 14, 60), Quaternion.Euler(50, 0, 0));
                playerCards.Add(blackPlayingCards[y].name);
            }
            if (5 <= y && y <= 9)
            {
                Instantiate(blackPlayingCards[y], new Vector3(58, 14, 40 + y * ofsetEnemy * -1), Quaternion.Euler(90, 90, -20));
                EnemyCards1.Add(blackPlayingCards[y].name);
            }
            if (10 <= y && y <= 14)
            {
                Instantiate(blackPlayingCards[y], new Vector3(36 + y * ofsetEnemy * -1, 14, -40), Quaternion.Euler(-100, 0, 0));
                EnemyCards2.Add(blackPlayingCards[y].name);
            }
            if (15 <= y && y <= 19)
            {
                Instantiate(blackPlayingCards[y], new Vector3(-57, 14, -40 + y * ofsetEnemy), Quaternion.Euler(90, -90, 20));
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
            //Debug.Log("Update");
            if (t == 0)
            {
            //tが０の時に１、２、３、４、５の数字をおしてカードを選んでfを押して選ばれているカードを全て捨てる。
            //
                //if (Keydown.D1)
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Debug.Log("Space is pushed");
                    t++;
                }
                //このボタンを押したらカードを選ばれた状態にする
                //blackPlayingCards[] = new ChoseCard;
                //カードを選んだ状態にする
                }
                //if (press  F )
                //{
                    //
                    //Destroy(ChoseCard, 0.5f);
                    //選ばれたカードを捨てる
                    //t++;
                //}
              
    
            if (t == 1)
            {
                //期待値が一番高くなるようにカードを選ぶ
                //カードを捨    て
                Debug.Log("t: "  + t);
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
                    
            }


        }


    }
