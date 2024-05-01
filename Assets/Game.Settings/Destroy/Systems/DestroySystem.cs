using Game.Gameplay.Movement;
using Leopotam.Ecs;

namespace Game.Settings.Destroy
{
    public class DestroySystem : IEcsRunSystem
    {
        private readonly EcsWorld ecsWorld = null;
        private readonly EcsFilter<PositionComponent, DeleteRequest> destroyObjects = null;
        public void Run()
        {
            foreach (var i in destroyObjects)
            {
                ref var position = ref destroyObjects.Get1(i);
                //position.position.gameObject.SetActive(false);
                UnityEngine.Object.Destroy(position.position.gameObject);

                var entity = destroyObjects.GetEntity(i);
                entity.Destroy();
            }
        }

    }
}
