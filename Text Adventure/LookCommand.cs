using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Iteration_1
{
    public class LookCommand : Command
    {
        public LookCommand() : base (new string[] { "look" })
        {
        }

        public override string Execute (Player p, string[] text)
        {
            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0] == "look")
                {
                    if (text[1] == "at")
                    {
                        if (text.Length == 3)
                        {
                            return LookAtIn(text[2], p);
                        }
                        else
                        {
                            if (text[3] == "in")
                            {
                                if (FetchContainer(p, text[4]) == null)
                                {
                                    return "Cannot find " + text[4];
                                }
                                else
                                {
                                    return LookAtIn(text[2], FetchContainer(p, text[4]));
                                }
                            }
                            else
                            {
                                return "Cannot find something to look at";
                            }
                        }
                    }
                    else
                    {
                        return "Cannot find something to look at";
                    }
                }
                else
                {
                    return "Cannot find something to look at";
                }
            }
            else
            {
                return "Invalid input";
            }
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn (string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null)
            {
                return "Cannot find " + thingId;
            }
            else
            {
                return container.Locate(thingId).FullDescription;
            }
        }
    }
}
