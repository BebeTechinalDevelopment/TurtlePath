namespace TurtlePath.Models
{
    public class Cords
    {
        public Cords()
        {
        }

        public Cords(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public void Left()
        {
            X--;
        }
        public void Right()
        {
            X++;
        }
        public void Up()
        {
            Y++;
        }
        public void Down()
        {
            Y--;
        }
    }
}
