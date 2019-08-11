﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;
using WPF_App.Model;
using WPF_App.View;

namespace WPF_App.Controller
{
    public class MyController
    {
        private static DispatcherTimer _timer = new DispatcherTimer();
        private User _user = new User();
        private List<BasicImprovement> _basicImprovements = new List<BasicImprovement>();
        private MyView _view = new MyView();
        private BonusImprovement _doubleClicker = new BonusImprovement(200);
        private BonusImprovement _doublePointer = new BonusImprovement(1000);

        public User User { get => _user; set => _user = value; }
        public MyView View { get => _view; set => _view = value; }
        public static DispatcherTimer Timer { get => _timer; set => _timer = value; }
        public List<BasicImprovement> BasicImprovements { get => _basicImprovements; set => _basicImprovements = value; }
        public BonusImprovement DoubleClicker { get => _doubleClicker; set => _doubleClicker = value; }
        public BonusImprovement DoublePointer { get => _doublePointer; set => _doublePointer = value; }

        // CONSTRUCTOR
        public MyController()
        {
            Timer.Tick += new EventHandler(AddPointsPerSecond);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        // METHODS
        public void AddBasicImprovements(params BasicImprovement[] basicImprovements)
        {
            for(int i = 0; i < basicImprovements.Length; i++)
            {
                BasicImprovements.Add(basicImprovements[i]);
            }
        }

        public void AddUser(User user) => User = user;
        public void LinkView(MyView view) => View = view;
        public void ChargeUser(double points) => User.Points -= points;
        public void AddPointsToUser(double points) => User.Points += points;
        public void IncreaseUserAdditionSpeed(double speed) => User.SpeedOfAddingPoints += speed;
        public void UpgradeBasicImprovement(int index)
        {
            BasicImprovements[index].Upgrade();
        }
        private void AddPointsPerSecond(object sender, EventArgs e)
        {
            if(DoublePointer.NumberOfUpgrades >= 1)
            {
                double speed = User.SpeedOfAddingPoints * Math.Pow(2, DoublePointer.NumberOfUpgrades);
                User.Points += speed;
                View.SetSpeedOfAddingPointsLabelText(speed);
            }
            else
            {
                User.Points += User.SpeedOfAddingPoints;
                View.SetSpeedOfAddingPointsLabelText(User.SpeedOfAddingPoints);
            }
            View.SetScoreLabelText(User.Points);
            
        }

    }
}
