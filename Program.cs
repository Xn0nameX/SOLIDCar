using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tryOOPSomeShit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO:
            //Длина пути генерируется случаяно и пользователь не знает её длину до самого конца
            //Максимальная вместимость бака равна 20
            //пользователю предложат сделать пит стоп и заправить бак в случаяный момент времени
            //В случае если пользователь выберет заправить ему дольётся бензин в бак на значение от 1 до 10
            //В случае не остановки пользователь просто едет дальше
            Random rng = new Random();
            int LenghtOfWay = rng.Next(50);
            Wheels frontLeftWheel = new Wheels("Переднее левое", 18);
            Wheels frontRightWheel = new Wheels("Переднее правое", 18);
            Wheels rearLeftWheel = new Wheels("Заднее левое", 18);
            Wheels rearRightWheel = new Wheels("Заднее правое", 18);
            gas gas = new gas(20);
            Engine myEngine = new Engine("V8 Turbo", 500);
            ProgresBar progresbar = new ProgresBar(20);
            Car myCar = new Car("Спортивная машина", myEngine, new Wheels[] { frontLeftWheel, frontRightWheel, rearLeftWheel, rearRightWheel },gas);


            myCar.getCarInfo();
        }
    }


    public interface IProgres
    {
        void GenerateProgres(int levelProgres);
    }
    
    public class ProgresBar : IProgres 
    {
        private int levelProgres;

        public ProgresBar(int levelProgres)
        {
            levelProgres = levelProgres;
        }

        public void GenerateProgres(int levelProgres)
        {
            Random randomStop = new Random();
            int StopOrNot;
            levelProgres = 0;
            for (int i =0 ; levelProgres < 10; levelProgres++, i++)
            {
                StopOrNot = randomStop.Next(1);
                if(StopOrNot == 1)
                {
                    
                }
                Thread.Sleep(2000);
            }
        }

    }

    public class Car
    {
        private string nameModel;
        private Engine engine;
        private Wheels[] wheels;
        private gas gas;

        public Car(string nameModel, Engine engine, Wheels[] wheels, gas gas)
        {
            this.nameModel = nameModel;
            this.engine = engine;
            this.wheels = wheels;
            this.gas = gas;
        }

        public void getCarInfo()
        {
            Console.WriteLine("Модель машины: " + nameModel);
            engine.getEngineInfo();

            foreach (var wheel in wheels)
            {
                wheel.getName();
            }
        }
    }

   

    public class gas
    {
        private int levelOfGas;
        public gas(int level)
        {
            levelOfGas = level;
        }
    }

    public interface IEngine
    {
        void getEngineInfo();
    }

    public class Engine : IEngine
    {
        private string nameEngine;
        private int powerLevel;

        public Engine(string name, int power)
        {
            nameEngine = name;
            powerLevel = power;
        }

        public void getEngineInfo()
        {
            Console.WriteLine("Имя движка: " + nameEngine + ", Мощность: " + powerLevel + " л.с.");
        }
    }

    public interface IWheelInfo
    {
        void getName();
    }

    public class Wheels : IWheelInfo
    {
        private string nameWheels;
        private double sizeWheel;

        public Wheels(string name, double size)
        {
            nameWheels = name;
            sizeWheel = size;
        }

        public void getName()
        {
            Console.WriteLine("Имя колеса: " + nameWheels + ", Размер: " + sizeWheel);
        }
    }
}
