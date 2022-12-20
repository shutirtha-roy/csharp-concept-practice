namespace Generics
{
    public class Point<T, D>
    {
        public T X;
        public D Y;

        public string Sum(T X, D Y)
        {
            return X.ToString() + Y.ToString(); 
        }
    }
}
