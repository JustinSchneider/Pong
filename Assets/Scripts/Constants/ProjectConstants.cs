using System.Collections.Generic;
using UnityEngine;

namespace Constants
{
    public static class ProjectConstants
    {
        // Asset paths
        public static readonly string Player1Asset = "Assets/Prefabs/Gameplay/Player1.prefab";
        public static readonly string Player2Asset = "Assets/Prefabs/Gameplay/Player2.prefab";
        public static readonly string BallAsset = "Assets/Prefabs/Gameplay/Ball.prefab";
        
        // Player movement
        public static readonly float PlayerMoveSpeed = 50f;

        // Ball
        public static readonly float BallMoveSpeed = 200f;
        
        // Game Settings
        public static readonly int ScoreToWin = 5;
    }
}