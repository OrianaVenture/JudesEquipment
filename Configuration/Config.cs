using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudesEquipment.Configuration
{
    public class Config
    {
        public string configHeader;
        public ConfigFile cfg;

        //objs = random parameters i might need
        public virtual bool Load(object[] objs)
        {
            return true;
        }

        public virtual bool ApplyConfig(object[] objs)
        {
            return true;
        }
    }
}
