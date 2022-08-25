using System;

namespace ZooSimulatorApp.BusinessLogic.Events
{
    internal class CageHasFoodEvent : EventArgs
    {
        private string food { get; set; }
        public string Food
        {
            get { return food; }
        }

        public CageHasFoodEvent(string value)
        {
            food = value;
        }
    }
}