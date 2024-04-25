using System;
using Game.Gameplay.Movement;
using Game.Gameplay.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld ecsWorld = null;
        private readonly PlayerDefinition playerDefinition = null;

        public void Init()
        {
            if (!playerDefinition) throw new Exception($"{nameof(PlayerDefinition)} doesn't exists!");

            var playerCount = 0;
            var playerObjects = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in playerObjects)
            {
                var startPosition = player.transform.position;

                var playerEntity = ecsWorld.NewEntity();
                playerEntity
                    .Replace(new PlayerComponent
                    {
                        lives = playerDefinition.startLives,
                        spawnPosition = startPosition,
                    })
                    .Replace(new PositionComponent
                    {
                        position = player.transform,
                    })
                    .Replace(new MovementComponent
                    {
                        desiredPosition = startPosition,
                        speed = playerDefinition.startSpeed,
                    });
            }
        }
    }
}