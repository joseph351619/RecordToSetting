using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordToSetting
{
    public class CsvWriter<T> where T : CsvableBase
    {
        public void Write(IEnumerable<T> objects, string destination)
        {
            var objs = objects as IList<T> ?? objects.ToList();
            if (objs.Any())
            {
                using (StreamWriter sw = new StreamWriter(destination))
                {
                    foreach(var obj in objs)
                    {
                        sw.WriteLine(obj.ToCSV());
                    }
                }
            }
        }
        public void Write(IEnumerable<T> objects, string destination,
                            string[] propertyNames, bool isIgnore)
        {
            var objs = objects as IList<T> ?? objects.ToList();
            if (objs.Any())
            {
                using (StreamWriter sw = new StreamWriter(destination))
                {
                    foreach(var obj in objs)
                    {
                        sw.WriteLine(obj.ToCSV(propertyNames, isIgnore));
                    }
                }
            }
        }
    }
}
