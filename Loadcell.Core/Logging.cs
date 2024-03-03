using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadCell.Core
{
    internal class Logging : ILog<float>
    {
        private static List<float> log = new();
        private float valueIn;
        public float ValueIn { set => valueIn = value; }
        public int MaxLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddObject(float obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteObject(int id)
        {
            throw new NotImplementedException();
        }

        public float GetObject(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(float obj)
        {
            throw new NotImplementedException();
        }
    }
}
