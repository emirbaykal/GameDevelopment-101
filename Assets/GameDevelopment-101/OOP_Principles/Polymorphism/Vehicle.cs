using System;
using UnityEngine;

namespace GameDevelopment_101.OOP_Principles.Polymorphism
{
    class MainProgram : MonoBehaviour
    {
        private void Start()
        {
            Car car = new Car();
            Truck truck = new Truck();
            Bicycle bicycle = new Bicycle();
            
            Vehicle[] vehicles = { car, truck, bicycle }; 
            
            foreach (var vehicle in vehicles)
            {
                vehicle.Move();
            }
        }
    }
    
    public class Vehicle
    {
        public virtual void Move() {}
    }

    public class Car : Vehicle
    {
        public override void Move()
        {
            Debug.Log("Car Move");
        }
    }

    public class Truck : Vehicle
    {
        public override void Move()
        {
            Debug.Log("Truck Move");
        }
    }

    public class Bicycle : Vehicle
    {
        public override void Move()
        {
            Debug.Log("Bicycle Move");
        }
    }
}