using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Movement
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private const float epsilon = 0.1f;

        private readonly EcsFilter<PositionComponent, MovementComponent> moveEntities = null;

        public void Run()
        {
            foreach (var i in moveEntities)
            {
                var movingEntity = moveEntities.GetEntity(i);
                ref var moveComponent = ref moveEntities.Get2(i);
                var transform = moveEntities.Get1(i).position;

                var curPosition = transform.position;
                var desiredPosition = moveComponent.desiredPosition;
                var estimatedVector = desiredPosition - curPosition;

#if DEBUG
                Debug.DrawLine(curPosition, desiredPosition, Color.yellow, 1);
#endif

                if (estimatedVector.magnitude > epsilon)
                {
                    transform.position = Vector3.Lerp(transform.position, desiredPosition,
                                                      moveComponent.speed / estimatedVector.magnitude * Time.deltaTime);
                    continue;
                }
            }
        }
    }
}