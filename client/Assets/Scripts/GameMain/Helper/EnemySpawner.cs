using UnityEngine;
using GameUtils;
using UnityGameFramework.Runtime;

namespace p1
{
    public class EnemySpawner : GlobalSingleton<EnemySpawner>
    {
        [SerializeField]
        public int MaxEnemyCount = 100;

        private int _curEnemyCount => GameEntry.GetComponent<EntityComponent>()
            .GetEntityGroup(GameConst.EntityGroup[EnumEntityGroup.Enemy]).EntityCount;

        private GameTimer _enemySpawnTimer = new GameTimer(0.5f);
        private Transform _enemySpawner;
        private Transform _minSpawnPoint;
        private Transform _maxSpawnPoint;
        private float _maxDistance;

        public float MaxDistance
        {
            get => _maxDistance;
            private set => _maxDistance = value;
        }

        public void Init()
        {
            _enemySpawner = transform;
            _minSpawnPoint = _enemySpawner.Find("MinSpawnPoint");
            _maxSpawnPoint = _enemySpawner.Find("MaxSpawnPoint");
            _maxDistance = Vector3.Distance(_maxSpawnPoint.position, Vector3.zero) + 4f;
        }

        public void UpdateSpawner(float delta)
        {
            if (_curEnemyCount >= MaxEnemyCount) return;
            transform.position = GameEntry.GetComponent<EntityComponent>().GetEntity(1).transform.position;
            _enemySpawnTimer.UpdateAsFinish(delta, EnemySpawn);
        }

        private void EnemySpawn()
        {
            int id = IdGenerator.Instance.GetNextID();
            var entityComponent = GameEntry.GetComponent<EntityComponent>();
            entityComponent.ShowEntity<EntityEnemy>(id,
                GameConst.EntityPath[EnumEntity.Enemy1],
                "EnemyGroup",
                userData: new EntityDataEnemy(GetRandomSpawnPoint()));
            _enemySpawnTimer.Reset();
        }

        private Vector3 GetRandomSpawnPoint()
        {
            Vector3 spawnPoint = Vector3.zero;

            bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;
            if (spawnVerticalEdge)
            {
                spawnPoint.y = Random.Range(_minSpawnPoint.position.y, _maxSpawnPoint.position.y);
                spawnPoint.x = Random.Range(0f, 1f) > 0.5f ? _minSpawnPoint.position.x : _maxSpawnPoint.position.x;
            }
            else
            {
                spawnPoint.x = Random.Range(_minSpawnPoint.position.x, _maxSpawnPoint.position.x);
                spawnPoint.y = Random.Range(0f, 1f) > 0.5f ? _minSpawnPoint.position.y : _maxSpawnPoint.position.y;
            }

            return spawnPoint;
        }
    }
}