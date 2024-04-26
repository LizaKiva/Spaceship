using System;
using Game.Gameplay.Enemy;
using Game.Gameplay.Movement;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Ghosts
{
    public sealed class EnemySpawnSystem : IEcsRunSystem
    {
        private readonly System.Random random = null;
        private readonly EcsWorld ecsWorld = null;
        private readonly EnemyDefinition gameDefinitions = null;

        public void Run()
        {
            if (!gameDefinitions) throw new Exception($"{nameof(EnemyDefinition)} doesn't exists!");

            var enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemyObjects)
            {
                var ghostEntity = ecsWorld.NewEntity();
                ghostEntity
                    .Replace(new EnemyComponent
                    {
                        
                    })
                    .Replace(new MovementComponent
                    {
                        
                    })
                    .Replace(new PositionComponent { position = enemy.transform });
            }
        }
    }
}