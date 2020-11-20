using System;
using Classes.Enums;
using UnityEngine;

namespace Classes
{
    [Serializable]
    public class Plant
    {
        public float growTime;
        public float currentGrowTime;

        public bool isGrown;

        public ToolType gatheringTool;
        
        [HideInInspector]
        public Sprite grownSprite;
        public Sprite growingSprite;
    }
}