using System;
using Game.Gameplay.Enemy;
using Game.Gameplay.Movement;
using Leopotam.Ecs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Gameplay.Enemy
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

        private Vector3 GetRandomSpawnPosition()
        {
            // смотрим позицию камеры по х и у
            float cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
            float cameraHalfHeight = Camera.main.orthographicSize;

            float spawnX = Random.Range(-cameraHalfWidth, cameraHalfWidth);
            float spawnY = cameraHalfHeight;
            return new Vector3(spawnX, spawnY, 0f);
        }
    }
}