namespace TheRace
{
    public class Car
    {
        public Car(string name, int speed)
        {
            this.Name = name;
            this.Speed = speed;
        }

        public string Name { get; private set; }

        public int Speed { get; private set; }
    }
}
