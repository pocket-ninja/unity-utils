using System.Collections.Generic;
using UnityEngine;
using System;

public static class CollectionExtensions {
    /// <summary>
    /// Returns random element from the array
    /// </summary>
    public static List<T> Adding<T>(this List<T> collection, T element) { 
        var result = new List<T>(collection);
        result.Add(element);
        return result;
    }

    /// <summary>
    /// Returns random element from the array
    /// </summary>
    public static T Random<T>(this T[] collection) { 
        return collection[UnityEngine.Random.Range(0, collection.Length)];
    }

    /// <summary>
    /// Returns random element from the list
    /// </summary>
    public static T Random<T>(this IList<T> collection) { 
        return collection[UnityEngine.Random.Range(0, collection.Count)];
    }
}