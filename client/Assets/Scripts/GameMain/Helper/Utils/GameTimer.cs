using System;
using GameFramework;

namespace GameUtils
{
#if NOT_UNITY
    public static class Time
    {
        public static long FrameEndTime;
        public static long FrameTime;
        public static float deltaTime { get; set; } = FrameTime / 1000f;
    }
#endif
    public class GameTimer : IReference
    {
        private float _maxTime;
        private float _time;
        private Action _onFinish;
        private bool _canRun = false;
        public bool IsFinished => _time >= _maxTime;
        public bool IsRunning => _time < _maxTime;
        public bool CanRun
        {
            get => _canRun;
            set => _canRun = value;
        }
        public float Time => _time;

        public float MaxTime
        {
            get => _maxTime;
            set => _maxTime = value;
        }

        public static GameTimer Create(float maxTime, bool canRun = true)
        {
            GameTimer timer = ReferencePool.Acquire<GameTimer>();
            timer.MaxTime = maxTime;
            timer.CanRun = canRun;
            return timer;
        }
        public GameTimer()
        {
            _maxTime = 0f;
            _time = 0f;
            _canRun = true;
        }
        public GameTimer(float maxTime, bool canRun = true)
        {
            if (maxTime <= 0)
            {
                throw new Exception($"_maxTime can not be 0 or negative");
            }
            _maxTime = maxTime;
            _time = 0f;
            _canRun = canRun;
        }

        public void Reset()
        {
            _time = 0f;
        }

        public GameTimer UpdateAsFinish(float delta, Action onFinish)
        {
            if (!_canRun)
            {
                return this;
            }
            if (!IsFinished)
            {
                _time += delta;
                if (onFinish != _onFinish)
                {
                    _onFinish = onFinish;
                }
                if (IsFinished)
                {
                    _onFinish?.Invoke();
                }
            }
            return this;
        }

        public GameTimer UpdateAsFinish(float delta)
        {
            if (!_canRun)
            {
                return this;
            }
            if (!IsFinished)
            {
                _time += delta;
                if (IsFinished)
                {
                    _onFinish?.Invoke();
                }
            }
            return this;
        }

        public void UpdateAsRepeat(float delta, Action onRepeat = null)
        {
            if (delta > _maxTime)
            {
                throw new Exception($"_maxTime too small, delta:{delta} > _maxTime:{_maxTime}");
            }
            _time += delta;
            if (onRepeat != null && onRepeat != _onFinish)
            {
                _onFinish = onRepeat;
            }
            while (_time >= _maxTime)
            {
                _time -= _maxTime;
                _onFinish?.Invoke();
            }
        }

        public void OnFinish(Action onFinish)
        {
            _onFinish = onFinish;
        }

        public void OnRepeat(Action onRepeat)
        {
            _onFinish = onRepeat;
        }

        public void Clear()
        {
            _maxTime = 0f;
            _time = 0f;
            _onFinish = null;
            _canRun = true;
        }
    }
}