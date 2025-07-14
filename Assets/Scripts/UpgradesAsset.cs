using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD
{
    [CreateAssetMenu]
    public class UpgradesAsset : ScriptableObject
    {
        public Sprite sprite;

        public int[] costByLevel = { 3 };
    }
}
