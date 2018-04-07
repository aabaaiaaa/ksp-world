using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalsConsoleApp
{
    public abstract class BaseCar<T> : ICar<T> where T : class, new()
    {
        public BaseCar(int numberOfGears)
        {
            _numberOfGears = numberOfGears;
        }

        private T[] _passengersOnBoard = new T[] { };

        public T this[int passengerNameIndex] { get => _passengersOnBoard[passengerNameIndex]; set => _passengersOnBoard[passengerNameIndex] = value; }

        private int _currentSpeed = 0;

        public int CurrentSpeed => _currentSpeed;

        public bool IsStopped => _currentSpeed == 0;

        private bool _isEngineStarted = false;

        public event CarEventHander<T> OnEngineStart;

        public bool IsEngineStarted => _isEngineStarted;

        readonly private int _numberOfGears;

        public int NumberOfGears => _numberOfGears;

        public void Accelearate(int amount)
        {
            _currentSpeed += amount;
        }

        public void Brake(int amount)
        {
            _currentSpeed -= amount;
        }

        public void StartEngine()
        {
            _isEngineStarted = true;
            OnEngineStart?.Invoke(this, _isEngineStarted);
        }
    }
}
