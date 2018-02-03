using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Charts.ViewModels
{
    public class ViewModelBase<T> where T : class,new()
    {
        public ViewModelBase()
        {

        }
        public T Restore()
        {
            Type t = typeof(T);
            var serializer = new System.Xml.Serialization.XmlSerializer(t);
            try
            {
                var fileName = t.ToString() + ".xml";
                using (System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false)))
                {
                    var v = serializer.Deserialize(sr);
                    return v as T;
                }
            }
            catch (System.IO.IOException)
            {
                return new T();
            }
        }
        public void Store(T value)
        {
            Type t = typeof(T);

            var fileName = t.ToString() + ".xml";

            var serializer = new System.Xml.Serialization.XmlSerializer(t);
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    fileName, false, new System.Text.UTF8Encoding(false)))
                {
                    serializer.Serialize(sw, value);
                }
            }
            catch { }
        }
    }
}
