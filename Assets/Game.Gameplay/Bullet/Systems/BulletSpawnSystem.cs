using Game.Gameplay.Bullet;
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
    public class BulletSpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld = null;
        private readonly BulletDefinition bulletDefinition = null;

        private readonly EcsFilter<PlayerComponent, PositionComponent> players = null;

        private float spawnTimer = 0;
        public void Run()
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
                return;
            }

            spawnTimer = bulletDefinition.delay;

            foreach (var i in players)
            {
                ref var position = ref players.Get2(i);
                Vector3 spawnPosition = position.position.position;
                GameObject newBullet = UnityEngine.Object.Instantiate(bulletDefinition.bulletPrefab, spawnPosition, Quaternion.identity);
                var startPosition = newBullet.transform.position;

#if DEBUG
                Debug.DrawLine(UnityEngine.Vector3.zero, startPosition, Color.red, 1);
#endif

                var bulletEntity = ecsWorld.NewEntity();
                bulletEntity
                    .Replace(new BulletComponent())
                    .Replace(new PositionComponent
                    {
                        position = newBullet.transform,
                    })
                    .Replace(new MovementComponent
                    {
                        desiredPosition = startPosition,
                        speed = bulletDefinition.bulletSpeed,
                    });
            }
        }

    }
}