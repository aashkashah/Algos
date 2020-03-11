using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Diverse
{
    class Test
    {
        // Input
        //{
        //  "k1": "v1",
        //  "k2": "v2",
        //  "k3": {
        //    "k4" :  "v4"
        //  }
        //}

        // Query
        //{
        //  "k1": "v1",
        //  "k3": {
        //    "k4" :  "v4"
        //  }
        // "k2": "v2",
        //}

        public bool IsMatchFound(Dictionary<string, object> input, Dictionary<string, object> query)
        {
            if (query.Count == 0)
            {
                return true;
            }

            if (input.Count == 0)
            {
                return false;
            }

            foreach (var keyVal in query)
            {
                var key = keyVal.Key;
                var val = keyVal.Value;

                if (input.ContainsKey(key))
                {
                    var inputValue = input[key];
                    if (inputValue is string && val is string)
                    {
                        if (val != inputValue)
                        {
                            return false;
                        }
                    }
                    else if (input is Dictionary<string, object> && val is Dictionary<string, object>)
                    {
                        var res = IsMatchFound((Dictionary<string, object>)inputValue, (Dictionary<string, object>)val);
                        if (res == false)
                            return false;
                    }
                    else 
                    {
                        return false;
                    }
                }
                else 
                {
                    return false;
                }
            }

            return true;
        }

        //bool Test1() 
        //{
        //    //{
        //    //  "k1": "v1",
        //    //  "k2": "v2",
        //    //  "k3": {
        //    //    "k4" :  "v4"
        //    //  }
        //    //}


        //    // QUery
        //    //{
        //    //  "k1": "v1",
        //    //  "k3": {
        //    //    "k5" :  "v4"
        //    //  }
        //    // "k2": "v2",
        //    //}


        //    //{
        //    //  "k1": "v1",
        //    //  "k2": "v2",
        //    //  "k3": {
        //    //    "k4" :  "v4"
        //    //  }
        //    //}


        //    // QUery
        //    //{
        //    //  "k7": "v1",
        //    //  
        //    //}

        //    //{
        //    //  "k1": "v1",
        //    //  "k2": "v2",
        //    //  "k3": {
        //    //    "k4" :  "v4"
        //    //  }
        //    //}


        //    // QUery
        //    //{
        //    //  "k1": {
        //    //    "k1": {
        //    //    "k4" :  "v4"
        //    //  }
        //    //  
        //    //}

        //}


    }
}
