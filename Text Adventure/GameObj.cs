using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_1
{
    public abstract class GameObj : Identifier
    {
        private string _description;
        private string _name;

        public GameObj (string[] ids, string name, string desc)
            : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get
            {
                string _shortDescription = _name.ToLower() + " (" + FirstId.ToLower() + ")";
                return _shortDescription;
            }
        }

        public virtual string FullDescription
        {
            get { return _description; }
        }
    }
}
