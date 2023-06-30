using System.Collections.Generic;

public static class ListExtention
{
    public static T PickRandom<T>(this IList<T> source)
    {
        var rnd = new System.Random();
        int randIndex = rnd.Next(source.Count);
        return source[randIndex];
    }
}

//class Program

//    static List<T> SelectRandomElements<T>(List<T> list, int count)
//    {
//        Random random = new Random();
//        List<T> randomElements = new List<T>();

//        // 要素数がcount未満の場合、すべての要素を選択する
//        count = Math.Min(count, list.Count);

//        while (randomElements.Count < count)
//        {
//            int randomIndex = random.Next(list.Count);

//            // 重複した要素を避けるために既に選択された要素をチェックする
//            if (!randomElements.Contains(list[randomIndex]))
//            {
//                randomElements.Add(list[randomIndex]);
//            }
//        }

//        return randomElements;
//    }
//}