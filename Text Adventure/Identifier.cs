using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_1
{
    public class Identifier
    {
        private List<string> _identifiers;

        public Identifier(string[] idents)
        {
           _identifiers = new List<string>();
            foreach (string s in idents)
            {
                s.ToLower();
                _identifiers.Add(s); 
            }//(new string[]
           // { "Bob", "Fred", "George", "Matt", "Wilma", "Johnny"});
        }

        public bool AreYou(string stringID)
        {
            string IdToCheck = stringID.ToLower();
            for (int i = 0; i < _identifiers.Count; i++)
            {
                if (_identifiers[i] == IdToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        public string FirstId
        {
            get { return _identifiers[0]; }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

    }
}
