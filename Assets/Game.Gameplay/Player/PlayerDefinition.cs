using UnityEngine;

namespace Game.Gameplay.Player
{
    [CreateAssetMenu(menuName = "Spaceship/" + nameof(PlayerDefinition))]
    public sealed class PlayerDefinition : ScriptableObject
    {
        [Range(0, 10)] public float startSpeed;
        [Range(0, 10)] public int startLives;
    }
}