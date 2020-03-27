using Model;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XmlData
{
    public abstract class XmlDataManager 
    {

        

        public XmlDataManager()
        {

            var projDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"XML");
            
            Directory.SetCurrentDirectory(projDir);
        }

        protected abstract void SaveChanges();   
    }
}
