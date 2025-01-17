﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTSharp.Controllers.Models
{
    public class IPageParam
    {
        public int offset { get; set; } = 0;
        public int limit { get; set; } = 2;
        public string order { get; set; } = "desc";
        public string where { get; set; } = "";
    }






    public class DeviceParam : IPageParam
    {
        public string TenantId { get; set; }
        public string CustomerId { get; set; }
 
     
        public int DeviceType{ get; set; }

        
        public DateTime[] LastActive { get; set; }
        public bool Online { get; set; }
        public string Name { get; set; }
    }
    public class RulePageParam : IPageParam
    {

        public string Name { get; set; }

        public string Creator { get; set; }
        public DateTime[] CreatTime { get; set; }
    }
    public class DictionaryParam : IPageParam
    {
        public string DictionaryName { get; set; }
        public int DictionaryGroupId { get; set; }
    }


    public class I18NParam : IPageParam
    {
        public string KeyName { get; set; }
     
    }
}
