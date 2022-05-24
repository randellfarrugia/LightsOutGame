using GameTest.Models;
using System;

namespace GameTest
{
    public class DataHandling
    {
        public PostClass posts = new PostClass();
        public string baseURL = "";
        public string DefaultSwitchedOnColour = "LightGreen";
        public string DefaultSwitchedOffColour = "ForestGreen";
        public Int32 DefaultNumberOfLightsSwitchedOn = 5;
        public Int32 DefaultBoardSize = 5;

        Params parameters;


        public DataHandling()
        {
            baseURL = "https://localhost:44378/api/";
            parameters = new Params();
        }

        public Params GetParams()
        {
            //Sending Request to REST API to get all params
            var url = baseURL + "Parameters/GetDefaultParams";
            string resp = posts.PostFormReturn(url, "GET");

            if (String.IsNullOrEmpty(resp) == false)
            {
                try
                {
                    parameters = Newtonsoft.Json.JsonConvert.DeserializeObject<Params>(resp);
                }
                catch
                {
                    parameters = new Params() { SwitchedOnColour = DefaultSwitchedOnColour, SwitchedOffColour = DefaultSwitchedOffColour, NumberOfLightsOn = DefaultNumberOfLightsSwitchedOn, BoardSize = DefaultBoardSize };
                }
            }
            else
            {
                parameters = new Params() { SwitchedOnColour = DefaultSwitchedOnColour, SwitchedOffColour = DefaultSwitchedOffColour, NumberOfLightsOn = DefaultNumberOfLightsSwitchedOn, BoardSize = DefaultBoardSize };
            }

            return parameters;
        }
    }


}
