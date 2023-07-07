using System;
using System.Collections;
using System.Collections.Generic;

//ref link:https://www.youtube.com/watch?v=Or9g8LOhXhg&list=PL9B5E4C37F7B234A8&index=3
//

class MainClass
{
    class GetRandomNumbersClass : IEnumerable<int>, IEnumerator<int>
    {
        //public int Current => throw new NotImplementedException();
        //object IEnumerator.Current => throw new NotImplementedException();

        public int count;
        public int i;
        int current;
        int state; // keeps track of loop

        public bool MoveNext() // this call means -- move to the next random number
        {
            //throw new NotImplementedException();
            //for (int i = 0; i < count; i++)
            //    yield return rand.Next();
            switch (state)
            {
                case 0:
                    i = 0;
                    goto case 1;
                case 1:
                    state = 1;
                    if (!(i < count))
                        return false;
                    current = MainClass.rand.Next();
                    state = 2;
                    return true;
                case 2:
                    i++;
                    //break;
                    goto case 1;
            }
            return false;
        }

        public int Current
        {
            //get { throw new NotImplementedException(); }
            get { return current; }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
        public void Dispose() { }
        //object System.Collections.IEnumerator.Current
        object IEnumerator.Current  // ctrl+mm(collapse line)
        {
            //get { throw new NotImplementedException(); }
            get { return Current; } // will result none explicitly in (public int Current)
        }
        public IEnumerator<int> GetEnumerator()
        {
            //throw new NotImplementedException();
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();
            return GetEnumerator(); // call none explicitly implemented
        }
    }
    static Random rand = new Random(); // one static random required
    
    static IEnumerable<int> GetRandomNumbers(int count)
    {
        //return new GetRandomNumbersClass();
        //return new GetRandomNumbersClass { count = count };
        GetRandomNumbersClass ret = new GetRandomNumbersClass();
        ret.count = count;
        return ret;
        //for (int i = 0; i < count; i++)
        //    yield return rand.Next();
    }
    static void Main()
    {
        foreach (int num in GetRandomNumbers(10)) // in(enumerator) requires knowledge in foreach
            Console.WriteLine(num);
    }
}