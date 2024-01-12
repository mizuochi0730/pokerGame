using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("1を入力してEnterキーを押すと、2の二乗が計算されます。");

        // ユーザーの入力を受け付ける
        string userInput = Console.ReadLine();

        // 入力が "1" の場合に2の二乗を計算
        if (userInput == "1")
        {
            int result = Square(2);
            Console.WriteLine($"2の二乗は {result} です。");
        }
        else
        {
            Console.WriteLine("無効な入力です。");
        }

        Console.ReadLine(); // プログラムがすぐに終了しないようにEnterキー待ちを追加
    }

    // 数字を二乗するメソッド
    static int Square(int number)
    {
        return number * number;
    }
}