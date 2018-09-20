using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordToSetting
{
    public abstract class CsvableBase
    {
        public virtual string ToCSV()
        {
            string output = string.Empty;
            var properties = GetType().GetProperties();
            for (int i = 0; i < properties.Length; ++i)
            {
                if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                {
                    var property = properties[i].PropertyType.GetMethod("ToCSV", new Type[0]);
                    output += property.Invoke(properties[i].GetValue(this), new object[0]);
                }
                else
                {
                    output += Preprocess($"{properties[i].GetValue(this)}");
                }
                if (i != properties.Length-1)
                {
                    output += ",";
                }
            }
            return output;
        }
        public virtual string ToCSV(string[] propertiesName, bool isIgnore)
        {
            string output = string.Empty;
            bool isFirstPropertyWritten = false;
            var properties = GetType().GetProperties();
            for(int i=0; i<properties.Length; ++i)
            {
                if (isIgnore)
                {
                    if (!propertiesName.Contains(properties[i].Name))
                    {
                        if (isFirstPropertyWritten)
                        {
                            output += ",";
                        }
                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var property = properties[i].PropertyType.GetMethod("ToCSV", new Type[0]);
                            output += property.Invoke(properties[i].GetValue(this), new object[0]);
                        }
                        else
                        {
                            output += Preprocess($"{properties[i].GetValue(this)}");
                        }
                        if (!isFirstPropertyWritten)
                        {
                            isFirstPropertyWritten = true;
                        }
                    }
                }
                else
                {
                    if (!propertiesName.Contains(properties[i].Name))
                    {
                        if(isFirstPropertyWritten)
                        {
                            output += ",";
                        }
                        if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                        {
                            var property = properties[i].PropertyType.GetMethod("ToCSV", new Type[0]);
                            output += property.Invoke(properties[i].GetValue(this), new object[0]);
                        }
                        else
                        {
                            output += Preprocess($"{properties[i].GetValue(this)}");
                        }
                        if (!isFirstPropertyWritten)
                        {
                            isFirstPropertyWritten = true;
                        }
                    }
                }
            }
            return output;
        }
        private string Preprocess(string input)
        {
            input = input.Replace("\"", "\"\"");
            if (input.Contains(","))
            {
                input = "\"" + input + "\"";
            }
            return input;
        }

        public virtual void AssignValueFromCsv(string[] propertyValue)
        {
            var properties = GetType().GetProperties();
            for(int i=0;i < properties.Length; ++i)
            {
                if (properties[i].PropertyType.IsSubclassOf(typeof(CsvableBase)))
                {
                    var instance = Activator.CreateInstance(properties[i].PropertyType);
                    var instanceProperties = instance.GetType().GetProperties();
                    var propertyList = new List<string>();
                    for (int j = 0; j < instanceProperties.Length; ++j)
                    {
                        propertyList.Add(propertyValue[i + j]);
                    }
                    var m = instance.GetType().GetMethod("AssignValueFromCsv", new Type[] {typeof(string[])});
                    m.Invoke(instance, new object[] { properties.ToArray() });
                    properties[i].SetValue(this, instance);
                    i += instanceProperties.Length;
                }
                else
                {
                    var type = properties[0].PropertyType.Name;
                    switch (type)
                    {
                        case "Int32":
                            properties[i].SetValue(this, int.Parse(propertyValue[i]));
                            break;
                        default:
                            properties[i].SetValue(this, propertyValue[i]);
                            break;
                    }
                }
            }
        }
    }
}
