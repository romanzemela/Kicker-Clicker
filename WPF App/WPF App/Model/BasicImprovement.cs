﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Model
{
    public class BasicImprovement: Improvement
    {
        private double _startingSpeed;

        public double SpeedOfAddingPoints { get => _startingSpeed; set => _startingSpeed = value; }

        // CONSTRUCTORS
        public BasicImprovement()
        {

        }
        public BasicImprovement(int startingPrice, double startingSpeed, int levelRequired)
        {
            NumberOfUpgrades = 0;
            StartingPrice = startingPrice;
            CurrentPrice = startingPrice;
            SpeedOfAddingPoints = startingSpeed;
            LevelRequired = levelRequired;
        }
        // METHODS 
        public override void Upgrade()
        {
            NumberOfUpgrades++;
            CurrentPrice = Convert.ToInt32(StartingPrice * Math.Pow(1.15, NumberOfUpgrades)); 
        }
    }
}
