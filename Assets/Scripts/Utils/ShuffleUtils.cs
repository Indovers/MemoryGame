using UnityEngine;

public class ShuffleUtils
{
    public static void ShuffleArray<T>(ref T[] array)
    {
        for (var i = array.Length - 1; i > 0; i--)
        {
            var rnd = Random.Range(0, i);
            
            (array[i], array[rnd]) = (array[rnd], array[i]);
        }
    }

    public static void ShuffleTransforms(Transform parent)
    {
        foreach (Transform child in parent)
        {
            var rnd = Random.Range(0, parent.childCount);
            child.SetSiblingIndex(rnd);
        }
    }
}
