namespace Generics
{
    public class Point<T, D> where D : ISummable, new()
                             where T : struct
    {
        public T X;
        public D Y;

        public string Sum(T X, D Y)
        {
            return X.ToString() + Y.ToString(); 
        }
    }
}
