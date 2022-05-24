using GameTest.Models;
using System;

namespace GameTestAPI.Controllers
{
    public class ParametersBL
    {
        protected ParametersDH ParametersDH;

        public ParametersBL()
        {
            ParametersDH = new ParametersDH();
        }
               
        public string GetDefaultParams()
        {
            return ParametersDH.GetDefaultParams();
        }
    }
}
