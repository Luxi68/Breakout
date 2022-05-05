using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class GameScores
{
    public int highScore { get; private set; }

    public GameScores()
    {
        this.highScore = 0;
    }

    public bool newHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            return true;
        }

        return false;
    }
}

// [Serializable]
// public class SaveData
// {
//     private static int DEFAULT_NO_SCORES_SAVED = 5;
//     public SortedList<int, string> highScoreData = new SortedList<int, string>(DEFAULT_NO_SCORES_SAVED);

//     public bool isHighScore(int score, string name)
//     {
//         IList<int> sortedScores = highScoreData.Keys;

//         for (int i = DEFAULT_NO_SCORES_SAVED - 1; i >= 0; i--)
//         {
//             if(score > sortedScores[i])
//             {
//                 highScoreData.RemoveAt(0);
//                 highScoreData.Add(score, name);

//                 return true;
//             }
//         }

//         return false;
//     }
// }

// public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
// {
//     #region IComparer<TKey> Members

//     public int Compare(TKey x, TKey y)
//     {
//         int result = y.CompareTo(x);

//         if (result == 0)
//             return 1;   // Handle equality as beeing greater
//         else
//             return result;
//     }

//     #endregion
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         SortedList<int, int> descSortedList = new SortedList<int, int>(new DuplicateKeyComparer<int>());
//         descSortedList.Add(1, 1);
//         descSortedList.Add(4, 4);
//         descSortedList.Add(3, 3);
//         descSortedList.Add(2, 2);

//         for (int i = 0; i < descSortedList.Count; i++)
//         {
//             Console.WriteLine("key: {0}, value: {1}", descSortedList.Keys[i], descSortedList.Values[i]);
//         }
//     }
// }