using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalsConsoleApp
{
    public delegate void CarEventHander<T>(ICar<T> car, bool engineStarted) where T : class, new();

    public interface ICar<PassengerType> where PassengerType : class, new()
    {
        void StartEngine();
        void Accelearate(int amount);
        void Brake(int amount);

        int CurrentSpeed { get; }
        bool IsStopped { get; }
        bool IsEngineStarted { get; }
        int NumberOfGears { get; }

        PassengerType this[int passengerNameIndex] { get;set; }

        event CarEventHander<PassengerType> OnEngineStart;
    }
}
