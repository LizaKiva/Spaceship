using Game.Gameplay.Enemy;
using Game.Gameplay.Movement;
using Game.Gameplay.Player;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Game.Gameplay.Enemy {
    public class EnemySpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld = null;
        private readonly EnemyDefinition enemyDefinition = null;

        private float spawnTimer = 0;
        public void Run()
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
                return;
            }

            spawnTimer = enemyDefinition.delay;

            float spawnX = Random.Range(-8f, 8f); // Генерируем случайную позицию по оси X
            Vector3 spawnPosition = new Vector3(spawnX, 5.2f, 0f); // Позиция врага в верхней части экрана
            GameObject newEnemy = UnityEngine.Object.Instantiate(enemyDefinition.enemyPrefab, spawnPosition, Quaternion.identity);
            var startPosition = newEnemy.transform.position;

#if DEBUG
            Debug.DrawLine(UnityEngine.Vector3.zero, startPosition, Color.red, 1);
#endif

            var enemyEntity = ecsWorld.NewEntity();
            enemyEntity
                .Replace(new EnemyComponent
                {
                    spawnPosition = startPosition,
                })
                .Replace(new PositionComponent
                {
                    position = newEnemy.transform,
                })
                .Replace(new MovementComponent
                {
                    desiredPosition = startPosition,
                    speed = Random.Range(enemyDefinition.enemyMinSpeed, enemyDefinition.enemyMaxSpeed),
                });
        }

    }
}
