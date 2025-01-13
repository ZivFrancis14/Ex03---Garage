﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_LicencePlateNumber;
        private  string m_VehicleModelName;
        private float m_EnergyPercentage;
        private List<Wheel> m_Wheels;
        private  Engine m_Engine;

        public Vehicle(string i_LicencePlateNumber, Engine i_Engine, int i_NumberOfWheels, float i_WheelsMaxPressure)
        {
            m_Engine = i_Engine;
            m_LicencePlateNumber = i_LicencePlateNumber;
            initializeVehicleWheels(i_NumberOfWheels, i_WheelsMaxPressure);
        }
        private void initializeVehicleWheels(int i_NumberOfWheels, float i_WheelsMaxPressure)
        {
            m_Wheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelsMaxPressure));
            }
        }
        public virtual void CompleteVehicleDetails(List<object> i_VehicleDetails)
        {
            ModelName = i_VehicleDetails[0]?.ToString();
            Engine.InitEngine((float)i_VehicleDetails[1]);
            m_EnergyPercentage = Engine.EnergyPrecentage();
            UpdateWheels((float)i_VehicleDetails[2], (string)i_VehicleDetails[3]);
        }
        private void UpdateWheels(float i_AirPressure, string i_ManufacturerName)
        {
            if (i_AirPressure > Wheels[0].MaxAirPressure)
            {
                //throw new ArgumentException($"Air pressure {i_AirPressure} exceeds the maximum allowed pressure {Wheels[0].MaxAirPressure} for this wheel.");
            }

            foreach (Wheel wheel in Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
                wheel.CurrentAirPressure = i_AirPressure;
            }
        }
        public string ModelName
        {
            get
            {
                return m_VehicleModelName;
            }
            set
            {
                m_VehicleModelName = value;
            }
        }
        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Energy percentage must be between 0 and 100.");
                }
                m_EnergyPercentage = value;
            }
        }
        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Wheels list cannot be null or empty.");
                }
                m_Wheels = value;
            }
        }
        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Engine cannot be null.", nameof(value));
                }
                m_Engine = value;
            }
        }
        public string LicencePlate
        {
            get
            {
                return m_LicencePlateNumber;
            }
            set
            {
                m_LicencePlateNumber = value;
            }
        }
    }
}
