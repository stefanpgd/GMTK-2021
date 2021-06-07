using UnityEngine;
using System.Collections.Generic;

namespace SilverRogue.Tools
{
    public static class GetRandomItemsFromList
    {
        public static List<T> Get<T>(List<T> list, int number)
        {
            // List to remove picked items from
            List<T> temporaryList = new List<T>(list);

            // List to return
            List<T> newList = new List<T>();

            while(newList.Count < number && temporaryList.Count > 0)
            {
                int index = Random.Range(0, temporaryList.Count);
                newList.Add(temporaryList[index]);
                temporaryList.RemoveAt(index);
            }

            return newList;
        }
    }
}

