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
        private int _currNumLong;
        private string _value;
        private string _valueToDisplay;

        public bool Beginning { get { return _beginning; } set { _beginning = value; } }
        public bool Ending { get { return _ending; } set { _ending = value; } }
        public int Position { get { return _position; } }
        public int StrLong { get { return _strLong; } }
        public int NumLong { get { return _numLong; } }
        public int CurrNumLong { get { return _currNumLong; } set { _currNumLong = value; } }
        public string Value { get { return _value; } }
        public string ValueToDisplay { get { return _valueToDisplay; } set { _valueToDisplay = value; _currNumLong = _valueToDisplay.Length; } }

        public NumberPart(int position, int strLong, int numLong, string value)
        {
            _position = position;
            _strLong = strLong;
            _numLong = numLong;
            _value = value;
            _valueToDisplay = value;
        }
    }
}
