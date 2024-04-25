using Game.Gameplay.Movement;
using Game.Gameplay.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, PositionComponent, MovementComponent> players = null;

        public void Run()
        {
            foreach (var i in players)
            {
                var xAxis = Input.GetAxis("Horizontal");

                ref var position = ref players.Get2(i);
                ref var movement = ref players.Get3(i);
                movement.desiredPosition = position.position.position + new Vector3(xAxis, 0, 0); 
            }
        }
    }
}