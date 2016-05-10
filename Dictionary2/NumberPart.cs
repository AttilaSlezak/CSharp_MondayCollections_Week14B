using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary2
{
    class NumberPart
    {
        private bool _beginning = false;
        private bool _ending = false;
        private int _position;
        private int _strLong;
        private int _numLong;
        private string _value;

        public bool Beginning { get { return _beginning; } set { _beginning = value; } }
        public bool Ending { get { return _ending; } set { _ending = value; } }
        public int Position { get { return _position; } set { _position = value; } }
        public int StrLong { get { return _strLong; } set { _strLong = value; } }
        public int NumLong { get { return _numLong; } set { _numLong = value; } }
        public string Value { get { return _value; } set { _value = value; } }

        public NumberPart(int position, int strLong, int numLong, string value)
        {
            _position = position;
            _strLong = strLong;
            _numLong = numLong;
            _value = value;
        }
    }
}
