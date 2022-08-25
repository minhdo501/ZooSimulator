using System;

namespace ZooSimulatorApp.BusinessLogic.Events
{
    internal class AnimalsMakeSoundEvent : EventArgs
    {
        private string sound { get; set; }
        public string Sound
        {
            get { return sound; }
        }

        public AnimalsMakeSoundEvent(string value)
        {
            sound = value;
        }
    }
}