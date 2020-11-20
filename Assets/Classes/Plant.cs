using System;
using UnityEngine;

namespace Classes
{
    [Serializable]
    public class Plant
    {
        public float growTime;
        public float currentGrowTime;

        public bool isGrown;
        
        [HideInInspector]
        public Sprite grownSprite;
        public Sprite growingSprite;
    }
}