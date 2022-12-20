namespace Generics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Point
            //var pointOne = new Point<int, double>();
            //pointOne.X = 5;
            //pointOne.Y = 5.5;

            //var result = pointOne.X + pointOne.Y;
            //Console.WriteLine(result);

            //Now we are add Item as it implemented ISummable
            //var pointTwo = new Point<int, Item>();
            #endregion

            #region Tree
            Tree<string> tree = new Tree<string>();
            tree.AddNode("Mango Tree");
            tree.AddNode("Banana Tree");
            Console.WriteLine(tree.DeleteNode("Banana Tree"));
            #endregion
        }
    }
}

