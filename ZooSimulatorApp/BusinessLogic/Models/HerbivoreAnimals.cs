namespace ZooSimulatorApp.BusinessLogic.Models
{
    internal abstract class HerbivoreAnimals : Animal
    {
        public bool LikeSeed;
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string Name { get => base.Name; set => base.Name = value; }

        public override void Bite(string bittenAnimal) { }

        public override void Eat() { }

        public override void Sleep() { }

        public override void Scream() { }
    }
}