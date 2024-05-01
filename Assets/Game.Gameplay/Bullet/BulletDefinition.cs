using UnityEngine;

namespace Game.Gameplay.Bullet
{
    [CreateAssetMenu(menuName = "Spaceship/" + nameof(BulletDefinition))]
    public sealed class BulletDefinition : ScriptableObject
    {
        [Range(0, 10)] public float bulletSpeed;
        [Range(0, 10)] public float delay;
        public GameObject bulletPrefab;
    }
}
