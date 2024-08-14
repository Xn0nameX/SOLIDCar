using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace tryOOPSomeShit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wheels frontLeftWheel = new Wheels("Переднее левое", 18);
            Wheels frontRightWheel = new Wheels("Переднее правое", 18);
            Wheels rearLeftWheel = new Wheels("Заднее левое", 18);
            Wheels rearRightWheel = new Wheels("Заднее правое", 18);

            Engine myEngine = new Engine("V8 Turbo", 500);

            Car myCar = new Car("Спортивная машина", myEngine, new Wheels[] { frontLeftWheel, frontRightWheel, rearLeftWheel, rearRightWheel });

            myCar.getCarInfo();
        }
    }

    public class Car
    {
        private string nameModel;
        private Engine engine;
        private Wheels[] wheels;

        public Car(string nameModel, Engine engine, Wheels[] wheels)
        {
            this.nameModel = nameModel;
            this.engine = engine;
            this.wheels = wheels;
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
