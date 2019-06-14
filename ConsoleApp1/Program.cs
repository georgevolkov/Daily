using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           var dataList = new List<Data>();
           dataList.Add(new Data() {Test = "aa"});
           var obj = dataList.LastOrDefault(x => x.Test == "a");
           if(obj == null)
               Console.WriteLine("Data is empty");
            Console.ReadKey();
        }

        class Data
        {
            public string Test { get; set; }
        }

        public class Test : IEquatable<Test>
        {
            private readonly int _id;

            public Test(int id)
            {
                _id = id;
            }

            public static bool operator ==(Test left, Test rigth)
            {
                return Equals(left, rigth);
            }

            public static bool operator !=(Test left, Test rigth)
            {
                return !(left == rigth);
            }

            public bool Equals(Test other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                if (other.GetType() != this.GetType()) return false;
                return _id == other._id;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((Test)obj);
            }

            public override int GetHashCode()
            {
                throw new NotImplementedException();
            }
        }

        public class Test2 : IEqualityComparer<Test2>
        {
            private readonly int _id;

            public Test2(int id)
            {
                _id = id;
            }

            public static bool operator ==(Test2 left, Test2 rigth)
            {
                return object.Equals(left, rigth);
            }

            public static bool operator !=(Test2 left, Test2 rigth)
            {
                return !object.Equals(left, rigth);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals(this, (Test2)obj);
            }

            public bool Equals(Test2 x, Test2 y)
            {
                if (x == null || y == null) return false;
                return ReferenceEquals(x, y) || x._id.Equals(y._id);
            }

            public int GetHashCode(Test2 obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}
