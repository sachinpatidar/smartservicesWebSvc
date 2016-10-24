using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace smartservicesapp.Repository
{
    public enum FileType
    {
        UserProfile=1, BlogImage=2

    }

    [DataContract]
    public partial class UserRegister 
    {

        [DataMember]
        public string FileName { get; set; }
    }

    

}