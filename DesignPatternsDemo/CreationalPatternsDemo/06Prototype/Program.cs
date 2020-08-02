namespace Prototype
{
    public class Program
    {
        public static void Main()
        {
            ColorController colorController = new ColorController
            {
                ["yellow"] = new Color(255, 255, 0),
                ["orange"] = new Color(255, 128, 0),
                ["purple"] = new Color(128, 0, 255),
                ["sunny"] = new Color(255, 54, 0),
                ["tasty"] = new Color(255, 153, 51),
                ["rainy"] = new Color(255, 0, 255)
            };



            Color c1 = colorController["yellow"].Clone() as Color;
            Color c2 = colorController["tasty"].Clone() as Color;
            Color c3 = colorController["rainy"].Clone() as Color;
        }
    }
}