using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary2
{
    class DictionaryTask
    {
            private static List<NumberPart> _numberParts = new List<NumberPart>();

            private static Dictionary<string, string> _numbersEng = new Dictionary<string, string>
            {
                {"zero", "0"},
                {"one", "1"},
                {"two", "2"},
                {"three", "3"},
                {"four", "4"},
                {"five", "5"},
                {"six", "6"},
                {"seven", "7"},
                {"eight", "8"},
                {"nine", "9"},
                {"ten", "10"},
                {"eleven", "11"},
                {"twelve", "12"},
                {"thirteen", "13"},
                {"fourteen", "14"},
                {"fifteen", "15"},
                {"sixteen", "16"},
                {"seventeen", "17"},
                {"eighteen", "18"},
                {"nineteen", "19"},
                {"twenty", "20"},
                {"thirty", "30"},
                {"forty", "40"},
                {"fifty", "50"},
                {"sixty", "60"},
                {"seventy", "70"},
                {"eighty", "80"},
                {"ninety", "90"},
                {"hundred", "100"},
                {"thousand", "1000"},
                {"million", "1000000"},
                {"billion", "1000000000"},
                {"trillion", "1000000000000"},
                {"quadrillion", "1000000000000000"},
                {"quintillion", "1000000000000000000"}
            };

        private static void CollectNumberParts(string text)
        {
            int positionInStr = 0;

            foreach (KeyValuePair<string, string> oneNum in _numbersEng)
            {
                int currentPos = 0;
                while ((positionInStr = text.ToLower().Substring(currentPos).IndexOf(oneNum.Key)) > -1)
                {
                    if ((positionInStr + currentPos + oneNum.Key.Length + 2 > text.Length 
                        || !((oneNum.Value == "6" || oneNum.Value == "7" || oneNum.Value == "9")
                        && text.Substring(positionInStr + currentPos + oneNum.Key.Length, 2) == "ty"))
                        && (positionInStr + currentPos + oneNum.Key.Length + 4 > text.Length
                        || !((oneNum.Value == "4" || oneNum.Value == "6" || oneNum.Value == "7" || oneNum.Value == "8" || oneNum.Value == "9")
                        && text.Substring(positionInStr + currentPos + oneNum.Key.Length, 4) == "teen")))
                    {
                        _numberParts.Add(new NumberPart(positionInStr + currentPos, oneNum.Key.Length, oneNum.Value.Length, oneNum.Value));
                    }
                    currentPos += positionInStr + oneNum.Key.Length;
                }
            }
        }

        private static void SortNumberParts()
        {
            NumberPartPosComparer numPartPosComparer = new NumberPartPosComparer();
            _numberParts.Sort(numPartPosComparer);
        }

        private static void RemoveWordPartsFromNumList(string text)
        {
            Regex pattern = new Regex("[A-Za-z]"); 
            
            for (int i = 0; i < _numberParts.Count; i++)
            {
                if (_numberParts.Count == 1)
                {
                    if ((_numberParts[0].Position > 0 && pattern.IsMatch(text[_numberParts[0].Position - 1].ToString()))
                        || (text.Length > _numberParts[0].Position + _numberParts[0].StrLong
                        && pattern.IsMatch(text[_numberParts[0].Position + _numberParts[0].StrLong].ToString())))
                    {
                        _numberParts.RemoveAt(0);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                else if (i < _numberParts.Count - 1
                    && _numberParts[i].Position + _numberParts[i].StrLong < _numberParts[i + 1].Position)
                {
                    if (pattern.IsMatch(text[_numberParts[i].Position + _numberParts[i].StrLong].ToString())
                        || (_numberParts[i].Position != 0 && pattern.IsMatch(text[_numberParts[i].Position - 1].ToString())))
                    {
                        _numberParts.RemoveAt(i);
                        i--;
                        continue;
                    }
                }

                else if (i == _numberParts.Count - 1
                    && _numberParts[i - 1].Position + _numberParts[i - 1].StrLong < _numberParts[i].Position)
                {
                    if (pattern.IsMatch(text[_numberParts[i].Position - 1].ToString())
                        || (_numberParts[i].Position + _numberParts[i].StrLong != text.Length 
                        && pattern.IsMatch(text[_numberParts[i].Position + _numberParts[i].StrLong].ToString())))
                    {
                        _numberParts.RemoveAt(i);
                    }
                }
            }
        }

        private static void SearchBeginAndEndOfNums(string text)
        {
            _numberParts[0].Beginning = true;
            _numberParts[_numberParts.Count - 1].Ending = true;

            for (int i = 0; i < _numberParts.Count - 1; i++)
            {
                if ((_numberParts[i].Position + _numberParts[i].StrLong == _numberParts[i + 1].Position - 1)
                    && !(text[_numberParts[i + 1].Position - 1] == ' ' || text[_numberParts[i + 1].Position - 1] == '-'))
                {
                    _numberParts[i].Ending = true;
                    _numberParts[i + 1].Beginning = true;
                }
                else if ((_numberParts[i].Position + _numberParts[i].StrLong == _numberParts[i + 1].Position - 1)
                    && text[_numberParts[i + 1].Position - 1] == '-' && !(_numberParts[i].NumLong == 2 && _numberParts[i + 1].NumLong == 1))
                {
                    _numberParts[i].Ending = true;
                    _numberParts[i + 1].Beginning = true;
                }
                else if ((_numberParts[i].Position + _numberParts[i].StrLong <= _numberParts[i + 1].Position - 3)
                    && ((text.Substring(_numberParts[i + 1].Position - 5, 5) != " and " 
                    || (_numberParts[i].Position + _numberParts[i].StrLong) != _numberParts[i + 1].Position - 5)
                    || !(_numberParts[i].NumLong == 3 && (_numberParts[i + 1].NumLong == 2 || _numberParts[i + 1].NumLong == 1))))
                {
                    _numberParts[i].Ending = true;
                    _numberParts[i + 1].Beginning = true;
                }
                else if ((_numberParts[i].Position + _numberParts[i].StrLong == _numberParts[i + 1].Position - 2)
                    && (text.Substring(_numberParts[i + 1].Position - 2, 2) != ", " || !((_numberParts[i].NumLong - 1) % 3 == 0)))
                {
                    _numberParts[i].Ending = true;
                    _numberParts[i + 1].Beginning = true;
                }
                else if (_numberParts[i].NumLong == 3 && _numberParts[i + 1].NumLong == 3)
                {
                    _numberParts[i].Ending = true;
                    _numberParts[i + 1].Beginning = true;
                }
                else if (_numberParts.Count > i + 2
                    && _numberParts[i].NumLong == 3 && _numberParts[i + 1].NumLong == 1 && _numberParts[i + 2].NumLong == 3)
                {
                    _numberParts[i].Ending = true;
                    _numberParts[i + 1].Beginning = true;
                }
                else if (_numberParts[i].NumLong == 2 && (_numberParts[i + 1].NumLong == 2 || _numberParts[i + 1].NumLong == 3))
                {
                    _numberParts[i].Ending = true;
                    _numberParts[i + 1].Beginning = true;
                }
                else if (_numberParts.Count > i + 2
                    && _numberParts[i].NumLong == 2 && _numberParts[i + 1].NumLong == 1 && _numberParts[i + 2].NumLong == 3)
                {
                    if (text[_numberParts[i + 1].Position - 1] == '-')
                    {
                        _numberParts[i + 1].Ending = true;
                        _numberParts[i + 2].Beginning = true;
                    }
                    else
                    {
                        _numberParts[i].Ending = true;
                        _numberParts[i + 1].Beginning = true;
                    }
                }
                else if (_numberParts[i].NumLong == 1 && (_numberParts[i + 1].NumLong == 1 || _numberParts[i + 1].NumLong == 2))
                {
                    _numberParts[i].Ending = true;
                    _numberParts[i + 1].Beginning = true;
                }
            }

            int lastDivisibleByThousand = 0;
            for (int i = 0; i < _numberParts.Count; i++)
            {
                if (_numberParts[i].Beginning)
                    lastDivisibleByThousand = 0;

                if (lastDivisibleByThousand != 0 && _numberParts[i].NumLong >= lastDivisibleByThousand)
                {
                    _numberParts[i - 1].Ending = true;
                    _numberParts[i].Beginning = true;
                }

                if (_numberParts[i].NumLong > 3 && (_numberParts[i].NumLong - 1) % 3 == 0)
                    lastDivisibleByThousand = _numberParts[i].NumLong;
            }
        }

        private static void CreateDisplayableValues()
        {
            for (int i = 0; i < _numberParts.Count; i++)
            {
                if (!_numberParts[i].Ending && i < _numberParts.Count - 1)
                {
                    if (_numberParts[i].NumLong == 2 && _numberParts[i + 1].NumLong == 1)
                    {
                        _numberParts[i].ValueToDisplay = _numberParts[i].ValueToDisplay[0].ToString();
                    }
                    else if (_numberParts[i].NumLong == 3 && _numberParts[i + 1].NumLong == 2)
                    {
                        _numberParts[i].ValueToDisplay = _numberParts[i].ValueToDisplay.Substring(0, _numberParts[i].CurrNumLong - 2);
                    }
                    else if (_numberParts[i].NumLong == 3 && _numberParts[i + 1].NumLong == 1)
                    {
                        _numberParts[i].ValueToDisplay = _numberParts[i].ValueToDisplay.Substring(0, _numberParts[i].CurrNumLong - 1);
                    }
                    else if ((_numberParts[i].NumLong - 1) % 3 == 0 && _numberParts[i].NumLong != 1)
                    {
                        for (int j = i + 1; j < _numberParts.Count && j <= i + 5; j++)
                        {
                            if (!_numberParts[j].Beginning)
                            {
                                if (j == i + 1 && (_numberParts[j].NumLong == 2 || _numberParts[j].NumLong == 3))
                                {
                                    _numberParts[i].ValueToDisplay = _numberParts[i].ValueToDisplay.Substring(0, _numberParts[i].CurrNumLong - _numberParts[j].NumLong);
                                }
                                else if (_numberParts[j].NumLong == 1)
                                {
                                    if (j + 1 < _numberParts.Count && _numberParts[j + 1].NumLong == 3)
                                    {
                                        _numberParts[i].ValueToDisplay = _numberParts[i].ValueToDisplay.Substring(0, _numberParts[i].CurrNumLong - 3);
                                    }
                                    else if (_numberParts[j - 1].NumLong != 3 && _numberParts[j - 1].NumLong != 2)
                                    {
                                        _numberParts[i].ValueToDisplay = _numberParts[i].ValueToDisplay.Substring(0, _numberParts[i].CurrNumLong - 1);
                                    }
                                }

                                if (j + 1 < _numberParts.Count && (_numberParts[j + 1].NumLong - 1) % 3 == 0 && _numberParts[j + 1].NumLong != 1)
                                {
                                    _numberParts[i].ValueToDisplay = _numberParts[i].ValueToDisplay.Substring(0, _numberParts[i].CurrNumLong - (_numberParts[j + 1].NumLong - 1));
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (_numberParts[i].NumLong == 1 && _numberParts[i + 1].NumLong == 3)
                    {
                        _numberParts[i + 1].ValueToDisplay = _numberParts[i + 1].ValueToDisplay.Substring(1);
                    }
                    else if ((_numberParts[i].NumLong == 3 || _numberParts[i].NumLong == 2 || _numberParts[i].NumLong == 1) 
                            && (_numberParts[i + 1].NumLong - 1) % 3 == 0 && _numberParts[i + 1].NumLong != 1)
                    {
                        _numberParts[i + 1].ValueToDisplay = _numberParts[i + 1].ValueToDisplay.Substring(1);
                    }
                }
            }
        }

        public static void PrintTextWithDigits(string text)
        {
            CollectNumberParts(text);
            SortNumberParts();
            RemoveWordPartsFromNumList(text);
            if (_numberParts.Count > 0)
            {
                SearchBeginAndEndOfNums(text);
                CreateDisplayableValues();
            }
            int lastEndPos = 0;
            Console.Write("\nThe result:\n\t");

            foreach (NumberPart oneNumPart in _numberParts)
            {
                if (oneNumPart.Beginning)
                Console.Write(text.Substring(lastEndPos, oneNumPart.Position - lastEndPos));

                Console.Write(oneNumPart.ValueToDisplay);

                if (oneNumPart.Ending)
                    lastEndPos = oneNumPart.Position + oneNumPart.StrLong;
            }
            Console.WriteLine(text.Substring(lastEndPos) + "\n");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("This application gives a text and change the written numbers in it to numerals.");
            Console.Write("Please write the text here: ");
            string text = Console.ReadLine();

            PrintTextWithDigits(text);

            foreach (NumberPart oneNumPart in _numberParts)
            {
                Console.WriteLine(oneNumPart.Value + ", pos: " + oneNumPart.Position + ", begin: " + oneNumPart.Beginning + ", end: " 
                    + oneNumPart.Ending);
            }
        }
    }
}
