using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [CreateAssetMenu(menuName = "Spaceship/" + nameof(EnemyDefinition))]
    public sealed class EnemyDefinition : ScriptableObject
    {
        [Range(0, 10)] public float enemySize;
        [Range(0, 10)] public float enemyMinSpeed;
        [Range(0, 10)] public float enemyMaxSpeed;
        [Range(0, 10)] public float delay;
        public GameObject enemyPrefab;
    }
}