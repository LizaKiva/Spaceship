using Game.Gameplay.Bullet;
using Game.Gameplay.Enemy;
using Game.Gameplay.Movement;
using Game.Gameplay.Player;
using Game.Settings.Destroy;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Game.Gameplay.Enemy
{
    public class EnemyCollisionSystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld = null;
        private readonly EnemyDefinition enemyDefinition = null;
        private readonly PlayerDefinition playerDefinition = null;

        private readonly EcsFilter<EnemyComponent, PositionComponent> enemyFiltered = null;
        private readonly EcsFilter<BulletComponent, PositionComponent> bulletFiltered = null;
        private readonly EcsFilter<PlayerComponent, PositionComponent> playerFiltered = null;
        public void Run()
        {
            foreach (var e in enemyFiltered)
            {
                var enemyPosition = enemyFiltered.Get2(e).position.position;
                var enemyEntity = enemyFiltered.GetEntity(e);

                foreach (var b in bulletFiltered)
                {
                    var bulletPosition = bulletFiltered.Get2(b).position.position;

                    if ((bulletPosition - enemyPosition).magnitude <= enemyDefinition.enemySize)
                    {
                        var bulletEntity = bulletFiltered.GetEntity(b);

                        bulletEntity.Replace(new DeleteRequest());
                        enemyEntity.Replace(new DeleteRequest());
                        break;
                    }
                }

                foreach (var p in playerFiltered)
                {
                    var playerPosition = playerFiltered.Get2(p).position.position;

                    if ((playerPosition - enemyPosition).magnitude <= enemyDefinition.enemySize + playerDefinition.playerSize)
                    {
                        var playerEntity = playerFiltered.GetEntity(p);

                        playerEntity.Replace(new DeleteRequest());
                        enemyEntity.Replace(new DeleteRequest());

                        ecsWorld.NewEntity().Get<ToggleEndScreenRequest>().enable = true;

                        break;
                    }
                }
            }
        }

    }
}
