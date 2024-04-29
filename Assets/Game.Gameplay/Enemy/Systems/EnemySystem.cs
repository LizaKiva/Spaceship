using Game.Gameplay.Enemy;
using Game.Gameplay.Movement;
using Game.Gameplay.Player;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Game.Gameplay.Enemy { 
    public class EnemySystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld = null;
        private readonly EnemyDefinition enemyDefinition = null;
        private readonly EcsFilter<EnemyComponent, PositionComponent, MovementComponent> enemyFiltered = null;
        public void Run()
        {
            var enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemyObjects)
            {
                var startPosition = enemy.transform.position;

                var enemyEntity = ecsWorld.NewEntity();
                enemyEntity
                    .Replace(new EnemyComponent
                    {
                        spawnPosition = startPosition,
                    })
                    .Replace(new PositionComponent
                    {
                        position = enemy.transform,
                    })
                    .Replace(new MovementComponent
                    {
                        desiredPosition = startPosition,
                        speed = enemyDefinition.enemySpeed,
                    });


                foreach (var i in enemyFiltered)
                {
                    ref var position = ref enemyFiltered.Get2(i);
                    ref var movement = ref enemyFiltered.Get3(i);
                    movement.desiredPosition = new UnityEngine.Vector3(enemy.transform.position.x, -5f, 0);
                }
            }
        }

    }
}