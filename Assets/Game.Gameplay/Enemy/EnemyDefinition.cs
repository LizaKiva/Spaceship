using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [CreateAssetMenu(menuName = "Spaceship/" + nameof(EnemyDefinition))]
    public sealed class EnemyDefinition : ScriptableObject
    {
        [Range(0, 10)] public float enemySpeed;
        [Range(0, 10)] public float delay;
        public GameObject enemyPrefab;
    }
}