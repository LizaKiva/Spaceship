using System;
using Game.Gameplay.Enemy;
using Game.Gameplay.Movement;
using Leopotam.Ecs;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Game.Gameplay.Enemy
{
    public sealed class EnemySpawnSystem : MonoBehaviour
    {
        public EnemyDefinition enemyDefinition;
        public EnemyComponent enemy;

        void Start()
        {
            InvokeRepeating("SpawnEnemy", 0, enemyDefinition.delay);
        }

        void SpawnEnemy()
        {
            float spawnX = Random.Range(-8f, 8f); // ���������� ��������� ������� �� ��� X
            Vector3 spawnPosition = new Vector3(spawnX, 5.2f, 0f); // ������� ����� � ������� ����� ������
            GameObject newEnemy = Instantiate(enemyDefinition.enemyPrefab, spawnPosition, Quaternion.identity);
            Destroy(newEnemy, 5f);
        }
    }
}