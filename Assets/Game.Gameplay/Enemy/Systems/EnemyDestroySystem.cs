using Game.Settings.Destroy;
using Game.Gameplay.Movement;
using Leopotam.Ecs;

namespace Game.Gameplay.Enemy
{
    public class EnemyDestroySystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld = null;
        private readonly EnemyDefinition enemyDefinition = null;
        private readonly EcsFilter<EnemyComponent, PositionComponent> enemyFiltered = null;
        public void Run()
        {
            foreach (var i in enemyFiltered)
            {
                ref var position = ref enemyFiltered.Get2(i);
                if (position.position.position.y < -7f) // Врага под экраном
                {
                    var enemyEntity = enemyFiltered.GetEntity(i);
                    enemyEntity.Replace(new DeleteRequest());
                }
            }
        }

    }
}
