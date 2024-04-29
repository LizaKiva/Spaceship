using Game.Gameplay.Player;
using Game.Gameplay.Movement;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using Game.Gameplay.Enemy;

public class GameStartUp : MonoBehaviour
{
    private EcsWorld _ecsWorld;
    private EcsSystems _ecsSystem;

    public PlayerDefinition playerDefinition;
    public EnemyDefinition enemyDefinition;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _ecsSystem = new EcsSystems(_ecsWorld);


        _ecsSystem.Add(new PlayerInputSystem())
                    .Add(new PlayerInitSystem())
                    .Add(new MovementSystem())
                    .Add(new EnemySystem())
                    .Inject(playerDefinition)
                    .Inject(enemyDefinition)
                    //.Add(new CollisionSystem())
                    //.Add(new GameOverSystem());
                    .ProcessInjects();

        _ecsSystem.Init();
    }

    private void Update()
    {
        _ecsSystem?.Run();
        
    }

    private void OnDestroy()
    {
        _ecsSystem?.Destroy();
        _ecsWorld?.Destroy();
    }
}
