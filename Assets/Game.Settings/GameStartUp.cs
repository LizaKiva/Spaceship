using Game.Gameplay.Player;
using Game.Gameplay.Movement;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using Game.Gameplay.Enemy;
using Game.Settings.Destroy;
using Game.Gameplay.Bullet;
using Game.UI;

public class GameStartUp : MonoBehaviour
{
    private EcsWorld _ecsWorld;
    private EcsSystems _ecsSystem;

    public EndScreenComponent endScreenComponent;

    public PlayerDefinition playerDefinition;
    public BulletDefinition bulletDefinition;
    public EnemyDefinition enemyDefinition;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _ecsSystem = new EcsSystems(_ecsWorld);

        _ecsSystem.Add(new PlayerInputSystem())
                    .Add(new PlayerInitSystem())

                    .Add(new BulletSpawnSystem())
                    .Add(new BulletMovementSystem())
                    .Add(new BulletDestroySystem())

                    .Add(new EnemySpawnSystem())
                    .Add(new EnemyMovementSystem())
                    .Add(new EnemyDestroySystem())
                    .Add(new EnemyCollisionSystem())

                    .Add(new MovementSystem())
                    .Add(new DestroySystem())

                    .Add(new GameStateSystem())
                    .OneFrame<ToggleEndScreenRequest>()
                    //.Add(new CollisionSystem())
                    //.Add(new GameOverSystem());
                    .Inject(playerDefinition)
                    .Inject(bulletDefinition)
                    .Inject(enemyDefinition)
                    .ProcessInjects();

        _ecsWorld.NewEntity().Replace(endScreenComponent);
        _ecsWorld.NewEntity().Get<ToggleEndScreenRequest>().enable = false;

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
