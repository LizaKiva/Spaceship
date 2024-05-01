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

namespace Game.Gameplay.Bullet
{
    public class BulletMovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld = null;
        private readonly EnemyDefinition enemyDefinition = null;
        private readonly EcsFilter<BulletComponent, PositionComponent, MovementComponent> bulletFiltered = null;
        public void Run()
        {
            foreach (var i in bulletFiltered)
            {
                ref var position = ref bulletFiltered.Get2(i);
                ref var movement = ref bulletFiltered.Get3(i);
                movement.desiredPosition = new UnityEngine.Vector3(position.position.position.x, position.position.position.y + 1f, 0);
            }
        }
    }
}
