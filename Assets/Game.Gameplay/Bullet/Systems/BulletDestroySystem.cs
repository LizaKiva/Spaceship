using Game.Settings.Destroy;
using Game.Gameplay.Movement;
using Leopotam.Ecs;
using Game.Gameplay.Bullet;

namespace Game.Gameplay.Enemy
{
    public class BulletDestroySystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld = null;
        private readonly EnemyDefinition enemyDefinition = null;
        private readonly EcsFilter<BulletComponent, PositionComponent> bulletFiltered = null;
        public void Run()
        {
            foreach (var i in bulletFiltered)
            {
                ref var position = ref bulletFiltered.Get2(i);
                if (position.position.position.y > 7f) // Пуля над экраном
                {
                    var bulletEntity = bulletFiltered.GetEntity(i);
                    bulletEntity.Replace(new DeleteRequest());
                }
            }
        }

    }
}
